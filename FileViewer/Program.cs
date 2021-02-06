using System;
using System.Net.Http;
using System.Threading.Tasks;

using Browser.Storage;

using FileViewer.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FileViewer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            builder.Services
                .AddFileViewerCoreServices()
                .AddScoped<IStorageProvider, LocalStorageProvider>()
                .AddScoped<FileSystemService>()
                .AddScoped<IItemModelBuilder, ItemModelBuilder>()
                .AddScoped<IItemManager, ItemManager>()
                .AddStorage();

            await builder.Build().RunAsync();
        }
    }
}
