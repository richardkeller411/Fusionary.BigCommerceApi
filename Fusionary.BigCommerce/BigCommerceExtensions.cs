using System.Net;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fusionary.BigCommerce;

public static class BigCommerceExtensions
{
    public static void AddBigCommerce(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BigCommerceConfig>(configuration.GetSection("BigCommerce"));
        services.AddHttpClient<BigCommerceClient>()
            .ConfigurePrimaryHttpMessageHandler(
                () => new HttpClientHandler
                {
                    AllowAutoRedirect = false, UseCookies = false, AutomaticDecompression = DecompressionMethods.All
                }
            );
        services.AddTransient<IBigCommerceApi, BigCommerceApi>();
        services.AddTransient<IBcStorefrontGraphQL, BcStorefrontGraphQL>();
        services.AddTransient<Bc>();

        if (!services.Contains(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>()))
        {
            services.AddMemoryCache();
        }

        services.AddSingleton<IBcTokenCache, BcTokenCache>();
    }
}