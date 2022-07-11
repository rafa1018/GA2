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
    /// Repository propiedades de formulario
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class PropiedadFormularioRepository : DapperGenerycRepository, IPropiedadFormularioRepository
    {
        /// <summary>
        /// Constructor PropiedadFormulario
        /// </summary>
        /// <param name="configuration">Configuracion aplicacion</param>
        /// <auth>Oscar Julian Rojas Garces</auth>
        /// <date>29/04/2021</date>
        public PropiedadFormularioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<PropiedadFormulario> CrearPropiedadFormulario(PropiedadFormulario propiedadFormulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.FRM_ID), propiedadFormulario.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FORMID), propiedadFormulario.PFR_FORMID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_NOMBRE), propiedadFormulario.PFR_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_DESCRIPCION), propiedadFormulario.PFR_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_READONLY), propiedadFormulario.PFR_READONLY);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_VISIBLE), propiedadFormulario.PFR_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_MODIFICADOPOR), propiedadFormulario.PFR_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FECHAMODIFICACION), propiedadFormulario.PFR_FECHAMODIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_CREADOPOR), propiedadFormulario.PFR_CREADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FECHACREACION), propiedadFormulario.PFR_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ESTADO), propiedadFormulario.PFR_ESTADO);

            return await GetAsyncFirst<PropiedadFormulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualizar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<PropiedadFormulario> ActualizarPropiedadFormulario(PropiedadFormulario propiedadFormulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ID), propiedadFormulario.PFR_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.FRM_ID), propiedadFormulario.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FORMID), propiedadFormulario.PFR_FORMID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_NOMBRE), propiedadFormulario.PFR_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_DESCRIPCION), propiedadFormulario.PFR_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_READONLY), propiedadFormulario.PFR_READONLY);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_VISIBLE), propiedadFormulario.PFR_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_MODIFICADOPOR), propiedadFormulario.PFR_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FECHAMODIFICACION), propiedadFormulario.PFR_FECHAMODIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_CREADOPOR), propiedadFormulario.PFR_CREADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_FECHACREACION), propiedadFormulario.PFR_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ESTADO), propiedadFormulario.PFR_ESTADO);

            return await GetAsyncFirst<PropiedadFormulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<PropiedadFormulario> EliminarPropiedadFormulario(PropiedadFormulario propiedadFormulario)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ID), propiedadFormulario.PFR_ID);

            return await GetAsyncFirst<PropiedadFormulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<IEnumerable<PropiedadFormulario>> ObtenerPropiedadesFormularioPorFormularioId(Guid propiedadFormularioId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumPropiedadFormularioParameters.PFR_ID), propiedadFormularioId);

            return await GetAsyncList<PropiedadFormulario>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }
    }
}