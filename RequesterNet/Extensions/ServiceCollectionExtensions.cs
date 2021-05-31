using Microsoft.Extensions.DependencyInjection;
using RequesterNetLib.Interfaces;
using RequesterNetLib.Options;
using System;

namespace RequesterNetLib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequesterNet(this IServiceCollection services, Action<RequesterNetOptions> options = null)
        {
            if (options != null)
                services.Configure(options);

            services.AddSingleton<IRequesterNet, RequesterNet>();
            return services;
        }
    }
}
