namespace HykeIt.Infrastructure;

public static class Utilities
{
    public static string TenantUrl(
        Alias alias,
        string url)
    {
        url = (!url.StartsWith("/")) ? "/" + url : url;
        return (alias != null && !string.IsNullOrEmpty(alias.Path)) ? "/" + alias.Path + url : url;
    }
}
