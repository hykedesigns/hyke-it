namespace HykeIt.Security;

public class UserIdentity
{
    public static ClaimsIdentity CreateClaimsIdentity(
        Alias alias,
        User user)
    {
        ClaimsIdentity claimsIdentity = new(GlobalConstants.AUTHENTICATION_SCHEME);
        if (alias != null &&
            user != null &&
            !user.IsDeleted)
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.UserId.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.GroupSid, alias.AliasId.ToString()));
            if (user.Roles.Contains(RoleNames.ServerAdmin))
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, RoleNames.ServerAdmin));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, RoleNames.Admin));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, RoleNames.Registered));
            }
            foreach (var role in user.Roles.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!claimsIdentity.Claims.Any(item =>
                    item.Type == ClaimTypes.Role &&
                    item.Value == role))
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
        }
        return claimsIdentity;
    }
}
