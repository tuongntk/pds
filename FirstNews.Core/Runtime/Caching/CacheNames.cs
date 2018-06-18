namespace FirstNews.Core.Runtime.Caching
{
    /// <summary>
    /// Names of standard caches used in ABP.
    /// </summary>
    public static class CacheNames
    {
        /// <summary>
        /// Application settings cache: FirstNewsApplicationSettingsCache.
        /// </summary>
        public const string ApplicationSettings = "FirstNewsApplicationSettingsCache";

        /// <summary>
        /// Tenant settings cache: FirstNewsTenantSettingsCache.
        /// </summary>
        public const string TenantSettings = "FirstNewsTenantSettingsCache";

        /// <summary>
        /// User settings cache: FirstNewsUserSettingsCache.
        /// </summary>
        public const string UserSettings = "FirstNewsUserSettingsCache";

        /// <summary>
        /// Localization scripts cache: FirstNewsLocalizationScripts.
        /// </summary>
        public const string LocalizationScripts = "FirstNewsLocalizationScripts";
    }
}