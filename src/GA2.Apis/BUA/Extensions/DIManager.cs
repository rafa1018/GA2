using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GA2.Apis.BUA.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DIManager
    {
        /// <summary>
        /// Metodo que inyecta las dependencias del proyecto
        /// </summary>
        /// <param name="services">Proveedor de servicios</param>
        /// <returns>Proveedor de servicios</returns>
        internal static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {

            #region AutoMapper
            services.AddAutoMapper(typeof(IdentityMapper));
            services.AddAutoMapper(typeof(BUAMapper));


            #endregion

            #region Main 
            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<ICryptoGA2, CryptoGA2>();
            services.AddTransient<IIntegracionesGA2Bua, IntegracionesGA2>();
            services.AddTransient<IProviderRequestG2, ProviderRequestG2>();

            #endregion

            #region Domain

            services.AddTransient<ILogErrorBusinessLogic, LogErrorBusinessLogic>();
            services.AddTransient<IClientesBusinessLogic, ClientesBusinessLogic>();
            services.AddTransient<IAfiliacionesBusinessLogic, AfiliacionesBusinessLogic>();
            services.AddTransient<IIntegracionesGa2BuaBusinessLogic, IntegracionesGA2BuaBusinessLogic>();
            services.AddTransient<ICuentasConceptosBusinessLogic, CuentasConceptosBusinessLogic>();
            
            services.AddTransient<ICierreMensualBusinessLogic, CierreMensualBusinessLogic>();
            services.AddTransient<ICierreMensualBusinessLogicBua, CierreMensualBusinessLogicBua>();

            services.AddTransient<ICierreAnualBusinessLogic, CierreAnualBusinessLogic>();
            services.AddTransient<ICierreAnualBusinessLogicBua, CierreAnualBusinessLogicBua>();

            services.AddTransient<ICuentasBusinessLogic, NuevaCuentasConceptosBusinessLogic>();

            #endregion

            #region Inrfraestructure Repository

            services.AddTransient<ILogErrorRepository, LogErrorRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IAfiliacionesRepository, AfiliacionesRepository>();
            services.AddTransient<IBlobStorageGenericRepository, BlobStorageGenericRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<ICuentasConceptosRepository, CuentasConceptosRepository>();
            services.AddTransient<ICierreMensualRepository, CierreMensualRepository>();
            services.AddTransient<ICierreMensualRepositoryBua, CierreMensualRepositoryBua>();
            services.AddTransient<ICierreAnualRepository, CierreAnualRepository>();
            services.AddTransient<ICierreAnualRepositoryBua, CierreAnualRepositoryBua>();

            #endregion

            return services;
        }
    }
}
