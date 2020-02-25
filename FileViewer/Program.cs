using System.Threading.Tasks;

using Browser.Storage;

using FileViewer.Services;

using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FileViewer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddFileViewerCoreServices()
                .AddSingleton<IStorageProvider, LocalStorageProvider>()
                .AddSingleton<FileSystemService>()
                .AddSingleton<IItemModelBuilder, ItemModelBuilder>()
                .AddSingleton<IItemManager, ItemManager>()
                .AddStorage();

            await builder.Build().RunAsync();
        }
    }
}
