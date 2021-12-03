namespace HykeIt.Services;

public class InstallationService : ServiceBase, IInstallationService
{
    private readonly NavigationManager _navManager;
    private readonly SiteState _state;

    public InstallationService(
        HttpClient client,
        NavigationManager navManager,
        SiteState state)
        : base(client, state)
    {
        _navManager = navManager;
        _state = state;
    }

    private string ApiUrl => CreateApiUrl("Installation", null, ControllerRoutes.ApiRoute);

    public async Task<Installation> Install(InstallConfig config)
    {
        return await PostJsonAsync<InstallConfig, Installation>(ApiUrl, config);
    }

    public async Task<Installation> IsInstalled()
    {
        var path = new Uri(_navManager.Uri).LocalPath[1..];
        return await GetJsonAsync<Installation>($"{ApiUrl}/installed/?path={WebUtility.UrlEncode(path)}");
    }

    public async Task RegisterAsync(string email)
    {
        await PostJsonAsync($"{ApiUrl}/register?email={WebUtility.UrlEncode(email)}", true);
    }

    public async Task RestartAsync()
    {
        await PostAsync($"{ApiUrl}/restart");
    }

    public void SetAntiForgeryTokenHeader(string antiforgerytokenvalue)
    {
        if (!string.IsNullOrEmpty(antiforgerytokenvalue))
        {
            AddRequestHeader(GlobalConstants.AntiForgeryTokenHeaderName, antiforgerytokenvalue);
        }
    }

    public async Task<Installation> Upgrade()
    {
        return await GetJsonAsync<Installation>($"{ApiUrl}/upgrade");
    }
}
