using Microsoft.Extensions.DependencyInjection;

namespace Browser.Storage
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<LocalStorage>();

            return services;
        }
    }
}
