using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShareLibrary.ProductRepositories;
using BlazorApp3.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
await builder.Build().RunAsync();
