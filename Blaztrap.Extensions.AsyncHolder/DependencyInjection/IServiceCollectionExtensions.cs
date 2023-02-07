using Microsoft.Extensions.DependencyInjection;

namespace Blaztrap.Extensions.AsyncHolder.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAsyncHolder(this IServiceCollection services)
        {
            services.AddSingleton<IAsyncHolderService, AsyncHolderService>();
            return services;
        }
    }
