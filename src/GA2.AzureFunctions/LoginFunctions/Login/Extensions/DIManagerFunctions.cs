using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Login.Extensions
{
    internal static class DIManagerFunctions
    {
        internal static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(typeof(IdentityMapper));

            #endregion

            #region Main 
            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<ILoginRequestProvider, LoginRequestProvider>();
            services.AddTransient<IProviderRequestG2, ProviderRequestG2>();
            services.AddTransient<ICryptoGA2, CryptoGA2>();

            #endregion

            #region Domain

            services.AddTransient<ILogErrorBusinessLogic, LogErrorBusinessLogic>();
            services.AddTransient<IUsersBusinessLogic, UsersBusinessLogic>();
            services.AddTransient<IRolBusinessLogic, RolBusinessLogic>();
            services.AddTransient<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddTransient<IFormularioBusinessLogic, FormularioBusinessLogic>();


            #endregion

            #region Inrfraestructure Repository

            services.AddTransient<ILogErrorRepository, LogErrorRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<ILoginGA2Repository, LoginGA2Repository>();
            services.AddTransient<IBlobStorageGenericRepository, BlobStorageGenericRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IFormularioRepository, FormularioRepository>();

            #endregion

            return services;
        }
    }
}
