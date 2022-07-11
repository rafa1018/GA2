using GA2.Application.Dto;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Cuenta repositorio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/05/2021</date>
    public interface ICuentaRepository
    {
        /// <summary>
        /// Actualizar cuenta en base datos
        /// </summary>
        /// <param name="cuenta">Cuenta a actualizar</param>
        /// <returns>Cuenta actualizada</returns>
        Task<Cuenta> ActualizarCuenta(Cuenta cuenta);

        /// <summary>
        /// Crear cuenta base de datos
        /// </summary>
        /// <param name="cuenta">Cuenta a crear</param>
        /// <returns>Cuenta creada</returns>
        Task<Cuenta> CrearCuenta(Cuenta cuenta);

        /// <summary>
        /// Eliminar cuenta 
        /// </summary>
        /// <param name="cuenta">Cuenta a eliminar</param>
        /// <returns>Cuenta eliminada</returns>
        Task<Cuenta> EliminarCuenta(Cuenta cuenta);
        Task<AfiliadoporIdentificacion> ObtenerAfiliadoporIdentificacion(string idafiliado);



        /// <summary>
        /// Obtener cuenta por id
        /// </summary>
        /// <param name="cuentaId">Cuenta id</param>
        /// <returns>Cuenta obtenido por id</returns>
        Task<IEnumerable<Cuenta>> ObtenerCuentaPorCuentaId(Guid cuentaId);

        /// <summary>
        /// Obtener cuenta por estado
        /// </summary>
        /// <param name="cuentaId">Cuenta id</param>
        /// <returns>Lista de cuentas obtenidos</returns>
        Task<IEnumerable<Cuenta>> ObtenerCuentaPorEstado(Guid cuentaId);

        /// <summary>
        /// crear cuenta segun logica de negocio
        /// </summary>
        /// <param name="verificarafiliado">Cuenta id</param>
        /// <returns>cuenta creada y movimiento realizado</returns>
        Task<VerificarAfiliado> VerificarAfiliado(VerificarAfiliado verificarafiliado);
    }
}