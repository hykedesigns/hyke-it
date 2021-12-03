var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
builder.Services.AddOptions();
builder.Services.AddLocalization(options =>
    options.ResourcesPath = "Resources");

builder.Services.AddHykeItAuthorization();
builder.Services.AddHykeItServices();

await builder.Build().RunAsync();
