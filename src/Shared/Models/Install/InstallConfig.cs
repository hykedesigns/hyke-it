namespace HykeIt.Models.Install
{
    public class InstallConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseType { get; set; }
        public string Aliases { get; set; }
        public string TenantName { get; set; }
        public bool IsNewTenant { get; set; }
        public string SiteName { get; set; }
        public string ServerAdminUsername { get; set; }
        public string ServerAdminPassword { get; set; }
        public string ServerAdminEmail { get; set; }
        public string ServerAdminName { get; set; }
        public string SiteTemplate { get; set; }
        public string DefaultTheme { get; set; }
        public string DefaultContainer { get; set; }
        public string DefaultAdminContainer { get; set; }
        public string Runtime { get; set; }
        public string RenderMode { get; set; }
        public bool Register { get; set; }
    }
}
