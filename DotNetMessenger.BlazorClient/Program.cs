using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DotNetMessenger.BlazorClient;
using DotNetMessenger.BlazorClient.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://138.16.183.198:5166/") }); // потом крч надо будет поменять везде HttpClient и убрать http... с портом, оставить только путь
builder.Services.AddScoped<User>();

await builder.Build().RunAsync();
