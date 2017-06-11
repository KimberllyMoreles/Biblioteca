// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyBiblioteca.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userId";
        private static readonly string UserIdDefault = string.Empty;

        const string AuthTokeyKey = "authtoken";
        static readonly string AuthTokeyDefault = string.Empty;

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokeyKey, AuthTokeyDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokeyKey, value); }
        }

        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);

    }
}