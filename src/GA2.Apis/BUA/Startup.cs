using GA2.Apis.BUA.Extensions;
using GA2.Transversals.Commons.Constants;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GA2.Apis.BUA
{
    /// <summary>
    /// Clase inicializadora de servicios de applicación
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>19/02/2021</date>
    public class Startup
    {
        /// <summary>
        /// Constructor de inicio de servicios
        /// </summary>
        /// <param name="configuration">Configuración de la aplicacion</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Propiedad que expone el archivo de configuracin de la aplicación 
        /// </summary>
        /// <author>Oscar Julian Rojas </author>
        /// <date>19/02/201</date>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Metodo que expone los servicios configurados en la aplicacion
        /// </summary>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>19/02/2021</date>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomCacheApplication();
            services.AddGlobalSettinsOptions(Configuration);
            //Extensiones de servicios
            services.AddCorsServices(Configuration);

            services.AddControllersWithViews();

            services.AddAntiforgery(setup =>
            {
                setup.HeaderName = "GA2-XSRF-TOKEN";
            });

            services.AddJwtDocumentation(Configuration);
            services.AddSwaggerDocumentation(Configuration);

            // Inject Dependencies
            services.AddServicesDependencies();
        }

        /// <summary>
        /// Metodo que acciona el uso de los servicios configurados en la aplicacion
        /// </summary>
        /// <param name="app">Constructor de aplicacion</param>
        /// <param name="env">Entorno en ejecucion</param>
        /// <param name="antiforgery">antiforgery token application</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>19/02/2021</date>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorValidation();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(BUAConstants.ApiName);
            app.UseSwaggerDocumentation();

            app.UseJwtAuthentication();
            app.UseAuthorization();

           // app.UseAntiforgeryToken(antiforgery);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
