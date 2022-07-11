using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace ObtenerProductoCliente.Extensions
{
    internal static class DIManagerFunctions
    {
        internal static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            #region Mapper
            services.AddAutoMapper(typeof(CarteraMapper));
            #endregion

            #region Repository
            services.AddTransient<ICarteraRepository, CarteraRepository>();
            #endregion

            #region BusinessLogic
            services.AddTransient<ICarteraBusinessLogic, CarteraBusinessLogic>();
            #endregion

            return services;
        }
    }
}
