using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Interfaz que expone la logica de negocio para manejar la informacion de los clientes
    /// </summary>
    public interface IClientesBusinessLogic
    {
        Task<Response<ClienteDto>> ActualizarCliente(ClienteDto client);
        Task<Response<ClienteDto>> ObtenerClienteInformacion(int Id);
        Task<Response<ClienteCedulaDto>> ObtenerInformacionClienteCedula(int identificacionCliente);
        Task<Response<ClienteDto>> ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(string tipoDocumento, string numeroIdentificacion, string numeroCelular, DateTime fechaExpedicion);
        Task<Response<ClienteDto>> ObtenerClientePorTipoIdentificationYNumero(int identificationType, string identificationNumber, IEnumerable<Claim> claims);
        Task<Response<IEnumerable<ClienteSinCrearDTO>>> ValidarClientes(string file);
        Task<Response<ClienteDto>> RestaurarIntegracionCliente(RestaurarIntegracionClienteDTO restaurarIntegracionCliente, IEnumerable<Claim> claims);
        Task<Response<ClienteCesantiasDto>> ObtenerInformacionClientePorDocumentoYTipo(int identificationType, string identificationNumber, int idCLiente);
        Task<Response<IEnumerable<CuentaAfiliadoDTO>>> ObtenerCuentasMovimientosAfiliado(string identificacion);
        Task<Response<CuentaDto>> ObtenerCuentaById(string request);

        Task<Response<CuentaDto>> ObtenerCuentaClieteByIdNumeroCuenta(int numeroCuenta, int idCliente);

        Task<Response<IEnumerable<ClienteDto>>> ObtenerClientesById(string clientesIds);

        Task<Response<IEnumerable<CuentaDto>>> ObtenerCuentaIdCuenta(string idCuenta);
    }
}