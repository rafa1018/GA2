using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Worker.Extensions
{
    public static class DIManagerWorker
    {
        /// <summary>
        /// Metodo que inyecta las dependencias del proyecto
        /// </summary>
        /// <param name="services">Proveedor de servicios</param>
        /// <returns>Proveedor de servicios</returns>
        internal static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {

            #region Mappers 
            services.AddAutoMapper(typeof(DocumentMapper));

            #endregion


            #region Main 

            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<ICryptoGA2, CryptoGA2>();
          
            #endregion

            #region Domain

            services.AddTransient<ILogErrorBusinessLogic, LogErrorBusinessLogic>();

            #endregion

            #region Inrfraestructure Repository

            services.AddTransient<ILogErrorRepository, LogErrorRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IMovimientoRepository, MovimientoRepository>();
            services.AddTransient<ICuentaWorkerRepository, CuentaWorkerRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();


            #endregion
            return services;
        }
    }
}
