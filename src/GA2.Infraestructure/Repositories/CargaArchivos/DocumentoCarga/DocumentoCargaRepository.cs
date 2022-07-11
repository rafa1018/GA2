using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class DocumentoCargaRepository
        : DapperGenerycRepository, IDocumentoCargaRepository
    {
        public DocumentoCargaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Documento de carga 
        /// </summary>
        /// <param name="documentoCarga">Documento de carga a crear</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/05/2021</date>
        /// <returns>Documento creado</returns>
        public async Task<Documento> CrearDocumentoCarga(Documento documentoCarga)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_ID), documentoCarga.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.TDC_ID), documentoCarga.TDC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.UEJ_ID), documentoCarga.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_NOMBRE), documentoCarga.DCT_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_FECHA_INICIAL), documentoCarga.DCT_FECHA_INICIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_CREADOPOR), documentoCarga.DCT_CREADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_FECHACREACION), documentoCarga.DCT_FECHACREACION);

            return await GetAsyncFirst<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene los documentos cargados, no consiliados
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/05/2021</date>
        /// <returns>Lista de documentos cargados</returns>
        public async Task<IEnumerable<Documento>> ObtenerDocumentosCarga(int esdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.ESD_ID), esdId);
            return await GetAsyncList<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear Documento de carga 
        /// </summary>
        /// <param name="documentoCarga">Documento de carga a crear</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/05/2021</date>
        /// <returns>Documento creado</returns>
        public async Task<Documento> ActualizarDocumentoCarga(Documento documentoCarga)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_ID), documentoCarga.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.ESD_ID), documentoCarga.ESD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_FECHA_FINAL), documentoCarga.DCT_FECHA_FINAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_MODIFICADOPOR), documentoCarga.DCT_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_FECHAMODIFICACION), documentoCarga.DCT_FECHAMODIFICACION);

            return await GetAsyncFirst<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener documento por id repository
        /// </summary>
        /// <param name="documentoId">Documento id</param>
        /// <returns>Documento buscado</returns>
        public async Task<Documento> ObtenerDocumentosPorId(int documentoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_ID), documentoId);

            return await GetAsyncFirst<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// actualizar el estado del documento
        /// </summary>
        /// <param name="documentoId">Documento id</param>
        public async Task<Documento> CambiarEstadoAProcesar(int documentoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.DCT_ID), documentoId);

            return await GetAsyncFirst<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
