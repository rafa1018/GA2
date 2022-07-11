using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityFunctions.Extensions
{
    public static class DIManagerFunctions
    {
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
            services.AddTransient<IIntegracionesGa2BuaBusinessLogic, IntegracionesGA2BuaBusinessLogic>();


            #endregion

            #region Inrfraestructure Repository

            services.AddTransient<ILogErrorRepository, LogErrorRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IBlobStorageGenericRepository, BlobStorageGenericRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();

            #endregion

            return services;
        }
    }
}
