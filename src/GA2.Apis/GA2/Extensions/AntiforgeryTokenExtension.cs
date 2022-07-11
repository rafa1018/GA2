using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace GA2.Apis.GA2.Extensions
{
    /// <summary>
    /// Provider CSRF token prevention
    /// </summary>
    public static class AntiforgeryTokenExtension
    {
        internal static IApplicationBuilder UseAntiforgeryToken(this IApplicationBuilder app, IAntiforgery antiforgery)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            app.Use(next => context =>
            {
                string path = context.Request.Path.Value;
                string urlAreas = "/api/obtenertoken";
                if (path.Equals(urlAreas))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    var token = new
                    {
                        crsfToken = tokens.RequestToken
                    };
                    context.Response.WriteAsync(JsonConvert.SerializeObject(token));
                }
                return next(context);
            });
            return app;
        }
    }
}
