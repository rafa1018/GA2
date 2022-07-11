using Microsoft.Extensions.DependencyInjection;

namespace GA2.Apis.BUA.Extensions
{
    /// <summary>
    /// Añadiendo cache a las peticiones de la apps
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>22/05/2021</date>
    internal static class CustomCacheApiExtension
    {
        /// <summary>
        /// Add servicios de cache al sistema de peticiones
        /// </summary>
        /// <param name="services">Servicios inyectados en la aplicacion</param>
        /// <returns>Servicio añadido de cache</returns>
        internal static IServiceCollection AddCustomCacheApplication(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            return services;
        }
    }
}
