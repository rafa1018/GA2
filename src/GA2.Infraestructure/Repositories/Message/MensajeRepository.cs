using Dapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.Message;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repository de Mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public class MensajeRepository : DapperGenerycRepository, IMensajeRepository
    {
        public MensajeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// Metodo Obtener Mensaje
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>28/05/2021</date>
        /// <returns></returns>
        public async Task<Mensaje> ObtenerMensaje(string CodigoMensaje)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMensajeParameters.CODIGO), CodigoMensaje);
            var response = await GetAsyncFirst<Mensaje>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response;
        }
    }
}
