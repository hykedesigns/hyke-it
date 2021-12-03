namespace HykeIt.Models.Identity;

public class User : IAudit, IDeletable
{
    public int UserId { get; set; }

    [NotMapped]
    public int SiteId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? PhotoFileId { get; set; }
    public DateTime? LastLoginOn { get; set; }
    public string LastIPAddress { get; set; } = string.Empty;

    [NotMapped]
    public string Roles { get; set; } = string.Empty;

    [NotMapped]
    public string Password { get; set; } = string.Empty;

    [NotMapped]
    public bool IsAuthenticated { get; set; }

    [NotMapped]
    public string FolderPath
    {
        get => "Users\\" + UserId.ToString() + "\\";
    }

    public int DeletedById { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdateDate { get; set; }
}
