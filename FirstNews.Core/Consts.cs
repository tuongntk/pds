namespace FirstNews.Core
{
    /// <summary>
    ///     Used to define some constants.
    /// </summary>
    public static class Consts
    {
        /// <summary>
        ///     Localization source name.
        /// </summary>
        public const string LocalizationSourceName = "FirstNews";

        internal static class Orms
        {
            public const string Dapper = "Dapper";
            public const string EntityFramework = "EntityFramework";
            public const string EntityFrameworkCore = "EntityFrameworkCore";
            public const string NHibernate = "NHibernate";
        }
    }
}
