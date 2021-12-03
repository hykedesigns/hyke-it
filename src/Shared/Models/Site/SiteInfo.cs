namespace HykeIt.Models.Site;

public class SiteInfo : IAudit, IDeletable
{
    public int SiteId { get; set; }
    public Guid SiteGuid { get; set; }
    public int TenantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? LogoFileId { get; set; }
    public int? FaviconFileId { get; set; }

    public string DefaultThemeType { get; set; } = string.Empty;
    public string DefaultContainerType { get; set; } = string.Empty;
    public string AdminContainerType { get; set; } = string.Empty;
    public bool PwaIsEnabled { get; set; }
    public int? PwaAppIconFileId { get; set; }
    public int? PwaSplashIconFileId { get; set; }

    public bool AllowRegistration { get; set; }
    public string Runtime { get; set; } = string.Empty;
    public string RenderMode { get; set; } = string.Empty;

    [NotMapped]
    public string SiteTemplateType { get; set; } = string.Empty;

    [NotMapped]
    public Dictionary<string, string>? Settings { get; set; }

    public int DeletedById { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdateDate { get; set; }
}
