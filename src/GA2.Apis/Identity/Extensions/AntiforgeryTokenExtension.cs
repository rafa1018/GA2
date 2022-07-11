using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace GA2.Apis.Identity.Extensions
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
                if (path.ToLowerInvariant().Equals(urlAreas))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRFTOKEN", tokens.RequestToken,
                        new CookieOptions()
                        {
                            HttpOnly = false,
                            Secure = false,
                            IsEssential = true,
                            SameSite = SameSiteMode.Strict
                        });
                }
                return next(context);
            });
            return app;
        }
    }
}
