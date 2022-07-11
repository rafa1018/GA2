using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrearTasasSimulacion.Extensions
{
    internal static class DiManagerFunctions
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
