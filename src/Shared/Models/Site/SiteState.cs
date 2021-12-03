namespace HykeIt.Models.Site;

public class SiteState
{
    public Alias? Alias { get; set; }
    public string AntiForgeryToken { get; set; } = string.Empty;
}
