namespace HykeIt.Models.Site;

public class Tenant : IAudit
{
    public int TenantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string DbType { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public int CreatedById { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdateDate { get; set; }
}
