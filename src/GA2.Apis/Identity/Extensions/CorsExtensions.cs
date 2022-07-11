using GA2.Transversals.Commons.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace GA2.Apis.Identity.Extensions
{
    /// <summary>
    /// Extension configuracion cors
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>18/02/2021</date>
    public static class CorsExtensions
    {
        /// <summary>
        /// Añadir servicio cors
        /// </summary>
        /// <param name="services">Interface services startup</param>
        /// <param name="configuration">configuration application</param>
        /// <returns></returns>
        internal static IServiceCollection AddCorsServices(this IServiceCollection services, IConfiguration configuration)
        {
            IList<string> urlsAllowed = new List<string>();
            var appsurls = configuration.GetSection("Apps").GetChildren();
            foreach (var i in appsurls)
                urlsAllowed.Add(i.Value);

            services.AddCors(
                opt => opt.AddPolicy(IdentityConstants.ApiName,
                builder =>
                builder.WithOrigins(urlsAllowed.ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader()));
            return services;
        }
    }
}
