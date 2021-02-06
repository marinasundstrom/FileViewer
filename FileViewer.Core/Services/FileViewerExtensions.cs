using Microsoft.Extensions.DependencyInjection;

namespace FileViewer.Services
{
    public static class FileViewerExtensions
    {
        public static IServiceCollection AddFileViewerCoreServices(this IServiceCollection services)
        {
            services.AddScoped<INodeTreeLoader, NodeTreeLoader>();
            services.AddScoped<INodeTreeBuilder, NodeTreeBuilder>();
            services.AddScoped<FileSystem>();

            return services;
        }
    }
}
