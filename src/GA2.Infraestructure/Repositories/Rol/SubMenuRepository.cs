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
    /// Repositorio para crear sub menus
    /// </summary>
    public class SubMenuRepository : DapperGenerycRepository, ISubMenuRepository
    {
        /// <summary>
        /// Constructor Sub Menu repository
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        public SubMenuRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<SubMenu> CrearSubMenu(SubMenu subMenu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.FRM_ID), subMenu.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.MNU_ID), subMenu.MNU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_DESCRIPCION), subMenu.SBM_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_LINK), subMenu.SBM_LINK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ICONO), subMenu.SBM_ICONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_VISIBLE), subMenu.SBM_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_CREADOPOR), subMenu.SBM_CREADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_FECHACREACION), subMenu.SBM_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ESTADO), subMenu.SBM_ESTADO);

            return await GetAsyncFirst<SubMenu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Actualizar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a actualizar</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu actualizado</returns>
        public async Task<SubMenu> ActualizarSubMenu(SubMenu subMenu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ID), subMenu.SBM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.FRM_ID), subMenu.FRM_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.MNU_ID), subMenu.MNU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_DESCRIPCION), subMenu.SBM_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_LINK), subMenu.SBM_LINK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ICONO), subMenu.SBM_ICONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_VISIBLE), subMenu.SBM_VISIBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_MODIFICADOPOR), subMenu.SBM_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_FECHAMODIFICACION), subMenu.SBM_FECHAMODIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ESTADO), subMenu.SBM_ESTADO);

            return await GetAsyncFirst<SubMenu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a eliminar</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>Submenu eliminado</returns>
        public async Task<SubMenu> EliminarSubMenu(SubMenu subMenu)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.SBM_ID), subMenu.SBM_ID);

            return await GetAsyncFirst<SubMenu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Obtneer por menuid
        /// </summary>
        /// <param name="MenuId">Menu id</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>28/04/2021</date>
        /// <returns>lista de submenus</returns>
        public async Task<IEnumerable<SubMenu>> ObtenerSubMenusPorMenuId(Guid MenuId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSumbMenuParameters.MNU_ID), MenuId);

            return await GetAsyncList<SubMenu>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

    }
}
