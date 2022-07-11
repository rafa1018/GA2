using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Consecutivo Logica
    /// <author>Erwin Pantoja España</author>
    /// <date>05/04/2022</date>
    /// </summary>
    public class EmbargosBusinessLogic : IEmbargosBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Embargos
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IEmbargosRepository _juzgadosRepository;
        private readonly IClientRequestProvider _iClientRequestProvider;

        public EmbargosBusinessLogic(
            IMapper mapper,
            IEmbargosRepository JuzgadosRepository,
            IClientRequestProvider iClientRequestProvider)
        {
            _mapper = mapper;
            _juzgadosRepository = JuzgadosRepository;
            _iClientRequestProvider = iClientRequestProvider;

        }


        #region Juzgados


        public async Task<Response<JuzgadosGuidDto>> ObtenerJuzgadoById(Guid id)
        {
            JuzgadosGuid ju = await this._juzgadosRepository.ObtenerJuzgadoById(id);

            JuzgadosGuidDto juzgado = _mapper.Map<JuzgadosGuidDto>(ju);
            return new Response<JuzgadosGuidDto> { Data = juzgado };
        }



        public async Task<Response<JuzgadosDto>> ActualizarJuzgado(JuzgadosDto juzgado)
        {
            return new Response<JuzgadosDto>
            {
                Data = _mapper.Map<JuzgadosDto>(
                    await _juzgadosRepository.ActualizarJuzgado(
                         _mapper.Map<Juzgados>(juzgado)))
            };
        }

        public async Task<Response<JuzgadosDto>> CrearJuzgado(JuzgadosDto juzgado)
        {
            return new Response<JuzgadosDto>
            {
                Data = _mapper.Map<JuzgadosDto>(
                    await _juzgadosRepository.CrearJuzgado(
                         _mapper.Map<Juzgados>(juzgado)))
            };
        }

        public async Task<Response<JuzgadosDto>> EliminarJuzgadoPorId(string idJuzgado)
        {
            return new Response<JuzgadosDto>
            {
                Data = _mapper.Map<JuzgadosDto>(
                    await this._juzgadosRepository.EliminarJuzgadoPorId(idJuzgado))
            };
        }

        

        public async Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorCiudad(JuzgadoDptoCiudadDto juzgadoDptoCiudad)
        {
            IEnumerable<JuzgadosDto> juzgados = _mapper.Map<IEnumerable<JuzgadosDto>>(await 
                _juzgadosRepository.ObtenerJuzgadosPorCiudad(juzgadoDptoCiudad.IdDepartamento, 
                juzgadoDptoCiudad.IdCiudad));
            return new Response<IEnumerable<JuzgadosDto>> { Data = juzgados };
        }

        public async Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorDepartamento(int idDpto)
        {
            IEnumerable<JuzgadosDto> juzgados = _mapper.Map<IEnumerable<JuzgadosDto>>(await _juzgadosRepository.ObtenerJuzgadosPorDepartamento(idDpto));
            return new Response<IEnumerable<JuzgadosDto>> { Data = juzgados };

        }

        public async Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorNombre(string nombreJuzgado)
        {
            IEnumerable<JuzgadosDto> juzgados = _mapper.Map<IEnumerable<JuzgadosDto>>(await _juzgadosRepository.ObtenerJuzgadosPorNombre(nombreJuzgado));
            return new Response<IEnumerable<JuzgadosDto>> { Data = juzgados };
        }


        #endregion

        public async Task<Response<IEnumerable<TipoEmbargosDto>>> ObtenerTiposEmbargos()
        {
            IEnumerable<TipoEmbargosDto> tipoEmbargos = _mapper.Map<IEnumerable<TipoEmbargosDto>>(await _juzgadosRepository.ObtenerTiposEmbargos());
            return new Response<IEnumerable<TipoEmbargosDto>> { Data = tipoEmbargos };
        }

        public async Task<Response<IEnumerable<TiposProcesosDto>>> ObtenerTiposProcesosEmbargos()
        {
            IEnumerable<TiposProcesosDto> tiposProcesos = _mapper.Map<IEnumerable<TiposProcesosDto>>(await _juzgadosRepository.ObtenerTiposProcesosEmbargos());
            return new Response<IEnumerable<TiposProcesosDto>> { Data = tiposProcesos };
        }

        public async Task<Response<EmbargosDto>> InsertarEmbargo(InsetEmbargosDto embargo, Guid user_Id)
        {
        
            Response<ClienteCesantiasDto> clienteDto = await _iClientRequestProvider.ObtenerInformacionClientePorDocumentoYTipo(embargo.ClienteTipoIdentificacion, embargo.ClienteIdentificacion, 0);
            Response<EmbargosDto> respuesta = new Response<EmbargosDto>();

            if (clienteDto.Data == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El cliente no existe";
                return respuesta;

            }

            Embargo emb = new Embargo();
            emb.EBA_RADICADO_WORK_MANAGER = embargo.RadicadoWorkManager;
            emb.EBA_FECHA_RADICADO_WORK_MANAGER = embargo.FechaRadicadoWorkManager;
            emb.EBA_RADICADO_JUZGADO = embargo.RadicadoJuzgado;
            emb.EBA_FECHA_RADICADO_JUZGADO = embargo.FechaRadicadoJuzgado;
            emb.EBA_EMAIL_RESPUESTA = embargo.EmailRespuesta;
            emb.EBA_DIRECCION_RESPUESTA = embargo.DireccionRespuesta;
            emb.EBA_NOMBRE_DEMANDANTE = embargo.NombreDemandante;
            emb.EBA_NOMBRE_DEMANDADO = embargo.NombreDemandado;
            emb.EBA_EXPEDIENTE_BANCO_AGRARIO = embargo.ExpedienteBancoAgrario;
            emb.EBA_REMANENTE = embargo.Remanente;
            emb.EBA_OBSERVACIONES = embargo.Observaciones;
            emb.EBA_RESPUESTA = embargo.Respuesta;
            emb.EBA_VALOR = embargo.Valor;
            emb.CLI_ID = clienteDto.Data.IdCliente;
            emb.EMB_ID_JUZGADO = embargo.JuzgadoId;
            emb.TPE_ID = embargo.ProcesoId;
            emb.TIE_ID = embargo.TipoEmbargoId;
            emb.EBA_CREADOPOR = user_Id;


            EmbargosDto  tipoEmbargos = _mapper.Map<EmbargosDto>(await this._juzgadosRepository.InsertarEmbargo(emb));
            return new Response<EmbargosDto> { Data = tipoEmbargos };
            
        }

        public async Task<Response<IEnumerable<EmbargosDto>>> ObtenerEmbargos()
        {
            IEnumerable<EmbargosDto> embargos = _mapper.Map<IEnumerable<EmbargosDto>>(await this._juzgadosRepository.ObtenerEmbargos());

            string txtClientes = "";

            foreach (var embargosDto in embargos) {
                txtClientes = txtClientes + embargosDto.ClienteId+",";
            }

            Response<IEnumerable<ClienteDto>> clienteDto = await _iClientRequestProvider.ObtenerClientesById(txtClientes);
            List<EmbargosDto> list = new List<EmbargosDto>();

            foreach (EmbargosDto embargosDto in embargos)
            {
                
                foreach (ClienteDto cliente in clienteDto.Data) {

                    if (cliente.IdCliente== embargosDto.ClienteId) {

                        embargosDto.PrimerNombreCliente = cliente.PrimerNombre;
                        embargosDto.SegundoNombreCliente = cliente.SegundoNombre;
                        embargosDto.PrimerApellidoCliente = cliente.PrimerApellido;
                        embargosDto.SegundoApellidoCliente = cliente.SegundoApellido;
                        embargosDto.IdentificacionCliente = cliente.Identificacion;
                        embargosDto.NombreCompletoCliente = cliente.PrimerNombre + " " + cliente.SegundoNombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;
                        TipoIdentificacion tipoDocumemto = await this._juzgadosRepository.ObtenerTipoIdentificacionById(cliente.IdTipoIdentificacion);
                        embargosDto.TipoIdentificacion = tipoDocumemto.TID_DESCRIPCION;

                        break;
                    }
                          
                }

              
                list.Add(embargosDto);

            }

            return new Response<IEnumerable<EmbargosDto>> { Data = list };
        }

        public async Task<Response<EmbargosDto>> EliminarEmbargo(Guid Id)
        {
            EmbargosDto embargo = _mapper.Map<EmbargosDto>(await this._juzgadosRepository.EliminarEmbargo(Id));
            return new Response<EmbargosDto> { Data = embargo };
        }

        public async Task<Response<EmbargosDto>> ActualizarEmbargo(InsetEmbargosDto embargo, Guid user_Id)
        {

            Response<ClienteCesantiasDto> clienteDto = await _iClientRequestProvider.ObtenerInformacionClientePorDocumentoYTipo(embargo.ClienteTipoIdentificacion, embargo.ClienteIdentificacion, 0);
            
            Response<EmbargosDto> respuesta = new Response<EmbargosDto>();

            if (clienteDto.Data == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El cliente no existe";
                return respuesta;
            }

            Embargo emb = new Embargo();
            emb.EBA_ID = embargo.Id;
            emb.EBA_RADICADO_WORK_MANAGER = embargo.RadicadoWorkManager;
            emb.EBA_FECHA_RADICADO_WORK_MANAGER = embargo.FechaRadicadoWorkManager;
            emb.EBA_RADICADO_JUZGADO = embargo.RadicadoJuzgado;
            emb.EBA_FECHA_RADICADO_JUZGADO = embargo.FechaRadicadoJuzgado;
            emb.EBA_EMAIL_RESPUESTA = embargo.EmailRespuesta;
            emb.EBA_DIRECCION_RESPUESTA = embargo.DireccionRespuesta;
            emb.EBA_NOMBRE_DEMANDANTE = embargo.NombreDemandante;
            emb.EBA_NOMBRE_DEMANDADO = embargo.NombreDemandado;
            emb.EBA_EXPEDIENTE_BANCO_AGRARIO = embargo.ExpedienteBancoAgrario;
            emb.EBA_REMANENTE = embargo.Remanente;
            emb.EBA_OBSERVACIONES = embargo.Observaciones;
            emb.EBA_RESPUESTA = embargo.Respuesta;
            emb.EBA_VALOR = embargo.Valor;
            emb.CLI_ID = clienteDto.Data.IdCliente;
            emb.EMB_ID_JUZGADO = embargo.JuzgadoId;
            emb.TPE_ID = embargo.ProcesoId;
            emb.TIE_ID = embargo.TipoEmbargoId;
            emb.EBA_ACTUALIZADOPOR = user_Id;


            EmbargosDto tipoEmbargos = _mapper.Map<EmbargosDto>(await this._juzgadosRepository.ActualizarEmbargo(emb));
            return new Response<EmbargosDto> { Data = tipoEmbargos };
        }

        public async Task<Response<EmbargoCuentaConceptoDto>> InsertarEmbargoCuentaConcepto(EmbargoCuentaConceptoDto dto, Guid user_Id)
        {


            Embargo emb = await this._juzgadosRepository.ObtenerEmbargoWorkManeger(dto.RadicadoWorkManager);

            Response<EmbargoCuentaConceptoDto> respuesta = new Response<EmbargoCuentaConceptoDto>();

            if (emb == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "No hay Embargos con el numero de radicado work manager";
                return respuesta;
            }

            Response<CuentaDto> cuenta = await _iClientRequestProvider.ObtenerCuentaClieteByIdNumeroCuenta(emb.CLI_ID,dto.NumeroCuenta);

 
            if (cuenta.Data == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "No hay una cuenta perteneciente al cliente con el numero de cuenta";
                return respuesta;
            }


            EmbargoCuentaConcepto ecc = new EmbargoCuentaConcepto();
            ecc.ECC_VALOR = dto.Valor;
            ecc.ECC_FECHA_INICIO_EMBARGO = dto.FechaInicio;
            ecc.ECC_FECHA_FIN_EMBARGO= dto.FechaFin;
            ecc.ECC_INDICADOR_CESANTIAS = dto.IndicadorCesantias;
            ecc.EBA_ID = emb.EBA_ID;
            ecc.TRE_ID = dto.TipoRetencionId;
            ecc.TIE_ID = dto.TipoEmbargoId;
            ecc.CTA_ID = cuenta.Data.IdCuenta;
            ecc.CCT_ID = cuenta.Data.conceptoId;
            ecc.EBA_CREADOPOR = user_Id;


            EmbargoCuentaConceptoDto embargoCuenta = _mapper.Map<EmbargoCuentaConceptoDto>(await this._juzgadosRepository.InsertarEmbargoCuentaConcepto(ecc));
            return new Response<EmbargoCuentaConceptoDto> { Data = embargoCuenta };

        }

        public async Task<Response<IEnumerable<EmbargoCuentaConceptoDto>>> ObtenerEmbargosCuentaConcepto()
        {

            IEnumerable<EmbargoCuentaConceptoDto> embargos = _mapper.Map<IEnumerable<EmbargoCuentaConceptoDto>>(await this._juzgadosRepository.ObtenerEmbargosCuentaConcepto());

            string idsEcc = "";

            foreach (EmbargoCuentaConceptoDto embargosDto in embargos) {
                idsEcc = idsEcc + embargosDto.CuentaId + ",";
            }

            Response<IEnumerable<CuentaDto>> cuentas = await _iClientRequestProvider.ObtenerCuentaIdCuenta(idsEcc);

            List<EmbargoCuentaConceptoDto> list = new List<EmbargoCuentaConceptoDto>();




            if (cuentas.Data.Count() > 0)
            {
                foreach (EmbargoCuentaConceptoDto embargosDto in embargos)
                {
                    foreach (CuentaDto cuenta in cuentas.Data) {

                        if (cuenta.IdCuenta== embargosDto.CuentaId) {
                            embargosDto.NumeroCuenta = cuenta.NumeroCuenta;
                        }            
                    }

                    list.Add(embargosDto);
                }
            }
            
          
            return new Response<IEnumerable<EmbargoCuentaConceptoDto>> { Data = list };
      
        }

        public async Task<Response<EmbargoCuentaConceptoDto>> EliminarEmbargoCuentaConcepto(Guid Id)
        {

            EmbargoCuentaConceptoDto embargoCuenta = _mapper.Map<EmbargoCuentaConceptoDto>(await this._juzgadosRepository.EliminarEmbargoCuentaConcepto(Id));
            return new Response<EmbargoCuentaConceptoDto> { Data = embargoCuenta };

        }

        public async Task<Response<EmbargoCuentaConceptoDto>> ActualizarEmbargoCuentaConcepto(EmbargoCuentaConceptoDto emb,Guid user_Id)
        {

            Embargo emba = await this._juzgadosRepository.ObtenerEmbargoWorkManeger(emb.RadicadoWorkManager);

            Response<EmbargoCuentaConceptoDto> respuesta = new Response<EmbargoCuentaConceptoDto>();

            if (emba == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "No hay Embargos con el numero de radicado work manager";
                return respuesta;
            }

            Response<CuentaDto> cuenta = await _iClientRequestProvider.ObtenerCuentaClieteByIdNumeroCuenta(emba.CLI_ID, emb.NumeroCuenta);


            if (cuenta.Data == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "No hay una cuenta perteneciente al cliente con el numero de cuenta";
                return respuesta;
            }


            EmbargoCuentaConcepto ecc = new EmbargoCuentaConcepto();
            ecc.ECC_ID = emb.Id;
            ecc.ECC_VALOR = emb.Valor;
            ecc.ECC_FECHA_INICIO_EMBARGO = emb.FechaInicio;
            ecc.ECC_FECHA_FIN_EMBARGO = emb.FechaFin;
            ecc.ECC_INDICADOR_CESANTIAS = emb.IndicadorCesantias;
            ecc.EBA_ID = emba.EBA_ID;
            ecc.TRE_ID = emb.TipoRetencionId;
            ecc.TIE_ID = emb.TipoEmbargoId;
            ecc.CTA_ID = cuenta.Data.IdCuenta;
            ecc.CCT_ID = cuenta.Data.conceptoId;
            ecc.EBA_ACTUALIZADOPOR = user_Id;

            EmbargoCuentaConceptoDto embargoCuenta = _mapper.Map<EmbargoCuentaConceptoDto>(await this._juzgadosRepository.ActualizarEmbargoCuentaConcepto(ecc));
            return new Response<EmbargoCuentaConceptoDto> { Data = embargoCuenta };

        }

        public async Task<Response<IEnumerable<TipoRetencionDto>>> ObtenerTiposRetenciones()
        {
            IEnumerable<TipoRetencionDto> retenciones = _mapper.Map<IEnumerable<TipoRetencionDto>>(await this._juzgadosRepository.ObtenerTiposRetenciones());
            return new Response<IEnumerable<TipoRetencionDto>> { Data = retenciones };
        }

        public async Task<Response<BeneficiariosPagoEmbargoDto>> InsertarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargoDto be,Guid userId)
        {


            Embargo embargo = await this._juzgadosRepository.ObtenerEmbargoWorkManeger(be.RadicadoWorkManager);
            BeneficiariosPagoEmbargo emb = new BeneficiariosPagoEmbargo();
            emb.EBA_ID = embargo.EBA_ID;
            emb.TID_ID = be.TipoDocumentoId;
            emb.BPE_NUMERO_IDENTIFICACION = be.NumeroIdentificacion;
            emb.BPE_PRIMER_NOMBRE = be.PrimerNombre;
            emb.BPE_SEGUNDO_NOMBRE = be.SegundoNombre;
            emb.BPE_PRIMER_APELLIDO = be.PrimerApellido;
            emb.BPE_SEGUNGO_APELLIDO = be.SegundoApellido;
            emb.BPE_CREADOPOR = userId;
      
            BeneficiariosPagoEmbargoDto beneficiario = _mapper.Map<BeneficiariosPagoEmbargoDto>(await this._juzgadosRepository.InsertarBeneficiariosPagoEmbargos(emb));
            return new Response<BeneficiariosPagoEmbargoDto> { Data = beneficiario };
                       
        }

        public async Task<Response<BeneficiariosPagoEmbargoDto>> ActualizarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargoDto be, Guid user_Id)
        {

            Embargo embargo = await this._juzgadosRepository.ObtenerEmbargoWorkManeger(be.RadicadoWorkManager);
           


            BeneficiariosPagoEmbargo emb = new BeneficiariosPagoEmbargo();
            emb.BPE_ID = be.Id;
            emb.EBA_ID = embargo.EBA_ID;
            emb.TID_ID = be.TipoDocumentoId;
            emb.BPE_NUMERO_IDENTIFICACION = be.NumeroIdentificacion;
            emb.BPE_PRIMER_NOMBRE = be.PrimerNombre;
            emb.BPE_SEGUNDO_NOMBRE = be.SegundoNombre;
            emb.BPE_PRIMER_APELLIDO = be.PrimerApellido;
            emb.BPE_SEGUNGO_APELLIDO = be.SegundoApellido;
            emb.BPE_ACTUALIZADOPOR = user_Id;

            BeneficiariosPagoEmbargoDto beneficiario = _mapper.Map<BeneficiariosPagoEmbargoDto>(await this._juzgadosRepository.ActualizarBeneficiariosPagoEmbargos(emb));
            return new Response<BeneficiariosPagoEmbargoDto> { Data = beneficiario };

        }

        public async Task<Response<BeneficiariosPagoEmbargoDto>> EliminarBeneficiariosPagoEmbargos(Guid Id)
        {
            BeneficiariosPagoEmbargoDto beneficiario = _mapper.Map<BeneficiariosPagoEmbargoDto>(await this._juzgadosRepository.EliminarBeneficiariosPagoEmbargos(Id));
            return new Response<BeneficiariosPagoEmbargoDto> { Data = beneficiario };

        }

        public async Task<Response<IEnumerable<BeneficiariosPagoEmbargoDto>>> ObtenerBeneficiariosEmbargo()
        {
            IEnumerable<BeneficiariosPagoEmbargoDto> retenciones = _mapper.Map<IEnumerable<BeneficiariosPagoEmbargoDto>>(await this._juzgadosRepository.ObtenerBeneficiariosEmbargo());
            return new Response<IEnumerable<BeneficiariosPagoEmbargoDto>> { Data = retenciones };
        }

        public async Task<Response<IEnumerable<EmbargosDto>>> ObtenerEmbargosRangoFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            IEnumerable<EmbargosDto> embargos = _mapper.Map<IEnumerable<EmbargosDto>>(await this._juzgadosRepository.ObtenerEmbargosRangoFecha(FechaInicial,FechaFinal));

            string txtClientes = "";

            foreach (var embargosDto in embargos)
            {
                txtClientes = txtClientes + embargosDto.ClienteId + ",";
            }

            Response<IEnumerable<ClienteDto>> clienteDto = await _iClientRequestProvider.ObtenerClientesById(txtClientes);
            List<EmbargosDto> list = new List<EmbargosDto>();

            foreach (EmbargosDto embargosDto in embargos)
            {

                foreach (ClienteDto cliente in clienteDto.Data)
                {

                    if (cliente.IdCliente == embargosDto.ClienteId)
                    {

                        embargosDto.PrimerNombreCliente = cliente.PrimerNombre;
                        embargosDto.SegundoNombreCliente = cliente.SegundoNombre;
                        embargosDto.PrimerApellidoCliente = cliente.PrimerApellido;
                        embargosDto.SegundoApellidoCliente = cliente.SegundoApellido;
                        embargosDto.IdentificacionCliente = cliente.Identificacion;
                        embargosDto.NombreCompletoCliente = cliente.PrimerNombre + " " + cliente.SegundoNombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;
                        TipoIdentificacion tipoDocumemto = await this._juzgadosRepository.ObtenerTipoIdentificacionById(cliente.IdTipoIdentificacion);
                        embargosDto.TipoIdentificacion = tipoDocumemto.TID_DESCRIPCION;


                        break;
                    }

                }

                list.Add(embargosDto);

            }

            return new Response<IEnumerable<EmbargosDto>> { Data = list };
        }

        public async Task<Response<DesembargoDto>> InsertarDesembargo(Guid Id)
        {
            DesembargoDto desembargo = _mapper.Map<DesembargoDto>(await this._juzgadosRepository.InsertarDesembargo(Id));
            return new Response<DesembargoDto> { Data = desembargo };
        }

        public async Task<Response<IEnumerable<ObtenerDesembargoDto>>> ObtenerDesembargo()
        {

            
            IEnumerable<ObtenerDesembargoDto> desembargosDto = _mapper.Map<IEnumerable<ObtenerDesembargoDto>>(await this._juzgadosRepository.ObtenerDesembargo());


            string txtClientes = "";
            string txtCuentas = "";

            foreach (ObtenerDesembargoDto desembargo in desembargosDto)
            {
                txtClientes = txtClientes + desembargo.ClienteId+ ",";
                txtCuentas = txtCuentas + desembargo.CuentaId+ ",";
            }

            Response<IEnumerable<ClienteDto>> clienteDto = await _iClientRequestProvider.ObtenerClientesById(txtClientes);
            Response<IEnumerable<CuentaDto>> cuentas = await _iClientRequestProvider.ObtenerCuentaIdCuenta(txtCuentas);

            List<ObtenerDesembargoDto> list = new List<ObtenerDesembargoDto>();

            foreach (ObtenerDesembargoDto desembargoDto in desembargosDto)
            {
                foreach (ClienteDto cliente in clienteDto.Data)
                {
                    if (cliente.IdCliente == desembargoDto.ClienteId)
                    {
                        desembargoDto.Cliente = cliente.PrimerNombre + " " + cliente.SegundoNombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;
                        break;
                    }
                }

                foreach (CuentaDto cuenta in cuentas.Data)
                {

                    if (cuenta.IdCuenta == desembargoDto.CuentaId)
                    {
                        desembargoDto.Cuenta= cuenta.NumeroCuenta;
                        break;
                    }
                }
                list.Add(desembargoDto);
            }


             return new Response<IEnumerable<ObtenerDesembargoDto>> { Data = list };
        }

        public async Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasPorRadicadoWordManager(string numeroRadicado)
        {

            Embargo embargo = await this._juzgadosRepository.ObtenerEmbargoWorkManeger(numeroRadicado);

            if (embargo != null)
            {

                Response<IEnumerable<CuentaClienteDto>> clienteDto = await _iClientRequestProvider.ObtenerCuentasClienteId(embargo.CLI_ID);
                return clienteDto;

            }
            else {

                Response<IEnumerable<CuentaClienteDto>> respuesta = new Response<IEnumerable<CuentaClienteDto>>();
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "No hay Embargos con el numero de radicado work manager";
                return respuesta;

            }

        }
    }
}
