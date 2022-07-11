using GA2.Transversals.Commons.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GA2.Apis.Identity.Extensions
{
    internal static class JwtExtensions
    {
        /// <summary>
        /// Add json web token documentacion
        /// </summary>
        /// <param name="services">Servicios de aplicacion</param>
        /// <param name="configuration">configuracion de aplicacion</param>
        /// <returns>Coleccion de servicio de jwt</returns>
        internal static IServiceCollection AddJwtDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"])),
                    ValidateIssuer = false,
                    ValidIssuer = IdentityConstants.ApiName,
                    ValidAudience = IdentityConstants.ApiName,
                    ValidateAudience = false,
                };
            });
            return services;
        }

        /// <summary>
        /// Uso de json web token
        /// </summary>
        /// <param name="app">Constructor de apliacion</param>
        /// <returns>Constructor de aplicacion</returns>
        internal static IApplicationBuilder UseJwtAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            return app;
        }
    }
}
