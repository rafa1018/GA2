using Dapper;
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
    /// Repositorio Formulario
    /// </summary>
    public class FormularioRepository : DapperGenerycRepository, IFormularioRepository
    {
        /// <summary>
        /// Constructor Formualario
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <param name="configuration"></param>
        public FormularioRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Crear Formulario
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>formulario Creado</returns>
        public async Task<Formulario> CrearFormulario(Formulario formulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.SBM_ID), formulario.SBM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_DESCRIPCION), formulario.FRM_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_VISIBLE), formulario.FRM_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_CREADOPOR), formulario.FRM_CREADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_FECHACREACION), formulario.FRM_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_ESTADO), formulario.FRM_ESTADO);

            return await GetAsyncFirst<Formulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarFormulario
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Formulario Actualizado</returns>
        public async Task<Formulario> ActualizarFormulario(Formulario formulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_ID), formulario.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.SBM_ID), formulario.SBM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_DESCRIPCION), formulario.FRM_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_VISIBLE), formulario.FRM_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_MODIFICADOPOR), formulario.FRM_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_FECHAMODIFICACION), formulario.FRM_FECHAMODIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_ESTADO), formulario.FRM_ESTADO);

            return await GetAsyncFirst<Formulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerFormularioPorId
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Formulio por id</returns>
        public async Task<Formulario> ObtenerFormularioPorId(Formulario formulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFormularioParametros.FRM_ID), formulario.FRM_ID);

            return await GetAsyncFirst<Formulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerFormularios
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Obteniene los formulario </returns>
        public async Task<IEnumerable<Formulario>> ObtenerFormularios()
        {
            return await GetAsyncList<Formulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
    }
}
