using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Client Core Negocio
    /// <author>Nicolas FLorez Sarrazola</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class ClientesBusinessLogic : IClientesBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clientsRepository;
        private readonly ITokenClaims _tokenClaims;
        private readonly IIntegracionesGa2BuaBusinessLogic _integraciones;
        private readonly CHKeysOptions _optionsCH;

        /// <summary>
        /// Constructor Negocio Clients
        /// </summary>
        /// <param name="mapper">Instancia mapper</param>
        /// <param name="clientsRepository">Instancia repositorio usuarios</param>
        public ClientesBusinessLogic(
            IMapper mapper,
            IClienteRepository clientsRepository,
            ITokenClaims tokenClaims,
            IIntegracionesGa2BuaBusinessLogic integraciones,
            IOptions<CHKeysOptions> optionsCH
            )
        {
            _mapper = mapper;
            _clientsRepository = clientsRepository;
            _tokenClaims = tokenClaims;
            _integraciones = integraciones;
            _optionsCH = optionsCH.Value;
        }

        /// <summary>
        /// Metodo obtener info cliente
        /// </summary>
        /// <param name="Cliente">Modelo dto cliente</param>
        /// <uthor>ONicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<ClienteDto>> ObtenerClienteInformacion(int Id)
        {
            var usuarios = this._mapper.Map<Cliente, ClienteDto>(await _clientsRepository.ObtenerClienteInformacion(Id));

            usuarios.Saldos = new();

            var listSaldos = await BuscarSaldos(usuarios.Identificacion);

            foreach (var saldo in listSaldos)
                usuarios.Saldos.Add(saldo);

            //usuarios.Saldos.Add(saldoAhorroDto);
            //usuarios.Saldos.Add(saldoInteresesAhorroDto);
            //usuarios.Saldos.Add(saldoCesantiasDto);
            //usuarios.Saldos.Add(saldoAhorroCesantiasDto);

            return new Response<ClienteDto> { Data = usuarios };
        }

        

        public async Task<Response<ClienteCedulaDto>> ObtenerInformacionClienteCedula(int identificacionCliente)
        {

            ClienteCedulaDto usuarios = new ClienteCedulaDto();
            usuarios = this._mapper.Map<ClienteCedula, ClienteCedulaDto>(await _clientsRepository.ObtenerInformacionClienteCedula(identificacionCliente));
            return new Response<ClienteCedulaDto> { Data = usuarios };
        }

        /// <summary>
        /// Metodo actualizar info cliente
        /// </summary>
        /// <uthor>ONicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <param name="cliente"></param>
        /// <returns>Modelo Dto</returns>
        public async Task<Response<ClienteDto>> ActualizarCliente(ClienteDto client)
        {
            var cliente = this._mapper.Map<Cliente>(client);
            return new Response<ClienteDto> { Data = this._mapper.Map<ClienteDto>(await this._clientsRepository.ActualizarCliente(cliente)) };
        }

        /// <summary>
        /// Metodo obtener info cliente por tipo y número de documento 
        /// </summary>
        /// <param name="Cliente">Modelo dto cliente</param>
        /// <uthor>Nicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<ClienteDto>> ObtenerClientePorTipoIdentificationYNumero(int identificationType, string identificationNumber, IEnumerable<Claim> claims)
        {
            ClienteDto usuarios = this._mapper.Map<Cliente, ClienteDto>(await _clientsRepository.ObtenerClientePorTipoIdentificationYNumero(identificationType, identificationNumber));
            var listSaldos = new List<SaldoDto>();
            ObtenerBuaResponse clienteIntegracionGA2 = await ObtenerClienteIntegracionGA2(identificationType, identificationNumber, claims);

            if (usuarios == null)
            {
                if (clienteIntegracionGA2.ObtenerBUAResult ==   null)
                {
                    return new Response<ClienteDto> { Data = null };
                }

                ClienteDto cliente = this._mapper.Map<ClienteDto>(clienteIntegracionGA2.ObtenerBUAResult);
                cliente = this._mapper.Map<ClienteDto>(await _clientsRepository.InsertarCliente(_mapper.Map<Cliente>(cliente)));

                cliente = await InsertarIntegracionCuentas(cliente, clienteIntegracionGA2.ObtenerBUAResult);
                cliente.Saldos = new();
                listSaldos = await BuscarSaldos(cliente.Cuentas);

                foreach (var saldo in listSaldos)
                    cliente.Saldos.Add(saldo);

                return new Response<ClienteDto> { Data = cliente };
            }

            usuarios.Cuentas = this._mapper.Map<List<CuentaDto>>(await _clientsRepository.ObtenerCuentas(usuarios.IdCliente));
            usuarios.AportesCategoria = this._mapper.Map<List<AportesClienteDto>>(await _clientsRepository.ObtenerAportesCliente(usuarios.IdCliente));
            usuarios.Dependientes = this._mapper.Map<List<DependienteDto>>(await _clientsRepository.ObtenerDependientes(usuarios.IdCliente));

            foreach (CuentaDto cuenta in usuarios.Cuentas)
            {
                cuenta.Movimientos = this._mapper.Map<List<MovimientoDTO>>(await _clientsRepository.ObtenerMovimientosCuenta(cuenta.IdCuenta));
            }

            ClienteDto clientePayload = this._mapper.Map<ClienteDto>(clienteIntegracionGA2.ObtenerBUAResult);
            usuarios.Saldos = new();
            listSaldos = await BuscarSaldos(clientePayload.Cuentas);

            foreach (var saldo in listSaldos)
                usuarios.Saldos.Add(saldo);
            var saldos = _mapper.Map<IEnumerable<CuentaAfiliado>, IEnumerable<CuentaAfiliadoDTO>>(await _clientsRepository.ObtenerCuentasMovimientosAfiliado(identificationNumber)).ToList();
            var saldosAhorro = saldos.FindAll(x => x.IdConcepto == 1 || x.IdConcepto == 2 || x.IdConcepto == 4 || x.IdConcepto == 23);
            var saldosInteresesAhorro = saldos.FindAll(x => x.IdConcepto == 9 || x.IdConcepto == 24);
            var saldosCesantias = saldos.FindAll(x => x.IdConcepto == 3 || x.IdConcepto == 5 || x.IdConcepto == 15);
            var saldosInteresesCesantias = saldos.FindAll(x => x.IdConcepto == 10 || x.IdConcepto == 17);

            #region Antigua Funcionalidad Saldos

            //var saldos = _mapper.Map<IEnumerable<CuentaAfiliado>, IEnumerable<CuentaAfiliadoDTO>>(await _clientsRepository.ObtenerCuentasMovimientosAfiliado(identificationNumber)).ToList();
            //var saldosAhorro = saldos.FindAll(x => x.IdConcepto == 1 || x.IdConcepto == 2 || x.IdConcepto ==  4 || x.IdConcepto == 23);
            //var saldosInteresesAhorro = saldos.FindAll(x => x.IdConcepto == 9 || x.IdConcepto == 24);
            //var saldosCesantias = saldos.FindAll(x => x.IdConcepto == 3 || x.IdConcepto == 5 || x.IdConcepto == 15);
            //var saldosInteresesCesantias = saldos.FindAll(x => x.IdConcepto == 10 || x.IdConcepto == 17);

            //SaldoDto saldoAhorroDto = new SaldoDto();
            //saldoAhorroDto.Concepto = "Ahorro";
            //saldoAhorroDto.Valor = saldosAhorro.Sum(x => x.Saldo);
            //SaldoDto saldoInteresesAhorroDto = new SaldoDto();
            //saldoInteresesAhorroDto.Concepto = "Int Ahorros";
            //saldoInteresesAhorroDto.Valor = saldosInteresesAhorro.Sum(x => x.Saldo);
            //SaldoDto saldoCesantiasDto = new SaldoDto();
            //saldoCesantiasDto.Concepto = "Cesantias";
            //saldoCesantiasDto.Valor = saldosCesantias.Sum(x => x.Saldo);
            //SaldoDto saldoAhorroCesantiasDto = new SaldoDto();
            //saldoAhorroCesantiasDto.Concepto = "Int Cesantias";
            //saldoAhorroCesantiasDto.Valor = saldosInteresesCesantias.Sum(x => x.Saldo);

            ////valor total para llevar al componente datosPersonales de la modalidad Desafiliación con cesantías
            //SaldoDto valorTotalDto = new SaldoDto();
            //valorTotalDto.Concepto = "Valor Total";
            //valorTotalDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor + saldoCesantiasDto.Valor + saldoAhorroCesantiasDto.Valor);

            ////valor solo aportes para llevar al componente datosPersonales de la modalidad Desafiliación solo aportes
            //SaldoDto valorAportesDto = new SaldoDto();
            //valorAportesDto.Concepto = "Valor Aportes";
            //valorAportesDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor);

            //usuarios.Saldos.Add(saldoAhorroDto);
            //usuarios.Saldos.Add(saldoInteresesAhorroDto);
            //usuarios.Saldos.Add(saldoCesantiasDto);
            //usuarios.Saldos.Add(saldoAhorroCesantiasDto);

            #endregion

            return new Response<ClienteDto> { Data = usuarios };
        }


        /// <summary>
        /// Metodo obtener info cliente por tipo y número de documento 
        /// </summary>
        /// <param name="identificationNumber">Identificacion del cliente</param>
        /// <param name="identificationType">Tipo identificacion</param>
        /// <param name="idCLiente"></param>
        /// <uthor>Erwin Pantoja España</uthor>
        /// <date>4/10/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<ClienteCesantiasDto>> ObtenerInformacionClientePorDocumentoYTipo(int identificationType, string identificationNumber, int idCLiente)
        {
            ClienteCesantiasDto usuarios = this._mapper.Map<ClienteCesantias, ClienteCesantiasDto>(await _clientsRepository.ObtenerInformacionClientePorDocumentoYTipo(identificationType, identificationNumber, idCLiente));
            return new Response<ClienteCesantiasDto> { Data = usuarios };
        }

        private ObtenerBuaRequest ObtenerBuaDto(int tipoId, string identificacion)
        {
            return new ObtenerBuaRequest()
            {
                afiliado = new ObtenerBua()
                {
                    tipo_Id = tipoId,
                    identificacion = identificacion
                }
            };
        }


        /// <summary>
        /// Metodo obtener info cliente por tipo y número de documento 
        /// </summary>
        /// <param name="Cliente">Modelo dto cliente</param>
        /// <uthor>ONicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<ClienteDto>> ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(string tipoDocumento, string numeroIdentificacion, string numeroCelular, DateTime fechaExpedicion)
        {
            var a = await _clientsRepository.ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(
                tipoDocumento, numeroIdentificacion, numeroCelular, fechaExpedicion);
            var cliente = this._mapper.Map<ClienteDto>(a);
            return new Response<ClienteDto> { Data = cliente };
        }

        /// <summary>
        /// Metodo obtener clientes existentes y no esxistentes
        /// </summary>
        /// <param name="Cliente">Modelo dto cliente</param>
        /// <uthor>ONicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<IEnumerable<ClienteSinCrearDTO>>> ValidarClientes(string file)
        {
            var clientes = await _clientsRepository.ValidarNomina(file);
            var respuesta = await _clientsRepository.CrearClientesPorCargaNomina(clientes);

            return new Response<IEnumerable<ClienteSinCrearDTO>>
            {
                Data = this._mapper.Map<IEnumerable<ClienteSinCrearDTO>>(respuesta),
                ReturnMessage = $"Lista de usuarios que no están en BUA creados"
            };
        }

        public async Task<Response<ClienteDto>> RestaurarIntegracionCliente(RestaurarIntegracionClienteDTO restaurarIntegracionCliente, IEnumerable<Claim> claims)
        {
            ObtenerBuaResponse clienteIntegracionGA2 = await ObtenerClienteIntegracionGA2(restaurarIntegracionCliente.IdTipoIdentificacion, restaurarIntegracionCliente.NumeroIdentificacion, claims);
            if (clienteIntegracionGA2 == null) { return new Response<ClienteDto> { Data = null }; }

            ClienteDto cliente = this._mapper.Map<ClienteDto>(clienteIntegracionGA2.ObtenerBUAResult);
            cliente.IdCliente = restaurarIntegracionCliente.IdCliente;
            cliente.IdInformacionEconomica = restaurarIntegracionCliente.IdInformacionFinanciera;
            cliente.IdDireccion = restaurarIntegracionCliente.IdDireccion;
            ClienteDto nuevoCliente = this._mapper.Map<ClienteDto>(await _clientsRepository.RestaurarIntegracionCliente(_mapper.Map<Cliente>(cliente)));

            await InsertarIntegracionCuentas(nuevoCliente, clienteIntegracionGA2.ObtenerBUAResult);

            return new Response<ClienteDto> { Data = nuevoCliente };
        }

        public async Task<ObtenerBuaResponse> ObtenerClienteIntegracionGA2(int identificationType, string identificationNumber, IEnumerable<Claim> claims)
        {
            var url = _optionsCH.UrlCajaHonor + "api/obtenerafiliadobua";
            var uri = new Uri(url);
            var userId = Guid.NewGuid().ToString();
            Response<string> responseIntegracion = await _integraciones.ObtenerBua(uri, ObtenerBuaDto(identificationType, identificationNumber), Guid.Parse(userId));
            ObtenerBuaResponse clienteIntegracionGA2 = JsonConvert.DeserializeObject<Response<ObtenerBuaResponse>>(responseIntegracion.Data.ToString()).Data;

            if (clienteIntegracionGA2 == null) { return null; }
            else { PrepararClienteIntegracion(clienteIntegracionGA2); }

            if (clienteIntegracionGA2.ObtenerBUAResult != null) { clienteIntegracionGA2.ObtenerBUAResult.Payload = responseIntegracion.Data.ToString(); }

            return clienteIntegracionGA2;
        }

        public ObtenerBuaResponse PrepararClienteIntegracion(ObtenerBuaResponse clienteIntegracionGA2)
        {
            if (clienteIntegracionGA2 != null)
            {
                if (clienteIntegracionGA2.ObtenerBUAResult != null)
                {
                    if (clienteIntegracionGA2.ObtenerBUAResult.Direccion != null)
                    {
                        clienteIntegracionGA2.ObtenerBUAResult.Direccion.TelefonoMostrar = clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != "" && clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != "0" ?
                                                                            clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular : "601" + clienteIntegracionGA2.ObtenerBUAResult.Direccion.Telefono;
                        clienteIntegracionGA2.ObtenerBUAResult.Direccion.TipoTelefono = clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != "" && clienteIntegracionGA2.ObtenerBUAResult.Direccion.Celular != "0" ?
                                                                            2 : clienteIntegracionGA2.ObtenerBUAResult.Direccion.Telefono != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.Telefono != "" ? 1
                                                                            : 0;
                        clienteIntegracionGA2.ObtenerBUAResult.Direccion.Correo = clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoInstitucional != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoInstitucional != "" ?
                                                    clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoInstitucional : clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoPersonal;
                        clienteIntegracionGA2.ObtenerBUAResult.Direccion.TipoCorreo = clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoInstitucional != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoInstitucional != "" ?
                                                                            2 : clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoPersonal != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CorreoPersonal != "" ? 1
                                                                            : 0;
                        if (clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion != null)
                        {
                            clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.IdCiudadEntero = clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.IdCiudad != null && clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.IdCiudad != "" ?
                                                                                                Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.IdCiudad) : 0;

                            if (clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento != null)
                            {
                                clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.IdDepartamentoEntero = clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.IdDepartamento != null && clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.IdDepartamento != "" ?
                                                                                                    Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.IdDepartamento) : 0;

                                if (clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.Pais != null)
                                {
                                    clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.Pais.IdPaisEntero = clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.Pais.IdPais != null && clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.Pais.IdPais != "" ?
                                                                                                        Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.LugarExpedicion.Departamento.Pais.IdPais) : 0;

                                }
                            }
                        }

                        if (clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento != null)
                        {
                            clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.IdCiudadEntero = clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.IdCiudad != null && clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.IdCiudad != "" ?
                                                                                                Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.IdCiudad) : 0;

                            if (clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento != null)
                            {
                                clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.IdDepartamentoEntero = clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.IdDepartamento != null && clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.IdDepartamento != "" ?
                                                                                                    Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.IdDepartamento) : 0;

                                if (clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.Pais != null)
                                {
                                    clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.Pais.IdPaisEntero = clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.Pais.IdPais != null && clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.Pais.IdPais != "" ?
                                                                                                        Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.CiudadNacimiento.Departamento.Pais.IdPais) : 0;

                                }
                            }
                        }

                        if (clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia != null)
                        {
                            clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.IdCiudadEntero = clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.IdCiudad != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.IdCiudad != "" ?
                                                                                                Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.IdCiudad) : 0;

                            if (clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento != null)
                            {
                                clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.IdDepartamentoEntero = clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.IdDepartamento != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.IdDepartamento != "" ?
                                                                                                    Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.IdDepartamento) : 0;

                                if (clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.Pais != null)
                                {
                                    clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.Pais.IdPaisEntero = clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.Pais.IdPais != null && clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.Pais.IdPais != "" ?
                                                                                                        Convert.ToInt32(clienteIntegracionGA2.ObtenerBUAResult.Direccion.CiudadResidencia.Departamento.Pais.IdPais) : 0;

                                }
                            }
                        }
                    }
                }
            }

            return clienteIntegracionGA2;
        }

        public async Task<ClienteDto> InsertarIntegracionCuentas(ClienteDto cliente, ClienteIntegracionGA2DTO clienteIntegracionGA2)
        {
            if (clienteIntegracionGA2.Cuentas != null)
            {
                cliente.Cuentas = new List<CuentaDto>();
                foreach (CuentaIntegracion cuenta in clienteIntegracionGA2.Cuentas)
                {
                    CuentaDto cuentaDto = this._mapper.Map<CuentaDto>(cuenta);
                    cuentaDto.IdCliente = cliente.IdCliente;
                    cuentaDto.IdCuentaIntegracion = cuenta.IdCuenta;
                    var cuentaInserted = await _clientsRepository.InsertarCuentaIntegracion(this._mapper.Map<Cuenta>(cuentaDto));
                    cliente.Cuentas.Add(cuentaDto);
                    cliente.Cuentas.LastOrDefault().Movimientos = new List<MovimientoDTO>();

                    foreach (Application.Dto.Movimiento movimiento in cuenta.Movimientos)
                    {
                        MovimientoDTO movimientoDTO = this._mapper.Map<MovimientoDTO>(movimiento);
                        movimientoDTO.CTA_ID = cuentaInserted.CTA_ID;
                        this._mapper.Map<MovimientoDTO>(await _clientsRepository.InsertarMovimientoIntegracion(this._mapper.Map<Entities.Movimiento>(movimientoDTO)));
                        cliente.Cuentas.LastOrDefault().Movimientos.Add(movimientoDTO);

                    }
                }
            }

            if (clienteIntegracionGA2.Dependiente != null)
            {
                cliente.Dependientes = new List<DependienteDto>();
                foreach (DependienteIntegracion dependiente in clienteIntegracionGA2.Dependiente)
                {
                    dependiente.Identificacion = dependiente.Identificacion;
                    DependienteDto dependienteDto = this._mapper.Map<DependienteDto>(dependiente);
                    dependienteDto.IdCliente = cliente.IdCliente;
                    cliente.Dependientes.Add(this._mapper.Map<DependienteDto>(await _clientsRepository.InsertarDependienteIntegracion(_mapper.Map<Dependiente>(dependienteDto))));
                }
            }

            if (clienteIntegracionGA2.AportesCategoria != null)
            {
                cliente.AportesCategoria = new List<AportesClienteDto>();
                foreach (AporteCategoria aporteCategoria in clienteIntegracionGA2.AportesCategoria)
                {
                    AportesClienteDto aportesClienteDto = this._mapper.Map<AportesClienteDto>(aporteCategoria);
                    aportesClienteDto.CLI_ID = cliente.IdCliente;
                    cliente.AportesCategoria.Add(this._mapper.Map<AportesClienteDto>(await _clientsRepository.InsertarAportesIntegracion(_mapper.Map<AportesCliente>(aportesClienteDto))));
                }
            }

            return cliente;
        }

        public async Task<Response<IEnumerable<CuentaAfiliadoDTO>>> ObtenerCuentasMovimientosAfiliado(string identificacion)
        {
            var data = _mapper.Map<IEnumerable<CuentaAfiliado>, IEnumerable<CuentaAfiliadoDTO>>(await _clientsRepository.ObtenerCuentasMovimientosAfiliado(identificacion));
            return new Response<IEnumerable<CuentaAfiliadoDTO>> { Data = data };
        }

        public async Task<Response<CuentaDto>> ObtenerCuentaById(string request)
        {
            return new Response<CuentaDto>() { Data = _mapper.Map<CuentaDto>(await _clientsRepository.ObtenerCuentaById(request)) };
        }

        public async Task<Response<CuentaDto>> ObtenerCuentaClieteByIdNumeroCuenta(int numeroCuenta, int idCliente)
        {
            return new Response<CuentaDto>() { Data = _mapper.Map<CuentaDto>(await _clientsRepository.ObtenerCuentaClieteByIdNumeroCuenta(numeroCuenta, idCliente)) };
        }

        public async Task<Response<IEnumerable<ClienteDto>>> ObtenerClientesById(string clientesIds)
        {

            IEnumerable<ClienteDto> clientes = this._mapper.Map<IEnumerable<ClienteDto>>(await _clientsRepository.ObtenerClientesById(clientesIds));
            return new Response<IEnumerable<ClienteDto>> { Data = clientes };

        }

        public async Task<Response<IEnumerable<CuentaDto>>> ObtenerCuentaIdCuenta(string idCuenta)
        {

            IEnumerable<CuentaDto> cuentas = this._mapper.Map<IEnumerable<CuentaDto>>(await _clientsRepository.ObtenerCuentaIdCuenta(idCuenta));

            return new Response<IEnumerable<CuentaDto>> { Data = cuentas };

        }


        private async Task<List<SaldoDto>> BuscarSaldos(string identificacion)
        {
            var saldos = _mapper.Map<IEnumerable<CuentaAfiliado>, IEnumerable<CuentaAfiliadoDTO>>(await _clientsRepository.ObtenerCuentasMovimientosAfiliado(identificacion)).ToList();
            var saldosAhorro = saldos.FindAll(x => x.IdConcepto == 1 || x.IdConcepto == 2 || x.IdConcepto == 4 || x.IdConcepto == 23);
            var saldosInteresesAhorro = saldos.FindAll(x => x.IdConcepto == 9 || x.IdConcepto == 24);
            var saldosCesantias = saldos.FindAll(x => x.IdConcepto == 3 || x.IdConcepto == 5 || x.IdConcepto == 15);
            var saldosInteresesCesantias = saldos.FindAll(x => x.IdConcepto == 10 || x.IdConcepto == 17);

            SaldoDto saldoAhorroDto = new SaldoDto();
            saldoAhorroDto.Concepto = "Ahorro";
            saldoAhorroDto.Valor = saldosAhorro.Sum(x => x.Saldo);
            SaldoDto saldoInteresesAhorroDto = new SaldoDto();
            saldoInteresesAhorroDto.Concepto = "Int Ahorros";
            saldoInteresesAhorroDto.Valor = saldosInteresesAhorro.Sum(x => x.Saldo);
            SaldoDto saldoCesantiasDto = new SaldoDto();
            saldoCesantiasDto.Concepto = "Cesantias";
            saldoCesantiasDto.Valor = saldosCesantias.Sum(x => x.Saldo);
            SaldoDto saldoAhorroCesantiasDto = new SaldoDto();
            saldoAhorroCesantiasDto.Concepto = "Int Cesantias";
            saldoAhorroCesantiasDto.Valor = saldosInteresesCesantias.Sum(x => x.Saldo);

            //valor total para llevar al componente datosPersonales de la modalidad Desafiliación con cesantías
            SaldoDto valorTotalDto = new SaldoDto();
            valorTotalDto.Concepto = "Valor Total";
            valorTotalDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor + saldoCesantiasDto.Valor + saldoAhorroCesantiasDto.Valor);

            //valor solo aportes para llevar al componente datosPersonales de la modalidad Desafiliación solo aportes
            SaldoDto valorAportesDto = new SaldoDto();
            valorAportesDto.Concepto = "Valor Aportes";
            valorAportesDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor);

            List<SaldoDto> listSaldos = new List<SaldoDto>();

            listSaldos.Add(saldoAhorroDto);
            listSaldos.Add(saldoInteresesAhorroDto);
            listSaldos.Add(saldoCesantiasDto);
            listSaldos.Add(saldoAhorroCesantiasDto);

            return listSaldos;
        }

        private async Task<List<SaldoDto>> BuscarSaldos(List<CuentaDto> cuentas)
        {
            List<ConceptosSaldosBloqueosDto> saldos = new();
            foreach (var item in cuentas)
            {
                List<ConceptosSaldosBloqueosDto> saldosEncontrados = item.ConceptosSaldosBloqueos.FindAll(x => x.IdConcepto == 1 || x.IdConcepto == 2 ||
                                                                  x.IdConcepto == 4 || x.IdConcepto == 23 ||
                                                                  x.IdConcepto == 9 || x.IdConcepto == 24 ||
                                                                  x.IdConcepto == 3 || x.IdConcepto == 5 ||
                                                                  x.IdConcepto == 15 || x.IdConcepto == 10 ||
                                                                  x.IdConcepto == 17);

                saldos = saldos.Concat(saldosEncontrados).ToList();

            }
            var saldosAhorro = saldos.FindAll(x => x.IdConcepto == 1 || x.IdConcepto == 2 || x.IdConcepto == 4 || x.IdConcepto == 23);
            var saldosInteresesAhorro = saldos.FindAll(x => x.IdConcepto == 9 || x.IdConcepto == 24);
            var saldosCesantias = saldos.FindAll(x => x.IdConcepto == 3 || x.IdConcepto == 5 || x.IdConcepto == 15);
            var saldosInteresesCesantias = saldos.FindAll(x => x.IdConcepto == 10 || x.IdConcepto == 17);

            SaldoDto saldoAhorroDto = new SaldoDto();
            saldoAhorroDto.Concepto = "Ahorro";
            saldoAhorroDto.Valor = saldosAhorro.Sum(x => x.SaldoConceptoCuenta);
            SaldoDto saldoInteresesAhorroDto = new SaldoDto();
            saldoInteresesAhorroDto.Concepto = "Int Ahorros";
            saldoInteresesAhorroDto.Valor = saldosInteresesAhorro.Sum(x => x.SaldoConceptoCuenta);
            SaldoDto saldoCesantiasDto = new SaldoDto();
            saldoCesantiasDto.Concepto = "Cesantias";
            saldoCesantiasDto.Valor = saldosCesantias.Sum(x => x.SaldoConceptoCuenta);
            SaldoDto saldoAhorroCesantiasDto = new SaldoDto();
            saldoAhorroCesantiasDto.Concepto = "Int Cesantias";
            saldoAhorroCesantiasDto.Valor = saldosInteresesCesantias.Sum(x => x.SaldoConceptoCuenta);

            //valor total para llevar al componente datosPersonales de la modalidad Desafiliación con cesantías
            SaldoDto valorTotalDto = new SaldoDto();
            valorTotalDto.Concepto = "Valor Total";
            valorTotalDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor + saldoCesantiasDto.Valor + saldoAhorroCesantiasDto.Valor);

            //valor solo aportes para llevar al componente datosPersonales de la modalidad Desafiliación solo aportes
            SaldoDto valorAportesDto = new SaldoDto();
            valorAportesDto.Concepto = "Valor Aportes";
            valorAportesDto.Valor = (saldoAhorroDto.Valor + saldoInteresesAhorroDto.Valor);
            List<SaldoDto> listSaldos = new List<SaldoDto>();

            listSaldos.Add(saldoAhorroDto);
            listSaldos.Add(saldoInteresesAhorroDto);
            listSaldos.Add(saldoCesantiasDto);
            listSaldos.Add(saldoAhorroCesantiasDto);

            return listSaldos;
        }

    }
}

