using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopApp.client;
using ShopApp.client.ClientServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5080") });
builder.Services.AddScoped<IClientClothesServices, ClientClothesServices>();
builder.Services.AddScoped<IClientItemsService, ClientItemsService>();


await builder.Build().RunAsync();
