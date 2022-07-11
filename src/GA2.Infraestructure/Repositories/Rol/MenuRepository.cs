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
    /// Repository Menu aplicacion
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>28/04/2021</date>
    public class MenuRepository : DapperGenerycRepository, IMenuRepository
    {
        /// <summary>
        /// Constructor menu repository
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        public MenuRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<Menu> CrearMenu(Menu menu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_DESCRIPCION), menu.MNU_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_VISIBLE), menu.MNU_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_LINK), menu.MNU_LINK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ICONO), menu.MNU_ICONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.FRM_ID), menu.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_CREADOPOR), menu.MNU_CREADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_FECHACREACION), menu.MNU_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ESTADO), menu.MNU_ESTADO);

            return await GetAsyncFirst<Menu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Actualizar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<Menu> ActualizarMenu(Menu menu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ID), menu.MNU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_DESCRIPCION), menu.MNU_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_VISIBLE), menu.MNU_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_LINK), menu.MNU_LINK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ICONO), menu.MNU_ICONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.FRM_ID), menu.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_MODIFICADOPOR), menu.MNU_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_FECHAMODIFICACION), menu.MNU_FECHAMODIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ESTADO), menu.MNU_ESTADO);

            return await GetAsyncFirst<Menu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<Menu> EliminarMenu(Menu menu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ID), menu.MNU_ID);

            return await GetAsyncFirst<Menu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<Menu> ObteneterMenu(Guid Id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.MNU_ID), Id);

            return await GetAsyncFirst<Menu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<IEnumerable<Menu>> ObteneterMenusPorAppId(Guid AppId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumMenuParameters.APP_ID), AppId);

            return await GetAsyncList<Menu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }
    }
}