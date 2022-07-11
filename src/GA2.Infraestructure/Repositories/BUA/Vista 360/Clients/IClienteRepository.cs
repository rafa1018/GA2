using GA2.Application.Dto;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> ActualizarCliente(Cliente client);
        Task<IEnumerable<ClienteSinCrear>> CrearClientesPorCargaNomina(IEnumerable<ClienteSinCrear> clientes);
        Task<Cliente> ObtenerClienteInformacion(int Id);
        Task<ClienteCedula> ObtenerInformacionClienteCedula(int identificacionCliente);
        Task<Cliente> ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(string tipoDocumento, string numeroIdentificacion, string numeroCelular, DateTime fechaExpedicion);
        Task<Cliente> ObtenerClientePorTipoIdentificationYNumero(int identificationType, string identificationNumber);
        Task<IEnumerable<ClienteSinCrear>> ValidarNomina(string json);
        Task<Cliente> InsertarCliente(Cliente client);
        Task<Cliente> RestaurarIntegracionCliente(Cliente client);
        Task<Cuenta> InsertarCuentaIntegracion(Cuenta cuenta);
        Task<Dependiente> InsertarDependienteIntegracion(Dependiente dependiente);
        Task<AportesCliente> InsertarAportesIntegracion(AportesCliente cuenta);
        Task<ClienteCesantias> ObtenerInformacionClientePorDocumentoYTipo(int identificationType, string identificationNumber, int idCLiente);       
        Task<IEnumerable<Cuenta>> ObtenerCuentas (int idCliente);        
        Task<IEnumerable<AportesCliente>> ObtenerAportesCliente(int idCliente);        
        Task<IEnumerable<Dependiente>> ObtenerDependientes(int idCliente);
        Task<Domain.Entities.Movimiento> InsertarMovimientoIntegracion(Domain.Entities.Movimiento movimiento);
        Task<IEnumerable<CuentaAfiliado>> ObtenerCuentasMovimientosAfiliado(string identificacion);
        Task<Cuenta> ObtenerCuentaById(string request);
        Task<IEnumerable<Domain.Entities.Movimiento>> ObtenerMovimientosCuenta(int idCuenta);
        Task<IEnumerable<CuerpoArchivoDto>> InsertarClienteNomina(CuerpoArchivoDto idCuenta);

        Task<Cuenta> ObtenerCuentaClieteByIdNumeroCuenta(int numeroCuenta,int idCliente);

        Task<IEnumerable<Cliente>> ObtenerClientesById(string clientesIds);

        Task<IEnumerable<Cuenta>> ObtenerCuentaIdCuenta(string idCuenta);

    }
}