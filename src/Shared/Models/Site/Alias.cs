namespace HykeIt.Models.Site;

public class Alias : IAudit
{
    public int AliasId { get; set; }
    public int TenantId { get; set; }
    public int SiteId { get; set; }
    public string Name { get; set; } = string.Empty;

    [NotMapped]
    public string Path => Name.Contains('/') ? Name[(Name.IndexOf("/") + 1)..] : "";

    public int CreatedById { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdateDate { get; set; }
}
