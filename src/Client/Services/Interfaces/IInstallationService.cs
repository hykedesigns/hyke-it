namespace HykeIt.Services.Interfaces;

public interface IInstallationService
{
    Task<Installation> IsInstalled();
    Task<Installation> Install(InstallConfig config);
    Task<Installation> Upgrade();
    Task RestartAsync();
    Task RegisterAsync(string email);
    void SetAntiForgeryTokenHeader(string antiforgerytokenvalue);
}
