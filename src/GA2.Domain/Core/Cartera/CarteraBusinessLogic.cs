using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class CarteraBusinessLogic : ICarteraBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICarteraRepository _carteraRepository;
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        private readonly IConfiguration _configuration;
        private readonly IBlobStorageGenericRepository _blobStorageGenericRepository;
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        public CarteraBusinessLogic(IMapper mapper, ICarteraRepository carteraRepository, IConfiguration configuration, ICreditoBusinessLogic creditoBusinessLogic,
                                    IBlobStorageGenericRepository blobStorageGenericRepository, ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _mapper = mapper;
            _carteraRepository = carteraRepository;
            _configuration = configuration;
            _creditoBusinessLogic = creditoBusinessLogic;
            _blobStorageGenericRepository = blobStorageGenericRepository;
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }


        /// <summary>
        /// Actualiza Simulacion
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<TasaSimuladorDto>> ActualizarTasasSimulacion(TasaSimuladorDto tasas)
        {
            var tasaUpdate = this._mapper.Map<TasaSimulador>(tasas);

            var response = this._mapper.Map<TasaSimuladorDto>(await this._carteraRepository.ActualizarTasasSimulacion(tasaUpdate));
            return new Response<TasaSimuladorDto> { Data = response };
        }

        /// <summary>
        /// Aplicar Pago
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>19/10/2021</Date>
        public async Task<Response<AplicacionPagoDto>> AplicarPago(PagoAplicarDto request)
        {
            InformacionCreditoDto credito = new();
            //Obtengo el credito bien sea por id o por numero de credito
            if (!string.IsNullOrEmpty(request.Identificacion))
                credito = (await this.ObtenerCreditoCarteraByIdentificacion(request.Identificacion)).Data;
            else
                credito = (await this.ObtenerCreditoCartera(request.NumeroCredito)).Data;

            //Se obtienen los parametros generales del aplicativo
            var parametrosGenerales = (await this.ObtenerParametrosAplicacionPagos()).Data;

            //Calcula los dias que lleva en mora
            var diasMoraCurso = (int)(DateTime.Now - ((DateTime)(credito.FechaProximoPago))).TotalDays;
            credito.DiasMora += diasMoraCurso;


            AplicacionPagoDto aplicacionPago = new();
            InformacionCreditoDto updateCredito = credito;

            //Establece los datos fijos de la actulizacion de credito
            aplicacionPago.IdAplicacionPago = Guid.NewGuid();
            aplicacionPago.IdCredito = credito.IdCredito;
            aplicacionPago.FechaPago = DateTime.Now;
            aplicacionPago.FechaAplicacion = request.FechaPago;
            aplicacionPago.ValorPago = request.ValorPago;
            aplicacionPago.CreadoPor = Guid.NewGuid();
            aplicacionPago.FechaCreacion = DateTime.Now;
            aplicacionPago.ModificadoPor = Guid.NewGuid();
            aplicacionPago.FechaModificacion = DateTime.Now;

            //Saldo que se va a abonar
            var saldoAplicar = credito.ValorCuota;
            credito.TasaCreditoPer *= 100;


            //Tasa MV
            var tasaMV = (Math.Pow(double.Parse((1 + (credito.TasaCreditoPer)).ToString()),(double)0.083333333333333)) - 1;
            //Calcula los valores de la deuda para el periodo actual
            var saldo=(credito.SaldoCapital - credito.CanonExtraordinario);
            var pagarSeguroVida = Math.Round(((float)credito.ValorDesembolso) * (credito.TasaSeguroVida));// preguntar si el valor es correcto
            var pagarSeguroHogar = Math.Round(((float)credito.ValorVivienda) * (credito.TasaSeguroHogar));// preguntar si el valor es correcto
            var pagarIntereses = (int)(credito.AlivioFrech == false ? ((float)saldo * (tasaMV)) : ((float)saldo * credito.TasaFrech)); // preguntar si el valor es correcto
            var pagoCapital = Math.Round(((int)credito.ValorCuota) - pagarSeguroHogar - pagarSeguroVida - pagarIntereses);

            //Pago Seguro Hogar
            var valorAcumuladoSeguroHogar = credito.AcumuladoSeguroHogar + (decimal)(pagarSeguroHogar);
            var fechaUltimoPagoSeguroHogar = credito.FechaUltimoPagoSeguroHogar;
            var tasaNominalSeguroHogar = credito.TasaSeguroHogar;
            var valorPorAplicar = saldoAplicar;

            var valorSeguroHogarC = default(decimal);

            //Valida si valor a aplicar cubre el acumulado de seguro hogar
            if (valorPorAplicar < valorAcumuladoSeguroHogar)
            {
                var diasSeguroHogarC = (int)((valorPorAplicar * 30) / valorAcumuladoSeguroHogar);
                valorAcumuladoSeguroHogar -= valorPorAplicar;
                fechaUltimoPagoSeguroHogar = fechaUltimoPagoSeguroHogar.AddDays(diasSeguroHogarC);
                aplicacionPago.AbonoSeguroHogar = valorPorAplicar;
                updateCredito.AcumuladoSeguroHogar -= valorAcumuladoSeguroHogar;
                updateCredito.FechaUltimoPagoSeguroHogar = fechaUltimoPagoSeguroHogar;
                valorPorAplicar = 0;
            }
            else
            {
                //var diasSeguroHogarC = credito.DiasSeguroHogar;
                valorSeguroHogarC = valorAcumuladoSeguroHogar;
                valorAcumuladoSeguroHogar -= valorSeguroHogarC;
                fechaUltimoPagoSeguroHogar = aplicacionPago.FechaAplicacion;
                valorPorAplicar -= valorSeguroHogarC;
                aplicacionPago.AbonoSeguroHogar = valorSeguroHogarC;
                updateCredito.AcumuladoSeguroHogar = valorAcumuladoSeguroHogar;
                updateCredito.FechaUltimoPagoSeguroHogar = fechaUltimoPagoSeguroHogar;
            }


            //Pago Seguro Vida

            var valorAcumuladoSeguroVida = credito.AcumuladoSeguroVida + (decimal)pagarSeguroVida;
            var fechaUltimoPagoSeguroVida = credito.FechaUltimoPago;
            var tasaNominalSeguroVida = credito.TasaSeguroVida;


            var valorSeguroVidaC = default(decimal);
            if (valorPorAplicar < valorAcumuladoSeguroVida)
            {
                var diasSeguroVidaC = (int)((valorPorAplicar * 30) / valorAcumuladoSeguroVida);
                fechaUltimoPagoSeguroVida = fechaUltimoPagoSeguroVida.AddDays(diasSeguroVidaC);
                aplicacionPago.AbonoSeguroVida = valorPorAplicar;
                updateCredito.AcumuladoSeguroVida = valorAcumuladoSeguroVida - valorPorAplicar;
                valorPorAplicar -= valorPorAplicar;
            }
            else
            {
                valorSeguroVidaC = valorAcumuladoSeguroVida;
                valorAcumuladoSeguroVida -= valorSeguroVidaC;
                fechaUltimoPagoSeguroVida = fechaUltimoPagoSeguroVida.AddMonths(1);
                valorPorAplicar -= valorSeguroVidaC;
                aplicacionPago.AbonoSeguroVida = valorSeguroVidaC;
                updateCredito.AcumuladoSeguroVida = valorAcumuladoSeguroVida;
                updateCredito.FechaUltimoPagoSeguroVida = fechaUltimoPagoSeguroVida;

            }

            //Pago Interes Mora
            var acumuladoInteresMora = credito.AcumuladoInteresMora;
            var capitalMora = credito.SaldoCapitalMora;
            var fechaUltimoPagoInteresMora = credito.FechaUltimoPago;
            var diasMora = credito.DiasMora;
            var valorMoraC = default(decimal);
            var valorMoraDia = default(double);

            if (diasMoraCurso > 0)
            {
                capitalMora += (decimal)pagoCapital;
                var tasaMora = parametrosGenerales.TasaMora / 100;
                var factorDias = parametrosGenerales.FactorDias / 30;
                var numeroBase = 1 + (double)tasaMora;
                var exponente = (1F / 12F);
                var tasaNominal = Math.Pow(numeroBase, exponente) - 1;
                valorMoraDia = Math.Round((tasaNominal * (double)capitalMora));
                var acumuladoMora = valorMoraDia * diasMora;
                acumuladoInteresMora += (decimal)acumuladoMora;
            }

            //Cuando el valor del pago no alcanza para cubrir los interesesm por mora
            if (request.ValorPago < acumuladoInteresMora)
            {
                var diasMoraC = (int)(((double)(request.ValorPago * diasMora) / (valorMoraDia * diasMora)));
                var diferenciaDias = diasMora - diasMoraC;
                diasMora = diferenciaDias < 0 ? 0 : diasMora;

                aplicacionPago.AbonoInteresMora = request.ValorPago;
                acumuladoInteresMora -= request.ValorPago;
                updateCredito.AcumuladoInteresMora = acumuladoInteresMora < 0 ? 0 : acumuladoInteresMora;
                updateCredito.FechaUltimoPagoInteresMora = credito.FechaUltimoPagoInteresMora.AddDays(1);//preguntar como calculamos la fecha
            }
            //Cuando el valor del pago alcanza para cubrir los interesesm por mora
            else
            {
                var diasMoraC = diasMora;
                valorMoraC = acumuladoInteresMora;
                valorPorAplicar = (request.ValorPago - acumuladoInteresMora);
                acumuladoInteresMora -= valorMoraC;
                fechaUltimoPagoInteresMora = fechaUltimoPagoInteresMora.AddDays(diasMoraC);//deberia ser el dia que se hace el pago?
                diasMora -= diasMoraC;
                updateCredito.AcumuladoInteresMora -= acumuladoInteresMora;
                aplicacionPago.AbonoInteresMora = valorMoraC;
                updateCredito.DiasMora = 0;
            }





            //Pago Intereses Corrientes

            var valorAcumuladoInteresesCorrientes = credito.AcumuladoInteresCorriente + Math.Round((decimal)pagarIntereses);
            var fechaUltimoPagoInteresesCorrientes = credito.FechaUltimoPagoInteresCorriente;

            var valorInteresC = default(decimal);
            if (valorPorAplicar < valorAcumuladoInteresesCorrientes)
            {
                var tasaCredito = credito.TasaCreditoPer;
                var factorCalculoDias = parametrosGenerales.FactorDias / 30;
                var diasMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                var diasInteresC = (int)((valorPorAplicar * diasMes) / valorAcumuladoInteresesCorrientes);
                aplicacionPago.AbonoInteresCorriente = valorPorAplicar;
                updateCredito.AcumuladoInteresCorriente = valorAcumuladoInteresesCorrientes - valorPorAplicar;
                fechaUltimoPagoInteresesCorrientes = fechaUltimoPagoInteresesCorrientes.AddDays(diasInteresC);
                updateCredito.FechaUltimoPagoInteresCorriente = fechaUltimoPagoInteresesCorrientes;
                updateCredito.FechaUltimoPagoInteresCorriente = fechaUltimoPagoInteresesCorrientes;
                valorPorAplicar -= valorPorAplicar;

            }
            else
            {
                //var diasInteresC = credito.DiasInteresesCorriente; // revisar
                valorInteresC = valorAcumuladoInteresesCorrientes;
                valorAcumuladoInteresesCorrientes -= valorInteresC;
                updateCredito.AcumuladoInteresCorriente = valorAcumuladoInteresesCorrientes;
                fechaUltimoPagoInteresesCorrientes = fechaUltimoPagoInteresesCorrientes.AddMonths(1);
                aplicacionPago.AbonoInteresCorriente = valorInteresC;
                valorPorAplicar -= valorInteresC;
            }

            //Abono a capital
            if (valorPorAplicar > 0)
            {
                var valorCapitalC = valorPorAplicar;
                aplicacionPago.AbonoCapital = valorCapitalC;
                updateCredito.SaldoCapital -= valorCapitalC;
                valorPorAplicar = default(decimal);
                updateCredito.PlazoActual -= 1;
                updateCredito.NumeroCuotasCanceladas += 1;

            }
            updateCredito.FechaModificacion = DateTime.Now;
            //var borrar= JsonConvert.SerializeObject(updateCredito);//Delete this line
            await this._carteraRepository.ActualizarCredito(this._mapper.Map<InformacionCredito>(updateCredito));

            return new Response<AplicacionPagoDto>() { Data = this._mapper.Map<AplicacionPagoDto>(await this._carteraRepository.AplicarPago(this._mapper.Map<AplicacionPago>(aplicacionPago))) };
        }

        /// <summary>
        /// Obtener Credito Cartera By Identificacion
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        private async Task<Response<InformacionCreditoDto>> ObtenerCreditoCarteraByIdentificacion(string identificacion)
        {
            var credito = await this._carteraRepository.ObtenerCreditoCarteraByIdentificacion(identificacion);

            return new Response<InformacionCreditoDto>() { Data = this._mapper.Map<InformacionCreditoDto>(credito) };
        }

        public async Task<Response<ProductoClienteDto>> EjecutarDesembolso(RequestEjecucionDesembolsoDto request)
        {
            var producto = await this._carteraRepository.PrepararEjecucionDesembolso(request.TipoIdentificacion, request.Identificacion);

            producto.CRE_FECHA_CREACION = producto.CRE_FECHA_DESEMBOLSO = producto.CRE_FECHA_ESTADO = producto.CRE_FECHA_MODIFICACION = producto.CRE_FECHA_ULTIMO_PAGO =
                producto.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE = producto.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA = producto.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR =
                producto.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA = DateTime.Today;

            producto.CRE_FECHA_PROXIMO_PAGO = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(2).AddDays(-1);

            producto.ESC_ID = 1;
            var ejecutado = await this._carteraRepository.EjecutarDesembolso(producto);

            return new Response<ProductoClienteDto>() { Data = _mapper.Map<ProductoClienteDto>(ejecutado) };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>19/10/2021</Date>
        public async Task<Response<InformacionCreditoDto>> ObtenerCreditoCartera(int request)
        {
            return new Response<InformacionCreditoDto> { Data = this._mapper.Map<InformacionCreditoDto>(await this._carteraRepository.ObtenerCreditoCartera(request)) };
        }

        /// <summary>
        /// Obtener parametros pagos
        /// </summary>
        /// <returns></returns>
        public async Task<Response<ParametrosAplicacionPagosDto>> ObtenerParametrosAplicacionPagos()
        {
            return new Response<ParametrosAplicacionPagosDto>() { Data = this._mapper.Map<ParametrosAplicacionPagosDto>(await this._carteraRepository.ObtenerParametrosAplicacionPagos()) };
        }

        /// <summary>
        /// Obtiene productos por cliente
        /// </summary>
        /// <param name="productoCliente"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>6/09/2021</Date>

        public async Task<Response<IEnumerable<ProductoClienteDto>>> ObtenerProductoCliente(SolicitudProductoPorClienteDto request)
        {
            var response = await this._carteraRepository.ObtenerProductoCliente(request.TipoIdentificacion, request.Identificacion);
            return new Response<IEnumerable<ProductoClienteDto>> { Data = this._mapper.Map<IEnumerable<ProductoClienteDto>>(response) };
        }



        public async Task<Response<ProductoClienteDto>> PrepararEjecucionDesembolso(SolicitudProductoPorClienteDto request)
        {
            var response = await this._carteraRepository.PrepararEjecucionDesembolso(request.TipoIdentificacion, request.Identificacion);
            var abonoExtra = await this._carteraRepository.ObtenerAbonoExtra(request.Identificacion);
            if (response != null && abonoExtra != null)
            {
                response.TIPO_IDENTIFICACION = request.TipoIdentificacion;
                response.CLI_IDENTIFICACION = request.Identificacion;
                response.CRE_TIPO_ABONO_EXTRA = abonoExtra.TIPO_ABONO_EXTRA;
                response.CRE_VALOR_ABONO_EXTRA = (int)abonoExtra.VALOR_ABONO_EXTRA;
                response.CRE_FECHA_CREACION = response.CRE_FECHA_DESEMBOLSO = response.CRE_FECHA_ESTADO = response.CRE_FECHA_MODIFICACION =
                response.CRE_FECHA_ULTIMO_PAGO = response.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE = response.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA =
                response.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR = response.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA = DateTime.Now;
                response.CRE_SALDO_CAPITAL = response.CRE_VALOR_DESEMBOLSO;
                response.CRE_DIAS_MORA = 0;
                response.CRE_SALDO_CAPITAL_MORA = response.CRE_VALOR_DEUDA_REMANENTE = response.CRE_VALOR_OPCION_COMPRA =
                response.CRE_ACUMULADO_INTERES_MORA = response.CRE_ACUMULADO_INTERES_CORRIENTE = response.CRE_ACUMULADO_SEGURO_HOGAR =
                response.CRE_TASA_SEGURO_VIDA = 0;

                response.CRE_TASA_CREDITO_PER = ((decimal)(Math.Pow((double)(1 + response.CRE_TASA_CREDITO_EA), 1 / 12) - 1)); ;//Aplicar formula para obtener tasa nominal a partir de response.CRE_TASA_CREDITO_EA

                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) > 29)
                {
                    response.CRE_DIA_PAGO = 30;
                    if (DateTime.Now > DateTime.Parse($"{response.CRE_DIA_PAGO}/{DateTime.Now.Month}/{DateTime.Now.Month}"))
                    {
                        var fechaProximoMes = DateTime.Now.AddMonths(1);
                        if (DateTime.DaysInMonth(fechaProximoMes.Year, fechaProximoMes.Month) > 29)
                        {
                            response.CRE_FECHA_PROXIMO_PAGO = DateTime.Parse($"{30}/{fechaProximoMes.Month}/{fechaProximoMes.Year}");
                        }
                        else
                        {
                            response.CRE_FECHA_PROXIMO_PAGO = DateTime.Parse($"{DateTime.DaysInMonth(fechaProximoMes.Year, fechaProximoMes.Month)}/{fechaProximoMes.Month}/{fechaProximoMes.Year}");
                        }
                    }
                }
                else
                {
                    response.CRE_DIA_PAGO = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                    var fechaProximoMes = DateTime.Now.AddMonths(1);
                    if (DateTime.DaysInMonth(fechaProximoMes.Year, fechaProximoMes.Month) > 29)
                    {
                        response.CRE_FECHA_PROXIMO_PAGO = DateTime.Parse($"{30}/{fechaProximoMes.Month}/{fechaProximoMes.Year}");
                    }
                    else
                    {
                        response.CRE_FECHA_PROXIMO_PAGO = DateTime.Parse($"{DateTime.DaysInMonth(fechaProximoMes.Year, fechaProximoMes.Month)}/{fechaProximoMes.Month}/{fechaProximoMes.Year}");
                    }
                }

                var data = await this._carteraRepository.EjecutarDesembolso(response);
                return new Response<ProductoClienteDto> { Data = this._mapper.Map<ProductoClienteDto>(response) };
            }

            return null;
        }

        /// <summary>
        /// Obtiene todos los registros de parametros 
        /// </summary>
        /// <param name="consultarTasas"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>03/12/2021</Date>

        public async Task<Response<IEnumerable<TasaSimuladorDto>>> ObtenerTasasSimulador()
        {
            var catalogoTasas = this._mapper.Map<IEnumerable<TasaSimuladorDto>>(await this._carteraRepository.ObtenerTasasSimulador());
            return new Response<IEnumerable<TasaSimuladorDto>> { Data = catalogoTasas };
        }

        /// <summary>
        /// Crear registro Simulacion
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<TasaSimuladorDto>> CrearTasasSimulacion(TasaSimuladorDto tasas)
        {
            var tasaCreate = this._mapper.Map<TasaSimulador>(tasas);

            var response = this._mapper.Map<TasaSimuladorDto>(await this._carteraRepository.CrearTasasSimulacion(tasaCreate));
            return new Response<TasaSimuladorDto> { Data = response };
        }


        /// <summary>
        /// Elimina un registro de SIM_SIMULADOR
        /// </summary>
        /// <param name="tasas"></param>
        /// /// <Author>Sergio ortega</Author>
        /// <Date>03/12/2021</Date>
        /// <returns></returns>
        public async Task<Response<TasaSimuladorDto>> EliminarRegistroSimuladorPorId(TasaSimuladorDto tasas)
        {
            var tasaDelete = this._mapper.Map<TasaSimulador>(tasas);

            var response = this._mapper.Map<TasaSimuladorDto>(await this._carteraRepository.EliminarRegistroSimuladorPorId(tasaDelete));

            return new Response<TasaSimuladorDto> { Data = response };
        }

        /// <summary>
        /// Obtiene todos los registros de las excepciones
        /// </summary>
        /// <param name="consultarExcepciones"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>03/12/2021</Date>

        public async Task<Response<IEnumerable<TasaSimuladorDto>>> ConsultarTipoActorById(TasaSimuladorDto tasas)

        {
            var consultaExcepcion = this._mapper.Map<TasaSimulador>(tasas);

            var response = this._mapper.Map<IEnumerable<TasaSimuladorDto>>(await this._carteraRepository.ConsultarTipoActorById(consultaExcepcion));
            return new Response<IEnumerable<TasaSimuladorDto>> { Data = response };
        }


        /// <summary>
        /// Obtiene todos los tipos de actores
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>29/12/2021</Date>

        public async Task<Response<IEnumerable<TipoActorDto>>> ObtenerTipoActor()

        {
            var response = this._mapper.Map<IEnumerable<TipoActorDto>>(await this._carteraRepository.ObtenerTipoActor());
            return new Response<IEnumerable<TipoActorDto>> { Data = response };
        }

        /// <summary>
        /// Crear actor Simulacion
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<ParametrosTasaActorDto>> CrearTasaActor(ParametrosTasaActorDto actores)
        {
            var actorCreate = this._mapper.Map<ParametrosTasaActor>(actores);

            var response = this._mapper.Map<ParametrosTasaActorDto>(await this._carteraRepository.CrearTasaActor(actorCreate));
            return new Response<ParametrosTasaActorDto> { Data = response };
        }

        /// <summary>
        /// Actualiza parametros simulador actor
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<ParametrosTasaActorDto>> ActualizarTasaSimuladorActor(ParametrosTasaActorDto actores)
        {
            var actorUpdate = this._mapper.Map<ParametrosTasaActor>(actores);

            var response = this._mapper.Map<ParametrosTasaActorDto>(await this._carteraRepository.ActualizarTasaSimuladorActor(actorUpdate));
            return new Response<ParametrosTasaActorDto> { Data = response };
        }

        /// <summary>
        /// Elimina un registro de PAR_TASA_SIMULADOR_ACTOR
        /// </summary>
        /// <param name="tasas"></param>
        /// /// <Author>Sergio ortega</Author>
        /// <Date>05/01/2022</Date>
        /// <returns></returns>
        public async Task<Response<ParametrosTasaActorDto>> EliminarParametroSimuladorActor(ParametrosTasaActorDto actores)
        {
            var actorDelete = this._mapper.Map<ParametrosTasaActor>(actores);

            var response = this._mapper.Map<ParametrosTasaActorDto>(await this._carteraRepository.EliminarParametroSimuladorActor(actorDelete));

            return new Response<ParametrosTasaActorDto> { Data = response };

        }

        /// <summary>
        /// Consulta las unidades ejecutoras
        /// </summary>
        /// <param name="tasas"></param>
        /// /// <Author>Sergio ortega</Author>
        /// <Date>09/01/2022</Date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<UnidadesEjecutorasDto>>> ObtenerUnidadesEjecutorasPorId(UnidadesEjecutorasDto unidades)
        {
            var consultaUnidadEjecutora = this._mapper.Map<UnidadesEjecutoras>(unidades);

            var response = this._mapper.Map<IEnumerable<UnidadesEjecutorasDto>>(await this._carteraRepository.ObtenerUnidadesEjecutorasPorId(consultaUnidadEjecutora));

            return new Response<IEnumerable<UnidadesEjecutorasDto>> { Data = response };
        }
        /// <summary>
        /// Crea parametros unidad ejecutora
        /// </summary>
        /// <param name="unidadesEjecutoras"></param>
        /// /// /// <Author>Sergio ortega</Author>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Response<UnidadesEjecutorasDto>> CrearUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidades)
        {
            var unidadCreate = this._mapper.Map<UnidadesEjecutoras>(unidades);

            var response = this._mapper.Map<UnidadesEjecutorasDto>(await this._carteraRepository.CrearUnidadEjecutoraSimulador(unidadCreate));

            return new Response<UnidadesEjecutorasDto> { Data = response };

        }
        /// <summary>
        /// Consulta nombres de las unidades ejecutoras
        /// </summary>
        /// <param name="unidadesEjecutoras"></param>
        /// <Author>Sergio ortega</Author>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Response<IEnumerable<UnidadesEjecutorasDto>>> ConsultarUnidadEjecutora()

        {
            var response = this._mapper.Map<IEnumerable<UnidadesEjecutorasDto>>(await this._carteraRepository.ConsultarUnidadEjecutora());
            return new Response<IEnumerable<UnidadesEjecutorasDto>> { Data = response };
        }


        /// <summary>
        /// Actualiza parametros unidad ejecutora
        /// </summary>
        /// <param name="unidadesEjecutoras"></param>
        ///  <Author>Sergio ortega</Author>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<UnidadesEjecutorasDto>> ActualizarUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidadEjecutoraUpdate)
        {
            var unidadUpdate = this._mapper.Map<UnidadesEjecutoras>(unidadEjecutoraUpdate);

            var response = this._mapper.Map<UnidadesEjecutorasDto>(await this._carteraRepository.ActualizarUnidadEjecutoraSimulador(unidadUpdate));
            return new Response<UnidadesEjecutorasDto> { Data = response };
        }

        /// <summary>
        /// Elimina un registro de PAR_TASA_SIMULADOR_UNDEJ
        /// </summary>
        /// <param name="tasas"></param>
        /// /// <Author>Sergio ortega</Author>
        /// <Date>012/01/2022</Date>
        /// <returns></returns>
        public async Task<Response<UnidadesEjecutorasDto>> EliminarUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidades)
        {
            var unidadEjecutoraDelete = this._mapper.Map<UnidadesEjecutoras>(unidades);

            var response = this._mapper.Map<UnidadesEjecutorasDto>(await this._carteraRepository.EliminarUnidadEjecutoraSimulador(unidadEjecutoraDelete));

            return new Response<UnidadesEjecutorasDto> { Data = response };

        }

        /// <summary>
        /// Obtiene todos los parametros generales de credito y cartera
        /// </summary>
        /// <param name="obtenerParametrosGeneralesCreditoYCartera"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>29/12/2021</Date>

        public async Task<Response<ParamGeneralesCreditoYCarteraDto>> ObtenerParamGeneralesCreditoYCartera()

        {
            var response = this._mapper.Map<ParamGeneralesCreditoYCarteraDto>(await this._carteraRepository.ObtenerParamGeneralesCreditoYCartera());
            return new Response<ParamGeneralesCreditoYCarteraDto> { Data = response };
        }

        /// <summary>
        /// Actualiza parametros generales de credito y cartera
        /// </summary>
        /// <param name="unidadesEjecutoras"></param>
        ///  <Author>Sergio ortega</Author>
        /// <returns></returns>
        public async Task<Response<ParamGeneralesCreditoYCarteraDto>> ActualizarParamGeneralesCreditoYCartera(ParamGeneralesCreditoYCarteraDto paramCreditoYCarteraUpdate)
        {
            var paramGeneralesUpdate = this._mapper.Map<ParamGeneralesCreditoYCartera>(paramCreditoYCarteraUpdate);

            var response = this._mapper.Map<ParamGeneralesCreditoYCarteraDto>(await this._carteraRepository.ActualizarParamGeneralesCreditoYCartera(paramGeneralesUpdate));
            return new Response<ParamGeneralesCreditoYCarteraDto> { Data = response };
        }

        /// <summary>
        /// Cargar Archivo Aplicacion Pago Masivo
        /// </summary>
        /// <param name="unidadesEjecutoras"></param>
        ///  <Author>Sergio ortega</Author>
        /// <returns></returns>
        public async Task<Response<List<AplicacionPagoDto>>> CargarArchivoAplicacionPagoMasivo(IFormFile request, int ueJRequest)
        {
            var extensionArchivo = request.FileName.Split('.')[1];

            var stream = (new StreamReader(request.OpenReadStream()));
            List<Response<AplicacionPagoDto>> listaPagosAplicados = new List<Response<AplicacionPagoDto>>();
            var idUnidadEje = string.Empty;
            var listaUnidades = (await ConsultarUnidadEjecutora()).Data;
            UnidadesEjecutorasDto unidadEjecutora = listaUnidades.FirstOrDefault(x => x.idUnidadEjecutora == ueJRequest);
            var validacionViabilidad = new ResponseFromValidation();
            if (extensionArchivo.Equals("xlx") || extensionArchivo.Equals("xlsx"))
            {

                var FileJson = await HandlerFileToJson.ConvertXLXtoJson(stream);
                IEnumerable<PagoMasivoNominaDto> listaRegistros = JsonConvert.DeserializeObject<IEnumerable<PagoMasivoNominaDto>>(FileJson);
                idUnidadEje = listaRegistros.ToList()[0].NIT;
                unidadEjecutora = (await this.ConsultarUnidadEjecutora()).Data.Where(x => x.NitUnidadEjecutora.ToString() == idUnidadEje.ToString()).FirstOrDefault();
                List<KeyValuePair<string, string>> diccionarioPagos = new List<KeyValuePair<string, string>>();
                foreach (var registro in listaRegistros)
                {
                    diccionarioPagos.Add(new KeyValuePair<string, string>(registro.IDENTIFICACION, registro.VALOR));
                }

                validacionViabilidad = (await this.ValidarViabilidadPagoMasivo(diccionarioPagos)).Data;
                if (validacionViabilidad.ValidezLista != false)
                {
                    foreach (var item in diccionarioPagos)
                    {
                        listaPagosAplicados.Add(await this.AplicarPago(new PagoAplicarDto { Identificacion = item.Key, ValorPago = decimal.Parse(item.Value) }));
                    }
                }
                else
                {
                    var listaClientes = string.Empty;
                    foreach (var item in validacionViabilidad.ListaPagos)
                    {

                        listaClientes += listaClientes == string.Empty ? item.Key : $", {item.Key}";
                    }
                    throw new Exception($"No existen creditos en la base de datos para los { validacionViabilidad.ListaPagos.Count } clientes: " + listaClientes);
                }


            }
            else if (extensionArchivo.Equals("csv"))
            {
                var FileJson = await HandlerFileToJson.ConvertCSVtoJson(stream);
                IEnumerable<PagoMasivoNominaDto> listaRegistros = JsonConvert.DeserializeObject<IEnumerable<PagoMasivoNominaDto>>(FileJson);
                List<KeyValuePair<string, string>> diccionarioPagos = new List<KeyValuePair<string, string>>();


                idUnidadEje = listaRegistros.ToList()[0].FUERZA;
                unidadEjecutora = (await this.ConsultarUnidadEjecutora()).Data.Where(x => x.nombreUnidadEjecutora.ToUpper() == idUnidadEje.ToUpper()).FirstOrDefault();
                foreach (var registro in listaRegistros)
                {
                    diccionarioPagos.Add(new KeyValuePair<string, string>(registro.CEDULA, registro.VALOR));
                }

                validacionViabilidad = (await this.ValidarViabilidadPagoMasivo(diccionarioPagos)).Data;
                if (validacionViabilidad.ValidezLista != false)
                {
                    foreach (var item in diccionarioPagos)
                    {
                        //listaPagosAplicados.Add(await this.AplicarPago(new PagoAplicarDto { Identificacion = item.Key, ValorPago = decimal.Parse(item.Value) })); DESCOMENTAR
                        listaPagosAplicados.Add(new Response<AplicacionPagoDto> { Data = new AplicacionPagoDto { ValorPago = decimal.Parse(item.Value) } });
                    }
                }
                else
                {
                    var listaClientes = string.Empty;
                    foreach (var item in validacionViabilidad.ListaPagos)
                    {

                        listaClientes += listaClientes == string.Empty ? item.Key : $", {item.Key}";
                    }
                    throw new Exception($"No existen creditos en la base de datos para los { validacionViabilidad.ListaPagos.Count } clientes: " + listaClientes);
                }
            }
            else if (extensionArchivo.Equals("txt"))
            {
                var FileJson = await HandlerFileToJson.ConvertTxtToJson(stream);
                List<KeyValuePair<string, string>> listaPagos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(FileJson.Item1);

                var unidades = JsonConvert.DeserializeObject<List<string>>(FileJson.Item2);
                foreach (var unidad in unidades)
                {
                    unidadEjecutora = (await this.ConsultarUnidadEjecutora()).Data.Where(x => x.SiglaUnidadEjecutora.ToUpper() == unidad.ToUpper()).FirstOrDefault();
                    if (unidadEjecutora != null)
                    {
                        throw new ArgumentException(typeof(UnidadesEjecutorasDto).ToString());
                    }
                }



                validacionViabilidad = (await this.ValidarViabilidadPagoMasivo(listaPagos)).Data;
                if (validacionViabilidad.ValidezLista != false)
                {
                    foreach (var item in listaPagos)
                    {
                        listaPagosAplicados.Add(await this.AplicarPago(new PagoAplicarDto { Identificacion = item.Key, ValorPago = decimal.Parse(item.Value) }));
                    }
                }
                else
                {
                    var listaClientes = string.Empty;
                    foreach (var item in validacionViabilidad.ListaPagos)
                    {

                        listaClientes += listaClientes == string.Empty ? item.Key : $", {item.Key}";
                    }
                    throw new Exception($"No existen creditos en la base de datos para los { validacionViabilidad.ListaPagos.Count } clientes: " + listaClientes);
                }

            }
            else if (extensionArchivo.ToLower().Equals("pdf"))
            {
                var jsonFile = await HandlerFileToJson.ConvertPdfToJson(stream.BaseStream);

                var listaPagos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(jsonFile);

                validacionViabilidad = (await this.ValidarViabilidadPagoMasivo(listaPagos)).Data;
                if (validacionViabilidad.ValidezLista != false)
                {
                    foreach (var item in listaPagos)
                    {
                        listaPagosAplicados.Add(await this.AplicarPago(new PagoAplicarDto { Identificacion = item.Key, ValorPago = decimal.Parse(item.Value) }));
                    }
                }
                else
                {
                    var listaClientes = string.Empty;
                    foreach (var item in validacionViabilidad.ListaPagos)
                    {

                        listaClientes += listaClientes == string.Empty ? item.Key : $", {item.Key}";
                    }
                    throw new Exception($"No existen creditos en la base de datos para los { validacionViabilidad.ListaPagos.Count } clientes: " + listaClientes);
                }
            }
            var listaResult = new List<AplicacionPagoDto>();
            foreach (var registro in listaPagosAplicados)
            {
                listaResult.Add(registro.Data);
            }
            return new Response<List<AplicacionPagoDto>>() { Data = listaResult };
        }

        private async Task<Response<ResponseFromValidation>> ValidarViabilidadPagoMasivo(List<KeyValuePair<string, string>> diccionarioPagos)
        {
            ResponseFromValidation responseValidation = new ResponseFromValidation();
            var dictionaryTrue = new List<KeyValuePair<string, string>>();
            var dictionaryFalse = new List<KeyValuePair<string, string>>();
            var listPersonalData = new List<SimulacionDatosPersonalesDto>();
            var datosPersonales = new SimulacionDatosPersonalesDto();
            foreach (var item in diccionarioPagos)
            {
                var credit = (await this.ObtenerCreditoCarteraByIdentificacion(item.Key)).Data;

                datosPersonales = (await this._creditoBusinessLogic.ObtenerSimulacionPersonales(item.Key)).Data;
                if (credit != null && datosPersonales != null)
                {
                    dictionaryTrue.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    listPersonalData.Add(datosPersonales);
                }
                else
                {
                    dictionaryFalse.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                }

            }
            var finalDictionaryFalse = new List<KeyValuePair<string, string>>();
            foreach (var item in dictionaryFalse)
            {
                try
                {
                    var reintento = (await this.PrepararEjecucionDesembolso(new SolicitudProductoPorClienteDto { Identificacion = item.Key, TipoIdentificacion = 1 })).Data;
                    dictionaryTrue.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    listPersonalData.Add((await this._creditoBusinessLogic.ObtenerSimulacionPersonales(item.Key)).Data);
                }
                catch (Exception)
                {
                    finalDictionaryFalse.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                }
            }
            var dataIfFalse = new ResponseFromValidation()
            {
                ListaDatosPersonales = listPersonalData,
                ListaPagos = finalDictionaryFalse,
                ValidezLista = false,
                UnidadEjecutora = null
            };
            var dataIfTrue = new ResponseFromValidation()
            {
                ListaDatosPersonales = listPersonalData,
                ListaPagos = finalDictionaryFalse,
                ValidezLista = true,
                UnidadEjecutora = null
            };

            Response<ResponseFromValidation> response = finalDictionaryFalse.Count() > 0 ? new Response<ResponseFromValidation>() { Data = dataIfFalse } : new Response<ResponseFromValidation>() { Data = dataIfTrue };
            return response;
        }

        internal class ResponseFromValidation
        {
            public List<KeyValuePair<string, string>> ListaPagos { get; set; }
            public bool ValidezLista { get; set; }
            public List<SimulacionDatosPersonalesDto> ListaDatosPersonales { get; set; }
            public UnidadEjecutoraDto UnidadEjecutora { get; set; }
        }

        /// <summary>
        /// Obtiene todos los plazos generales de los creditos
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>08/02/2022</Date>

        public async Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerParametrosGeneralesPlazoCredito()

        {
            var response = this._mapper.Map<IEnumerable<ParamGeneralesExcepcionPlazoDto>>(await this._carteraRepository.ObtenerParametrosGeneralesPlazoCredito());
            return new Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>> { Data = response };
        }

        /// <summary>
        /// Crear expecion plazo
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> CrearExcepcionPlazo(ParamGeneralesExcepcionPlazoDto plazo)
        {
            var plazoCreate = this._mapper.Map<ParamGeneralesExcepcionPlazo>(plazo);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.CrearExcepcionPlazo(plazoCreate));
            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };
        }

        /// <summary>
        /// Obtiene todos los plazos generales de los creditos
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>08/02/2022</Date>

        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarParametrosGeneralesPlazoCredito(ParamGeneralesExcepcionPlazoDto plazos)
        {
            var plazoUpdate = this._mapper.Map<ParamGeneralesExcepcionPlazo>(plazos);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.ActualizarParametrosGeneralesPlazoCredito(plazoUpdate));
            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };
        }


        /// <summary>
        /// Elimina un registro de PARAM_PLAZOS
        /// </summary>
        /// <param name="tasas"></param>
        /// /// <Author>Sergio ortega</Author>
        /// <Date>11/02/2022</Date>
        /// <returns></returns>
        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> EliminarExcepcionPlazo(ParamGeneralesExcepcionPlazoDto plazos)
        {
            var plazoDelete = this._mapper.Map<ParamGeneralesExcepcionPlazo>(plazos);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.EliminarExcepcionPlazo(plazoDelete));

            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };

        }


        /// <summary>
        /// Actualiza una excepcion del plazo
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>08/02/2022</Date>

        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarExcepcionesPlazo(ParamGeneralesExcepcionPlazoDto excepcion)
        {
            var excepcionUpdate = this._mapper.Map<ParamGeneralesExcepcionPlazo>(excepcion);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.ActualizarExcepcionesPlazo(excepcionUpdate));
            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };
        }

        /// <summary>
        /// Obtiene todos las excepciones de los plazos
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>14/02/2022</Date>

        public async Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerExcepcionesPlazo(ParamGeneralesExcepcionPlazoDto getPlazo)

        {
            var obtenerPlazos = this._mapper.Map<ParamGeneralesExcepcionPlazo>(getPlazo);

            var response = this._mapper.Map<IEnumerable<ParamGeneralesExcepcionPlazoDto>>(await this._carteraRepository.ObtenerExcepcionesPlazo(obtenerPlazos));
            return new Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>> { Data = response };
        }

        /// <summary>
        /// Obtiene todos las excepciones de los plazos por unidad ejecutora
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>21/02/2022</Date>

        public async Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerExcepcionPlazoPorUnidadEjecutora(ParamGeneralesExcepcionPlazoDto getPlazo)

        {
            var obtenerPlazos = this._mapper.Map<ParamGeneralesExcepcionPlazo>(getPlazo);

            var response = this._mapper.Map<IEnumerable<ParamGeneralesExcepcionPlazoDto>>(await this._carteraRepository.ObtenerExcepcionPlazoPorUnidadEjecutora(obtenerPlazos));
            return new Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>> { Data = response };
        }

        /// <summary>
        /// Crear expecion plazo por unidad ejecutora
        /// </summary>
        /// <param name="tasas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> CrearExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazoDto plazo)
        {
            var plazoCreate = this._mapper.Map<ParamGeneralesExcepcionPlazo>(plazo);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.CrearExcepcionPlazoUnidadEjecutora(plazoCreate));
            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };
        }


        /// <summary>
        /// Actualiza una excepcion del plazo por unidad ejecutora
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>22/02/2022</Date>

        public async Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazoDto excepcion)
        {
            var excepcionUpdate = this._mapper.Map<ParamGeneralesExcepcionPlazo>(excepcion);

            var response = this._mapper.Map<ParamGeneralesExcepcionPlazoDto>(await this._carteraRepository.ActualizarExcepcionPlazoUnidadEjecutora(excepcionUpdate));
            return new Response<ParamGeneralesExcepcionPlazoDto> { Data = response };
        }

        /// <summary>
        /// Obtiene todos los plazos generales de los seguros
        /// </summary>
        /// <param name="obtenerTipoActores"></param>
        /// <returns></returns>
        /// <Author>Sergio ortega</Author>
        /// <Date>22/02/2022</Date>

        public async Task<Response<IEnumerable<ParamGeneralesSegurosDto>>> ObtenerSeguroGeneral()
        {
            var response = this._mapper.Map<IEnumerable<ParamGeneralesSegurosDto>>(await this._carteraRepository.ObtenerSeguroGeneral());
            return new Response<IEnumerable<ParamGeneralesSegurosDto>> { Data = response };
        }

        public async Task<Response<ParamGeneralesSegurosDto>> ActualizarSeguroGeneral(ParamGeneralesSegurosDto seguroUpdate)
        {
            var actualizarSeguro = this._mapper.Map<ParamGeneralesSeguros>(seguroUpdate);
            var response = this._mapper.Map<ParamGeneralesSegurosDto>(await this._carteraRepository.ActualizarSeguroGeneral(actualizarSeguro));

            return new Response<ParamGeneralesSegurosDto> { Data = response };
        }

        public async Task<Response<IEnumerable<ParamGeneralesSegurosDto>>> ObtenerExcepSeguroPorMunicipio()
        {
            var ciudades = (await _catalogosBusinessLogic.ObtenerCiudades()).Data;
            var departamentos = (await _catalogosBusinessLogic.ObtenerDepartamentos()).Data;
            var response = this._mapper.Map<IEnumerable<ParamGeneralesSegurosDto>>(await this._carteraRepository.ObtenerExcepSeguroPorMunicipio());
            foreach (var respuesta in response)
            {
                respuesta.CiudadNombre = ciudades.FirstOrDefault(c => c.IdDepartamento == respuesta.departamentoId && c.Id == respuesta.ciudadId).Nombre;
                respuesta.DepartamentoNombre = departamentos.FirstOrDefault(c => c.Id == respuesta.departamentoId).Nombre;
            }
            return new Response<IEnumerable<ParamGeneralesSegurosDto>> { Data = response };
        }

        public async Task<Response<ParamGeneralesSegurosDto>> CrearExcepcionPorMunicipio(ParamGeneralesSegurosDto seguroExcepcioCreate)

        {
            var crearExcepcionSeguroMunicipio = this._mapper.Map<ParamGeneralesSeguros>(seguroExcepcioCreate);
            var response = this._mapper.Map<ParamGeneralesSegurosDto>(await this._carteraRepository.CrearExcepcionPorMunicipio(crearExcepcionSeguroMunicipio));
            return new Response<ParamGeneralesSegurosDto> { Data = response };
        }

        public async Task<Response<ParamGeneralesSegurosDto>> ActualizarExcepSeguroPorMunicipio(ParamGeneralesSegurosDto seguroExcepcionUpdate)
        {
            var actualizarExcepcionSeguro = this._mapper.Map<ParamGeneralesSeguros>(seguroExcepcionUpdate);
            var response = this._mapper.Map<ParamGeneralesSegurosDto>(await this._carteraRepository.ActualizarExcepSeguroPorMunicipio(actualizarExcepcionSeguro));
            return new Response<ParamGeneralesSegurosDto> { Data = response };
        }

        public async Task<Response<ParamGeneralesSegurosDto>> EliminarExcepcionSeguroPorMunicipio(ParamGeneralesSegurosDto seguroExcepcionDelete)
        {
            var eliminarExcepcionSeguroMunicipio = this._mapper.Map<ParamGeneralesSeguros>(seguroExcepcionDelete);
            var response = this._mapper.Map<ParamGeneralesSegurosDto>(await this._carteraRepository.EliminarExcepcionSeguroPorMunicipio(eliminarExcepcionSeguroMunicipio));
            return new Response<ParamGeneralesSegurosDto> { Data = response };
        }

        /// <summary>
        /// Carga archivo masivo leasing en tabla cre credito
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult> CargaMasivaLeasing(IFormFile request)
        {
            var TiposVivienda = (await _catalogosBusinessLogic.ObtenerTipoVivienda()).Data;
            var EstadosVivienda = (await _catalogosBusinessLogic.ObtenerTiposDeVivienda()).Data;
            var parametrosGenerales = (await this.ObtenerParamGeneralesCreditoYCartera()).Data;

            var extensionArchivo = request.FileName.Split('.')[1];

            var stream = new StreamReader(request.OpenReadStream());
            if (extensionArchivo.Equals("xlx") || extensionArchivo.Equals("xlsx"))
            {
                var FileJson = (await HandlerFileToJson.ConvertXLXtoJson(stream)).Replace("\r", "").Replace("\n", "").Replace(@"\/", "/");
                var jsonUnescaped = Regex.Replace(FileJson, " \"", "\"");
                var listaLeasigs = JsonConvert.DeserializeObject<IEnumerable<CargueMasivoLeasingDto>>(jsonUnescaped);
                foreach (var leasing in listaLeasigs)
                {
                    try
                    {
                        int estadoVivienda = 0;
                        if (leasing.Estado_vivienda != null)
                        {
                            estadoVivienda = leasing.Estado_vivienda.ToUpper().Equals("NUEVA") ? 3 : 4;
                        }
                        else
                        {
                            estadoVivienda = 4;
                        }

                        bool vis = (double.Parse(leasing.Valor_Comercial_inmueble) / double.Parse(parametrosGenerales.parametroSalarioMinimo.ToString())) >
                                        double.Parse(parametrosGenerales.limiteSalariosVis.ToString()) ? false : true;

                        //Prueba de variables
                        // Dejar todos en var

                        //var fechafinpagos = DateTime.Parse(leasing.Fecha_Finaliza_Pagos);
                        //var fechaUltimoPago = DateTime.Parse(leasing.Fecha_Finaliza_Pagos);
                        //var categoria = leasing.Categoria;

                        //Tasa efectiva anual calculada
                        var tea = (decimal.Parse(leasing.tasa_Credito) / 100) * 12;
                        var tem = (decimal.Parse(leasing.tasa_Credito) / 100);
                        var producto = new ProductoCliente()
                        {
                            CRE_CANON_EXTRAORDINARIO = decimal.Parse(leasing.Canon_Extraordinario),
                            CATEGORIA = leasing.Categoria,
                            CIUDAD_INMUEBLE = leasing.Ciudad_Inmueble,
                            CLI_EDAD = int.Parse(leasing.Edad),
                            CLI_IDENTIFICACION = leasing.Identificacion,
                            CRE_ACUMULADO_INTERES_CORRIENTE = decimal.Parse(leasing.Valor_Causación_Acumulada_Interes_Corriente),
                            CRE_ACUMULADO_INTERES_MORA = decimal.Parse(leasing.Valor_Causación_Acumulada_Interes_Remanente),
                            CRE_ACUMULADO_SEGURO_HOGAR = decimal.Parse(leasing.Valor_Causación_Seguro_Hogar),
                            CRE_ACUMULADO_SEGURO_VIDA = decimal.Parse(leasing.Valor_Causación_Seguro_Vida),
                            CRE_ALIVIO_FRECH = 0,
                            CRE_CREADO_POR = default(Guid),
                            CRE_DIAS_MORA = 0,
                            CRE_DIA_PAGO = DateTime.ParseExact(leasing.Fecha_proximo_Pago, "dd/MM/yyyy", null).Day,
                            CRE_DIRECCION_INMUEBLE = leasing.Dirección_Inmueble,
                            CRE_FECHA_CREACION = DateTime.Now,
                            CRE_FECHA_DESEMBOLSO = DateTime.ParseExact(leasing.Fecha_Desembolso, "dd/MM/yyyy", null),
                            CRE_FECHA_ESTADO = DateTime.Now,
                            CRE_FECHA_FINALIZA_PAGOS = DateTime.ParseExact(leasing.Fecha_Finaliza_Pagos, "dd/MM/yyyy", null),
                            CRE_FECHA_MODIFICACION = DateTime.Now,
                            CRE_FECHA_PROXIMO_PAGO = DateTime.ParseExact(leasing.Fecha_proximo_Pago, "dd/MM/yyyy", null),
                            CRE_FECHA_ULTIMO_PAGO = DateTime.ParseExact(leasing.Fecha_ultimo_Pago, "dd/MM/yyyy", null),
                            CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE = DateTime.ParseExact(leasing.Fecha_ultimo_Pago, "dd/MM/yyyy", null),
                            CRE_FECHA_ULTIMO_PAGO_INTERES_MORA = DateTime.ParseExact(leasing.Fecha_ultimo_Pago, "dd/MM/yyyy", null),
                            CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR = DateTime.ParseExact(leasing.Fecha_ultimo_Pago, "dd/MM/yyyy", null),
                            CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA = DateTime.ParseExact(leasing.Fecha_ultimo_Pago, "dd/MM/yyyy", null),
                            CRE_ID = Guid.NewGuid(),
                            CRE_MODIFICADO_POR = default(Guid),
                            CRE_NRO_CREDITO = leasing.Nro_Credito,
                            CRE_NUMERO_CUOTAS_CANCELADAS = int.Parse(leasing.Plazo) - int.Parse(leasing.Cuotas_Pendientes),
                            CRE_PLAZO_ACTUAL = int.Parse(leasing.Cuotas_Pendientes),
                            CRE_PLAZO_TOTAL = int.Parse(leasing.Plazo),
                            CRE_POR_CANON_INICIAL = decimal.Parse(leasing.Canon_inicial),
                            CRE_POR_OPCION_COMPRA = decimal.Parse(leasing.Valor_Opcion_Compra),
                            CRE_SALDO_CAPITAL = decimal.Parse(leasing.Saldo_Capital),
                            CRE_SALDO_CAPITAL_MORA = 0,//Preguntar -> queda en 0 
                            CRE_TASA_CREDITO_EA = tea,
                            CRE_TASA_CREDITO_PER = tem,//calcular
                            CRE_TASA_FRECH = 0, // calcular -> queda 0
                            CRE_TASA_SEGURO_HOGAR = decimal.Parse(leasing.Porc_Seguro_Hogar),
                            CRE_TASA_SEGURO_VIDA = decimal.Parse(leasing.Porc_Seguro_Vida),
                            CRE_TIPO_ABONO_EXTRA = "1", // preguntar, no puede ser nulo, en un principio todos estaran en 0
                            CRE_VALOR_ABONO_EXTRA = 0, // preguntar, queda en 0 
                            CRE_VALOR_ALIVIO_CUOTA = 0, //preguntar, tambien queda en 0
                            CRE_VALOR_CANON_INICIAL = decimal.Parse(leasing.Canon_inicial), //->desde aca
                            CRE_VALOR_CUOTA = decimal.Parse(leasing.Vlor_Cuota),
                            CRE_VALOR_DESEMBOLSO = decimal.Parse(leasing.Monto_Aprobado),
                            CRE_VALOR_DEUDA_REMANENTE = 0, // preguntar, dejar en 0
                            CRE_VALOR_OPCION_COMPRA = decimal.Parse(leasing.Valor_Opcion_Compra),
                            CRE_VALOR_VIVIENDA = decimal.Parse(leasing.Valor_Comercial_inmueble),
                            DESCRIPCION_INMUEBLE = leasing.Descripción_Inmueble,
                            ESCRITURA_INMUEBLE = leasing.Escritura_Inmueble,
                            ESC_ID = 1,
                            FECHA_ESCRITURA = DateTime.ParseExact(leasing.Fecha_Escritura, "dd/MM/yyyy", null),
                            FECHA_SOLICITUD = DateTime.ParseExact(leasing.Fecha_Solicitud, "dd/MM/yyyy", null),
                            GRADO = leasing.Grado,
                            NOTARIA = leasing.Notaria,
                            NUMERO_MATRICULA = leasing.Matricula_Inmueble,
                            SIJ_LINDEROS = leasing.Linderos_inmueble,
                            SOC_SCORE = int.Parse(leasing.ScoreTranunion),
                            TCR_ID = 1,
                            TIPO_IDENTIFICACION = 1,
                            TVV_ID = estadoVivienda, //preguntar,
                            TIV_ID = vis ? 1 : 2,//preguntar
                            CLASE_INMUEBLE = leasing.Clase_Inmueble,
                            CRE_FECHA_CAUSACION = DateTime.ParseExact(leasing.Fecha_Desembolso, "dd/MM/yyyy", null)

                        };

                        await _carteraRepository.EjecutarDesembolso(producto);
                    }
                    catch (Exception ex)
                    {
                        var log = ex;
                    }



                }



            }

            return new OkObjectResult("Ok");
        }

        /// <summary>
        /// Obtiene los datos de liquidacion general
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<DatosLiquidacionDto>> ObtenerLiquidacionGeneral()
        {
            var response = this._mapper.Map<DatosLiquidacionDto>(await this._carteraRepository.ObtenerLiquidacionGeneral());
            return new Response<DatosLiquidacionDto> { Data = response };
        }

        /// <summary>
        /// Actualizar Liquidacion General
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<DatosLiquidacionDto>> ActualizarLiquidacionGeneral(DatosLiquidacionDto request)
        {
            var peticion = this._mapper.Map<DatosLiquidacion>(request);
            var response = this._mapper.Map<DatosLiquidacionDto>(await this._carteraRepository.ActualizarLiquidacionGeneral(peticion));
            return new Response<DatosLiquidacionDto> { Data = response };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<IEnumerable<AplicacionPagoDto>>> ObtenerAplicacionPago(Guid request)
        {
            var response = this._mapper.Map<IEnumerable<AplicacionPagoDto>>(await this._carteraRepository.ObtenerAplicacionPago(request));
            return new Response<IEnumerable<AplicacionPagoDto>> { Data = response };
        }
    }
}

