using Microsoft.Maui.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class GoogleOAuthTest
{
    const string ClientId = "285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8.apps.googleusercontent.com";
    static readonly Uri CallbackUri =
        new("com.googleusercontent.apps.285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8:/oauth2redirect");

    
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
        public string? sub { get; set; }           // стабильный Google user id
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
        timeout ??= TimeSpan.FromSeconds(60);

        var verifier = CreateCodeVerifier();
        var challenge = CreateCodeChallenge(verifier);

        await SecureStorage.SetAsync("pkce_verifier", verifier);

        var authUrl =
            "https://accounts.google.com/o/oauth2/v2/auth" +
            $"?client_id={Uri.EscapeDataString(ClientId)}" +
            $"&redirect_uri={Uri.EscapeDataString(CallbackUri.ToString())}" +
            $"&response_type=code" +
            $"&scope={Uri.EscapeDataString("openid email profile")}" +
            $"&code_challenge={Uri.EscapeDataString(challenge)}" +
            $"&code_challenge_method=S256" +
            $"&prompt=select_account";

        try
        {
            var authTask = WebAuthenticator.Default.AuthenticateAsync(new Uri(authUrl), CallbackUri);

            var completed = await Task.WhenAny(authTask, Task.Delay(timeout.Value));
            if (completed != authTask)
                return null;

            var result = await authTask;
            return result.Properties.TryGetValue("code", out var code) ? code : null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
    }


    static string CreateCodeVerifier()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            .TrimEnd('=').Replace('+', '-').Replace('/', '_');

    static string CreateCodeChallenge(string verifier)
    {
        var bytes = SHA256.HashData(Encoding.ASCII.GetBytes(verifier));
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
    
    public static async Task<GoogleTokenResponse> ExchangeCodeAsync(string code)
    {
        var verifier = await SecureStorage.GetAsync("pkce_verifier");
        if (string.IsNullOrWhiteSpace(verifier))
            throw new Exception("PKCE verifier not found");

        using var http = new HttpClient();

        var resp = await http.PostAsync(
            "https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = ClientId,
                ["code"] = code,
                ["code_verifier"] = verifier,
                ["redirect_uri"] = CallbackUri.ToString(), // важно: exact match [web:219]
                ["grant_type"] = "authorization_code",
            }));

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

    static string Base64UrlDecodeToString(string input)
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