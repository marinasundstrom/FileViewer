using Microsoft.Extensions.DependencyInjection;

namespace FileViewer.Services
{
    public static class FileViewerExtensions
    {
        public static IServiceCollection AddFileViewerCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<INodeTreeLoader, NodeTreeLoader>();
            services.AddSingleton<INodeTreeBuilder, NodeTreeBuilder>();
            services.AddSingleton<FileSystem>();

            return services;
        }
    }
}
