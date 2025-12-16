using Android.App;
using Android.Content;
using Android.Content.PM;
using Microsoft.Maui.Authentication;

namespace MedCompatibility;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.googleusercontent.apps.285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8"
)]
public class MedCompatAuthCallbackActivity : WebAuthenticatorCallbackActivity { }