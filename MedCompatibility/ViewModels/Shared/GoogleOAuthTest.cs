using Microsoft.Maui.Authentication;
using Microsoft.Maui.ApplicationModel;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class GoogleOAuthTest
{
#if WINDOWS
    // Windows Desktop OAuth Client
    private const string ClientId =
        "285954249476-vb7elrr48v9skunb9vnidndlqnfka734.apps.googleusercontent.com";

    // TODO: вставь секрет сам (из Google Cloud Console)
    private const string ClientSecret = "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";

    private static Uri? _lastLoopbackRedirectUri;
#else
    // Android OAuth Client
    private const string ClientId =
        "285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8.apps.googleusercontent.com";

    private static readonly Uri CallbackUri =
        new("com.googleusercontent.apps.285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8:/oauth2redirect");
#endif

    // Fallback если SecureStorage недоступен (на некоторых Windows-конфигах/запусках)
    private static string? _verifierFallback;

    public class GoogleTokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; set; } = "";
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
        [JsonPropertyName("token_type")] public string TokenType { get; set; } = "";
        [JsonPropertyName("scope")] public string Scope { get; set; } = "";
        [JsonPropertyName("id_token")] public string IdToken { get; set; } = "";
        [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    }

    public sealed class GoogleIdTokenPayload
    {
        public string? sub { get; set; }
        public string? email { get; set; }
        public bool email_verified { get; set; }
        public string? name { get; set; }
        public string? given_name { get; set; }
        public string? family_name { get; set; }
        public string? picture { get; set; }
        public string? aud { get; set; }
        public string? iss { get; set; }
        public long exp { get; set; }
    }

    public static async Task<string?> GetAuthCodeAsync(TimeSpan? timeout = null)
    {
        timeout ??= TimeSpan.FromSeconds(120);

        var verifier = CreateCodeVerifier();
        var challenge = CreateCodeChallenge(verifier);
        await SetPkceVerifierAsync(verifier);

#if WINDOWS
        var (listener, redirectUri) = StartLoopbackListener();
        _lastLoopbackRedirectUri = redirectUri;

        var authUrl = BuildAuthUrl(redirectUri, challenge);

        // Открываем дефолтный браузер
        await Launcher.Default.OpenAsync(new Uri(authUrl));

        // Ждём редиректа (code или error)
        return await WaitForOAuthRedirectAsync(listener, timeout.Value);
#else
        var authUrl = BuildAuthUrl(CallbackUri, challenge);

        try
        {
            var authTask = WebAuthenticator.Default.AuthenticateAsync(new Uri(authUrl), CallbackUri);

            var completed = await Task.WhenAny(authTask, Task.Delay(timeout.Value));
            if (completed != authTask)
                return null;

            var result = await authTask;
            return result.Properties.TryGetValue("code", out var code) ? code : null;
        }
        catch (TaskCanceledException) { return null; }
        catch (OperationCanceledException) { return null; }
#endif
    }

    public static async Task<GoogleTokenResponse> ExchangeCodeAsync(string code)
    {
        var verifier = await GetPkceVerifierAsync();
        if (string.IsNullOrWhiteSpace(verifier))
            throw new Exception("PKCE verifier not found");

        string redirectUri = GetRedirectUriForTokenExchange();

        using var http = new HttpClient();

        var form = new Dictionary<string, string>
        {
            ["client_id"] = ClientId,
            ["code"] = code,
            ["code_verifier"] = verifier,
            ["redirect_uri"] = redirectUri,
            ["grant_type"] = "authorization_code",
        };

#if WINDOWS
        // Если токен-эндпоинт ругается "client_secret is missing", добавляем его в Windows ветке. [web:70]
        form["client_secret"] = ClientSecret;
#endif

        var resp = await http.PostAsync(
            "https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(form));

        var json = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new Exception(json);

        return JsonSerializer.Deserialize<GoogleTokenResponse>(json)!;
    }

    public static GoogleIdTokenPayload ParseIdToken(string idToken)
    {
        var parts = idToken.Split('.');
        if (parts.Length < 2) throw new Exception("Invalid JWT");

        var json = Base64UrlDecodeToString(parts[1]);
        return JsonSerializer.Deserialize<GoogleIdTokenPayload>(json)!;
    }

    // ---------------- Windows loopback ----------------
#if WINDOWS
    private static (HttpListener listener, Uri redirectUri) StartLoopbackListener()
    {
        // Найти свободный порт
        var tcp = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
        tcp.Start();
        var port = ((IPEndPoint)tcp.LocalEndpoint).Port;
        tcp.Stop();

        // HttpListener требует "/" в конце prefix
        var redirectUri = new Uri($"http://127.0.0.1:{port}/oauth2redirect/");
        var listener = new HttpListener();
        listener.Prefixes.Add(redirectUri.ToString());
        listener.Start();

        return (listener, redirectUri);
    }

    private static async Task<string?> WaitForOAuthRedirectAsync(HttpListener listener, TimeSpan timeout)
    {
        try
        {
            var ctxTask = listener.GetContextAsync();
            var completed = await Task.WhenAny(ctxTask, Task.Delay(timeout));

            if (completed != ctxTask)
                return null;

            var ctx = await ctxTask;

            var error = ctx.Request.QueryString["error"];
            var code = ctx.Request.QueryString["code"];

            // Ответ пользователю в браузер
            var html = """
                       <html>
                         <head><meta charset="utf-8"/></head>
                         <body>
                           <h3>Login completed</h3>
                           <p>Можно закрыть это окно и вернуться в приложение.</p>
                         </body>
                       </html>
                       """;
            var bytes = Encoding.UTF8.GetBytes(html);
            ctx.Response.ContentType = "text/html; charset=utf-8";
            ctx.Response.ContentLength64 = bytes.Length;
            await ctx.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
            ctx.Response.OutputStream.Close();

            if (!string.IsNullOrWhiteSpace(error))
                return null;

            return string.IsNullOrWhiteSpace(code) ? null : code;
        }
        finally
        {
            try { listener.Stop(); } catch { }
            try { listener.Close(); } catch { }
        }
    }
#endif

    // ---------------- Shared helpers ----------------
    private static string BuildAuthUrl(Uri redirectUri, string challenge)
    {
        return
            "https://accounts.google.com/o/oauth2/v2/auth" +
            $"?client_id={Uri.EscapeDataString(ClientId)}" +
            $"&redirect_uri={Uri.EscapeDataString(redirectUri.ToString())}" +
            $"&response_type=code" +
            $"&scope={Uri.EscapeDataString("openid email profile")}" +
            $"&code_challenge={Uri.EscapeDataString(challenge)}" +
            $"&code_challenge_method=S256" +
            $"&prompt=select_account";
    }

    private static string CreateCodeVerifier()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            .TrimEnd('=').Replace('+', '-').Replace('/', '_');

    private static string CreateCodeChallenge(string verifier)
    {
        var bytes = SHA256.HashData(Encoding.ASCII.GetBytes(verifier));
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    private static async Task SetPkceVerifierAsync(string verifier)
    {
        _verifierFallback = verifier;
        try { await SecureStorage.SetAsync("pkce_verifier", verifier); } catch { }
    }

    private static async Task<string?> GetPkceVerifierAsync()
    {
        try
        {
            var v = await SecureStorage.GetAsync("pkce_verifier");
            if (!string.IsNullOrWhiteSpace(v))
                return v;
        }
        catch { }

        return _verifierFallback;
    }

    private static string GetRedirectUriForTokenExchange()
    {
#if WINDOWS
        if (_lastLoopbackRedirectUri is null)
            throw new Exception("Loopback redirect uri not initialized. Call GetAuthCodeAsync() first.");
        return _lastLoopbackRedirectUri.ToString();
#else
        return CallbackUri.ToString();
#endif
    }

    private static string Base64UrlDecodeToString(string input)
    {
        input = input.Replace('-', '+').Replace('_', '/');
        switch (input.Length % 4)
        {
            case 2: input += "=="; break;
            case 3: input += "="; break;
        }
        var bytes = Convert.FromBase64String(input);
        return Encoding.UTF8.GetString(bytes);
    }
}
