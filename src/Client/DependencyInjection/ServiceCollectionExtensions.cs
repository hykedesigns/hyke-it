

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHykeItAuthorization(
        this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddScoped<IdentityAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(a =>
            a.GetRequiredService<IdentityAuthenticationStateProvider>());
        return services;
    }

    internal static IServiceCollection AddHykeItServices(
        this IServiceCollection services)
    {
        services.AddScoped<SiteState>();

        return services;
    }
}
