using BlazorComponentBus;
using Blazored.SessionStorage;
using BrewUp.Web.Client;
using BrewUp.Web.Modules.Production.Extensions;
using BrewUp.Web.Modules.Pubs.Extensions;
using BrewUp.Web.Shared.Configuration;
using BrewUp.Web.Shared.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Configuration
builder.Services.AddSingleton(_ => builder.Configuration.GetSection("BrewUp:AppConfiguration")
	.Get<AppConfiguration>());
builder.Services.AddApplicationService();
#endregion

builder.Services.AddMudServices();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped<ComponentBus>();

#region Modules
builder.Services.AddPubsModule();
builder.Services.AddProductionModule();
#endregion

await builder.Build().RunAsync();
