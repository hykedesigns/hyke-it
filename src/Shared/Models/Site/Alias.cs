namespace HykeIt.Models.Site;

public class Alias : IAudit
{
    public int AliasId { get; set; }
    public string AliasName { get; set; } = string.Empty;

    public int CreatedById { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdateDate { get; set; }
}
