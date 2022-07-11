using GA2.Transversals.Commons.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GA2.Apis.BUA.Extensions
{
    /// <summary>
    /// Swagger Extension
    /// </summary>
    /// <date>18/02/2021</date>
    internal static class SwaggerExtensions
    {
        /// <summary>
        /// Add swagger documentation
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">Configuracion de aplicación</param>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>18/02/2021</date>
        /// <returns>Services Configuration Swagger</returns>
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["VersionApi"], GetOpenApiInfo(configuration));
                options.AddSecurityDefinition(configuration["JwtOptions:Type"], GetOpenApiSecurityScheme(configuration));
                options.AddSecurityRequirement(GetOpenApiSecurityRequirement());
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{configuration["JwtOptions:typeDocumentExtension"]}";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
            });
            return services;
        }

        /// <summary>
        /// Get Open API information
        /// </summary>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>18/02/2021</date>
        /// <returns>Configuration OpenApi</returns>
        internal static OpenApiInfo GetOpenApiInfo(IConfiguration configuration)
        {
            return new OpenApiInfo
            {
                Title = string.Format($"{BUAConstants.ApiName} API"),
                Version = configuration["VersionApi"],
                Description = BUAConstants.GetOpenApiInfoDescription
            };
        }

        /// <summary>
        /// Get Open API security scheme
        /// </summary>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>18/02/2021</date>
        /// <returns>Configuration OpenApiSecurity Schema</returns>
        internal static OpenApiSecurityScheme GetOpenApiSecurityScheme(IConfiguration configuration)
        {
            return new OpenApiSecurityScheme
            {
                Description = BUAConstants.GetOpenApiSecuritySchemeDescription,
                Name = BUAConstants.GetOpenApiSecuritySchemeName,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = configuration["JwtOptions:Type"]
            };
        }

        /// <summary>
        /// Get Open API security requirements
        /// </summary>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>18/02/2021</date>
        /// <returns>Configuration OpenApi requimiento</returns>
        internal static OpenApiSecurityRequirement GetOpenApiSecurityRequirement()
        {
            return new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new List<string>()
                }
            };
        }

        /// <summary>
        /// Use swagger documentation
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>18/02/2021</date>
        /// <returns>Configurtation Application builder Swagger</returns>
        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GA2.BUA API");
            });
            return app;
        }
    }
}
