namespace HykeIt.Infrastructure.Interfaces;

public interface IInstallationManager
{
    void InstallPackages();
    bool UninstallPackage(string PackageName);
    Task UpgradePlatform();
    void RestartApplication();
}
