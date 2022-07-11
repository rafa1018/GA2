using Dapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Cuenta repositorio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/05/2021</date>
    public class CuentaWorkerRepository : DapperGenerycWorkerRepository, ICuentaWorkerRepository
    {
        /// <summary>
        /// Constructor cuenta repository
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        public CuentaWorkerRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// json para la creacion de las cuentas
        /// </summary>
        /// <param name="json"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        public async Task<IEnumerable<CuentaDto>> ParametrosCreacionCuenta(string json)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(HelpersEnums.GetEnumDescription(EnumEjecutorParameters.Json), json);
            return await ParametrosCreacionCuentaAsync<CuentaDto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameter, CommandType.StoredProcedure, IsolationLevel.ReadUncommitted);

        }
    }
}
