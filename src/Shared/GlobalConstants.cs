namespace HykeIt;

public class GlobalConstants
{
    public static readonly string AUTHENTICATION_SCHEME = "Identity.Application";
    public static readonly string RequestVerificationToken = "__RequestVerificationToken";
    public static readonly string AntiForgeryTokenHeaderName = "X-XSRF-TOKEN-HEADER";
    public static readonly string AntiForgeryTokenCookieName = "X-XSRF-TOKEN-COOKIE";
}
