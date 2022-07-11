using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class ProspeccionBusinessLogic : IProspeccionBusinessLogic
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        private readonly ICreditoRepository _creditoRepository;
        private readonly IOptions<AqmOptions> _optionsAqm;
        private readonly IOptions<ApisOptions> _optionsApis;
        private readonly ITokenClaims _tokenClaims;
        private readonly IClientRequestProvider _requestProvider;
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;
        private readonly IFenixBusinessLogic _fenixBusinessLogic;
        private readonly IVigiaBusinessLogic _vigiaBusinessLogic;
        private readonly IGestorIdVisionBusinessLogic _gestorIdVision;
        private readonly IClientRequestProvider _clientRequestProvider;
        private readonly IMapper _mapper;


        public ProspeccionBusinessLogic(ICreditoBusinessLogic creditoBusinessLogic, ICreditoRepository creditoRepository, IOptions<AqmOptions> optionsAqm, IOptions<ApisOptions> optionsApis, ITokenClaims tokenClaims, IClientRequestProvider requestProvider, ICatalogosBusinessLogic catalogsBusinessLogic, ICarteraBusinessLogic carteraBusinessLogic, IFenixBusinessLogic fenixBusinessLogic, IVigiaBusinessLogic vigiaBusinessLogic, IGestorIdVisionBusinessLogic gestorIdVision, IClientRequestProvider clientRequestProvider, IMapper mapper)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _creditoRepository = creditoRepository;
            _optionsAqm = optionsAqm;
            _optionsApis = optionsApis;
            _tokenClaims = tokenClaims;
            _requestProvider = requestProvider;
            _catalogsBusinessLogic = catalogsBusinessLogic;
            _carteraBusinessLogic = carteraBusinessLogic;
            _fenixBusinessLogic = fenixBusinessLogic;
            _vigiaBusinessLogic = vigiaBusinessLogic;
            _gestorIdVision = gestorIdVision;
            _clientRequestProvider = clientRequestProvider;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<SimulacionDto>>> CrearSimulacionCliente(CreacionSimulacionClienteDto request)
        {
            var datosPersonales = (await _creditoBusinessLogic.ObtenerSimulacionPersonales(request.documento)).Data;
            var idSimulacion = datosPersonales.IdSimulacion;
            if (request.simId == 1)
                return await this.CrearSimulacionCreditoViviendaTradicional(request, datosPersonales, idSimulacion);
            else if (request.simId == 2)
                return await this.CrearSimulacionCreditoLeasingTradicional(request, datosPersonales, idSimulacion);
            else
                return await this.CrearSimulacionCreditoConsumo(request, datosPersonales, idSimulacion);
        }

        private async Task<Response<IEnumerable<SimulacionDto>>> CrearSimulacionCreditoConsumo(CreacionSimulacionClienteDto request, SimulacionDatosPersonalesDto datosPersonales, Guid idSimulacion)
        {
            List<SimulacionDto> planillaSimulacion = new();
            var equivalenciasSimuladoCredito = (await _creditoBusinessLogic.ObtenerEquivalenciasSimuladorCredito()).Data;
            var recursos = (await _clientRequestProvider.ObtenerClientePorTipoIdentificationYNumero(request.tipoIdentificacion, request.documento)).Data;
            var cliente = (await this.ObtenerClienteProspeccion(new DataClienteProspeccionDto { TipoIdentificacion = request.tipoIdentificacion, NumeroDocumento = request.documento })).Data;
            var datosFinancieros = (await this._creditoBusinessLogic.ObtenerDatosFinancierosPersonales(request.documento)).Data;
            var tasaSeguroVida = (double)(await _carteraBusinessLogic.ObtenerSeguroGeneral()).Data.First().seguroVida / 100;
            var tasaSimulador = (await _carteraBusinessLogic.ObtenerTasasSimulador()).Data.First(t => t.IdSimulacion == request.simId.ToString());
            var tasaCredito = tasaSimulador.TasaEA / 100;
            var plazoMaximo = tasaSimulador.MaximoPlazoMeses;
            var plazo = 0;
            var salarioMinimo = 1000000;
            var montoMaxSMLV = 300;
            var montoMaximo = salarioMinimo * montoMaxSMLV;
            var ingresoTotal = datosFinancieros.TotalIngresos;
            var totalDescuentos = datosFinancieros.TotalEgresos;
            var capacidadPago = (ingresoTotal * (decimal)0.5) - totalDescuentos;
            double primero = (double)(1 + tasaCredito);
            double segundo = 0.0833333333333333;
            var tasaMesVencido = Math.Pow(primero, segundo) - 1;
            //Calcula tasa mixta(segurovida + tasa mes vencido)
            var tasaMixta = tasaSeguroVida + tasaMesVencido;
            var factor = 0M;
            var prestamoMaximo = 0M;
            var cuotaConSeguro = 0M;
            var cuotaSinSeguro = 0M;
            if (request.valor > 0 && request.valorCuota <= 0 && request.plazo <= 0)
            {
                //Si calcula sobre el valor prestamos
                if (request.plazo <= 0 || request.plazo > plazoMaximo)
                    plazo = tasaSimulador.MaximoPlazoMeses;
                else
                    plazo = request.plazo;
                factor = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1));
                prestamoMaximo = capacidadPago / factor;
                if ((decimal)request.valor > prestamoMaximo)
                    request.valor = (double?)prestamoMaximo;
                cuotaConSeguro = (decimal)request.valor * factor;
                cuotaSinSeguro = cuotaConSeguro - ((decimal)request.valor * (decimal)tasaSeguroVida);
            }
            else if (request.valorCuota > 0 && request.valor <= 0 && request.plazo <= 0)
            {
                //Si calcula sobre el valor de la cuota
                plazo = plazoMaximo;
                factor = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1));
                prestamoMaximo = capacidadPago / factor;
                cuotaConSeguro = (decimal)request.valor * factor;
                request.valor = (double)prestamoMaximo;
                cuotaSinSeguro = cuotaConSeguro - ((decimal)request.valor * (decimal)tasaSeguroVida);
            }
            else if (request.plazo > 0 && request.valorCuota <= 0 && request.valor <= 0)
            {
                //Si calcula sobre el plazo
                if (request.plazo > plazoMaximo)
                    plazo = plazoMaximo;
                factor = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1));
                prestamoMaximo = capacidadPago / factor;
                cuotaConSeguro = (decimal)request.valor * factor;
                request.valor = (double)prestamoMaximo;
                cuotaSinSeguro = cuotaConSeguro - ((decimal)request.valor * (decimal)tasaSeguroVida);
            }
            else if (request.plazo > 0 && request.valorCuota <= 0 && request.valor > 0)
            {
                //Si calcula sobre el plazo y el valor del prestamo
                if (request.plazo > plazoMaximo)
                    plazo = plazoMaximo;
                factor = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1));
                prestamoMaximo = capacidadPago / factor;
                if ((decimal)request.valor > prestamoMaximo)
                    request.valor = (double?)prestamoMaximo;
                cuotaConSeguro = (decimal)request.valor * factor;
                cuotaSinSeguro = cuotaConSeguro - ((decimal)request.valor * (decimal)tasaSeguroVida);
            }
            else if (request.plazo > 0 && request.valorCuota > 0 && request.valor <= 0)
            {
                //Si calcula sobre el valor de la cuota y el plazo
                if (request.plazo > plazoMaximo)
                    plazo = plazoMaximo;
                factor = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1));
                prestamoMaximo = capacidadPago / factor;
                cuotaConSeguro = (decimal)request.valor * factor;
                request.valor = (double)prestamoMaximo;
                cuotaSinSeguro = cuotaConSeguro - ((decimal)request.valor * (decimal)tasaSeguroVida);
            }

            var solicitudSimulacion = await _creditoBusinessLogic.CrearSolicitudSimulacionCredito(new SolicitudSimulacionDto
            {
                Id = idSimulacion,
                EnvioNotificacion = false,
                Estado = "I",
                FechaActualiza = DateTime.Now,
                FechaSolicitud = DateTime.Now,
                NumeroPreAprobado = 0,
                ProblemaEmail = false,
                UsuarioActualiza = Guid.NewGuid(),
                TcrId = equivalenciasSimuladoCredito.First(e => e.TipoSimulador == request.simId).TipoCredito
            });
            var simulacionCliente = await _creditoBusinessLogic.CrearSimulacionClienteSMC(new SMCSimulacionClienteDto()
            {
                Documento = request.documento,
                TotalCuotas = plazo,
                FechaSimulacion = DateTime.Now,
                IdDatosPersonales = datosPersonales.Id,
                IdSimulacion = idSimulacion,
                IdSimulacionCliente = Guid.NewGuid(),
                NumeroPreaprobado = 0,
                TasaEa = tasaCredito,
                TasaFrech = 0,
                TasaMv = tasaMesVencido,
                TipoAbono = "N",
                TipoAlivio = "N",
                TomaSeguro = "N",
                ValorPrestamo = (decimal)request.valor,
                TipoVivienda="",
                ViviendaVis="",
                UsaRecursosAcumulados=""
                
            });


            for (int i = 0; i <= plazo; i++)
            {
                if (i == 0)
                {
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        IdSimulacion = idSimulacion,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        Cuota = i,
                        ValorPrestamo = (decimal)request.valor,
                        TotalCuota = (double)cuotaConSeguro,
                        TotalCuotaSinSeguros = (double?)cuotaSinSeguro,
                        PlazoMeses = plazo,
                        PlazoAnos = plazo / 12,
                        ValorTasa = tasaCredito,
                        ValorTasaNominal = tasaMesVencido,
                        Saldo = (double)request.valor,
                        FechaPago=DateTime.Now,
                        FechaCorte=DateTime.Now
                    });

                }
                else
                {
                    decimal interesCuota = (decimal)(planillaSimulacion[i - 1].Saldo * tasaMesVencido);
                    decimal seguroVidaCuota = (decimal)(tasaSeguroVida * planillaSimulacion[i - 1].Saldo);
                    var capital = (cuotaConSeguro - seguroVidaCuota - interesCuota);
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        IdSimulacion = idSimulacion,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        Cuota = i,
                        TotalCuota = (double)cuotaConSeguro,
                        SeguroVida = (double)seguroVidaCuota,
                        Intereses = (double)interesCuota,
                        Capital = (double)capital,
                        FechaCorte=DateTime.Now,
                        FechaPago=DateTime.Now,
                        Saldo= planillaSimulacion[i - 1].Saldo-(double)capital
                    });                }
            }
            foreach (var detalle in planillaSimulacion)
            {
                try
                {
                    var insercion = new Thread(async x => await _creditoBusinessLogic.CrearDetalleSimulacion(detalle));
                    insercion.Start();
                }
                catch (Exception ex)
                {
                    return new Response<IEnumerable<SimulacionDto>> { ReturnMessage = ex.ToString() };
                }
            }
            return new Response<IEnumerable<SimulacionDto>> { Data = planillaSimulacion };
        }

        private async Task<Response<IEnumerable<SimulacionDto>>> CrearSimulacionCreditoLeasingTradicional(CreacionSimulacionClienteDto request, SimulacionDatosPersonalesDto datosPersonales, Guid simulacionId)
        {
            List<SimulacionDto> planillaSimulacion = new();
            var equivalenciasSimuladoCredito = (await _creditoBusinessLogic.ObtenerEquivalenciasSimuladorCredito()).Data;
            var recursos = (await _clientRequestProvider.ObtenerClientePorTipoIdentificationYNumero(request.tipoIdentificacion, request.documento)).Data;
            var cliente = (await this.ObtenerClienteProspeccion(new DataClienteProspeccionDto { TipoIdentificacion = request.tipoIdentificacion, NumeroDocumento = request.documento })).Data;
            var datosFinancieros = (await this._creditoBusinessLogic.ObtenerDatosFinancierosPersonales(request.documento)).Data;
            var tiposVivienda = (await _catalogsBusinessLogic.ObtenerTiposDeVivienda()).Data;
            var tasaSeguroVida = (double)(await _carteraBusinessLogic.ObtenerSeguroGeneral()).Data.First().seguroVida / 100;
            var tasaSeguroHogar = ((await _creditoBusinessLogic.ObtenerTasasHogarCiudad()).Data).First(t => t.DpcId == datosPersonales.DpcIdInmueble).ValorTasa / 100;
            var tasaSimulador = (await _carteraBusinessLogic.ObtenerTasasSimulador()).Data.First(t => t.IdSimulacion == request.simId.ToString());
            var tasaCredito = tasaSimulador.TasaEA / 100;
            var valorSeguro = (double)request.valor * (double)tasaSeguroHogar;
            var viviendaVis = "PENDIENTE";//verificar tipo de vivienda vis no vis
            var vivienda = 2;

            //obtengo la tasa mes vencido
            double primero = (double)(1 + tasaCredito);
            double segundo = ((double)0.0833333333333333);
            var tasaMesVencido = Math.Pow(primero, segundo) - 1;

            //Calcula tasa mixta(segurovida + tasa mes vencido)
            var tasaMixta = tasaSeguroVida + tasaMesVencido;


            if (datosPersonales.Cuotas >= 108)
                tasaSimulador.MaximoPlazoMeses = 72;
            else if (datosPersonales.Cuotas >= 25)
                tasaSimulador.MaximoPlazoMeses = 168 - datosPersonales.Cuotas;
            else
            {
                viviendaVis = "NO VIABLE POR CUOTAS";
                //return new Response<IEnumerable<SimulacionDto>> { ReturnMessage = "El usuario tiene menos de 25 cuotas aportadas" };
            }
            //Asigno plazo maximo seguntabla
            var plazo = 0;
            if (request.plazo == null || request.plazo == 0)
                plazo = tasaSimulador.MaximoPlazoMeses;
            else
                plazo = request.plazo;
            var plazoMax = plazo;//igualar a plazo;
            //Calculo Factor 1y2
            var factor1 = (decimal)(tasaMixta * Math.Pow((1 + tasaMixta), plazoMax) / (Math.Pow(1 + tasaMixta, plazoMax) - 1));
            var factor2 = (decimal)(tasaMesVencido * Math.Pow((1 + tasaMesVencido), plazoMax) / (Math.Pow(1 + tasaMesVencido, plazoMax) - 1));

            //obtengo total ingresos y obtengo total egresos
            var totalIngesos = (double)datosFinancieros.TotalIngresos;
            var totalDescuentos = (double)datosFinancieros.TotalEgresos;

            //calculo cuota max totalIngresos*0.5-totalEgresos
            var capacidadPago = (totalIngesos * 0.5) - totalDescuentos;
            var porcentajeCanonInicial = request.CanonInicial/100;
            var porcentajeOpcionCompra = request.porOpcionCompra / 100;
            decimal factorIncremento = 0.04M;
            decimal factorAhorro = 0.08M;
            decimal factorInflacion = 0.03M;
            decimal factorCesantias = 0.1342M;
            var subsidiovivienda = recursos.Saldos.First(s => s.Concepto.Equals("Ahorro")).Valor;
            decimal ahorroProgramado = 0;
            decimal salarioAuxiliar = 0;
            decimal ahorros = 0;
            decimal ahorrosAnt = 0;
            decimal intAhorros = 0;
            decimal cesantias = 0;
            decimal intCesantias = 0;
            decimal cesantiasAnt = 0;
            decimal intCesantiasAnt = 0;
            for (int x = 1; x <= (int)(plazoMax / 12); x++)
            {
                if (x == 1)
                {
                    salarioAuxiliar = datosFinancieros.ValorSalario * (decimal)(Math.Pow((double)(1 + factorIncremento), x));
                    ahorros = salarioAuxiliar * factorAhorro * 12;
                    intAhorros = subsidiovivienda * factorInflacion;
                    cesantias += 12 * salarioAuxiliar * factorCesantias;
                    cesantiasAnt = 12 * salarioAuxiliar * factorCesantias;
                }
                else
                {
                    salarioAuxiliar = datosFinancieros.ValorSalario * (decimal)(Math.Pow((double)(1 + factorIncremento), x));
                    ahorros = salarioAuxiliar * factorAhorro * 12;
                    intAhorros = ahorrosAnt * factorInflacion;
                    cesantias += factorCesantias * 12 * salarioAuxiliar;
                    intCesantias = (factorInflacion) * (cesantiasAnt + intCesantias) + intCesantias;
                    cesantias += intCesantias;
                    intCesantiasAnt = (factorInflacion) * (cesantiasAnt + intCesantiasAnt);
                    cesantiasAnt = 12 * salarioAuxiliar * factorCesantias;
                }
                ahorrosAnt = ahorros;
                ahorroProgramado += ahorros + intAhorros;
            }
            var recursosCuentaIndividual = recursos.Saldos.First(s => s.Concepto.Equals("Ahorro")).Valor;
            var alertaValorVivienda = 0.15M;
            var maximoUsar = recursosCuentaIndividual * alertaValorVivienda;
            var totalOpcionCompra = subsidiovivienda + ahorroProgramado + cesantias;
            var cuotaEquivalenteVF = (totalOpcionCompra * factor2) / (decimal)(Math.Pow(1 + tasaMesVencido, plazoMax));
            var valorPrestamo = ((decimal)(capacidadPago) + cuotaEquivalenteVF) / (factor1 + (decimal)((decimal)tasaSeguroHogar / (1 - porcentajeCanonInicial)));
            var valorViviendaMaximo = valorPrestamo / (decimal)(1 - (porcentajeCanonInicial)-(porcentajeOpcionCompra));
            var canonInicial = valorViviendaMaximo * (decimal)(porcentajeCanonInicial);
            var recursosCanon = (decimal)(maximoUsar) < canonInicial ? (decimal)maximoUsar : canonInicial;
            var valorCredito = valorViviendaMaximo - canonInicial;
            var valorCuotaSinOpcionCompra = (valorPrestamo * factor1) + (valorViviendaMaximo * (decimal)tasaSeguroHogar);
            var canonReducido = ((decimal)valorCuotaSinOpcionCompra - (decimal)cuotaEquivalenteVF)>(decimal)capacidadPago? (decimal)valorCuotaSinOpcionCompra - (decimal)cuotaEquivalenteVF: (decimal)capacidadPago;
            var seguroVidaPromedio = (decimal)tasaSeguroVida * valorCredito;
            var valorSeguroHogar = (decimal)tasaSeguroHogar * valorViviendaMaximo;
            decimal valorViviendaDeseado = (decimal)request.valor;
            var recursosPropios = valorViviendaDeseado - valorViviendaMaximo + canonInicial;

            var capitalReducido = (canonReducido - seguroVidaPromedio - valorSeguroHogar) / factor2;
            var opcionCompra = valorViviendaMaximo * (request.porOpcionCompra/100);
            var valorDescOpcionCompra = (opcionCompra * factor1) / (decimal)Math.Pow(1 + tasaMixta, plazoMax);
            var canonTradicional = valorCuotaSinOpcionCompra - valorDescOpcionCompra;

            var solicitudSimulacion = await _creditoBusinessLogic.CrearSolicitudSimulacionCredito(new SolicitudSimulacionDto
            {
                Id = simulacionId,
                EnvioNotificacion = false,
                Estado = "I",
                FechaActualiza = DateTime.Now,
                FechaSolicitud = DateTime.Now,
                NumeroPreAprobado = 0,
                ProblemaEmail = false,
                UsuarioActualiza = Guid.NewGuid(),
                TcrId = equivalenciasSimuladoCredito.First(e => e.TipoSimulador == request.simId).TipoCredito
            });
            var simulacionCliente = await _creditoBusinessLogic.CrearSimulacionClienteSMC(new SMCSimulacionClienteDto()
            {
                Documento = request.documento,
                OpcionCompra = (double)opcionCompra,
                TotalCuotas = plazoMax,
                FechaSimulacion = DateTime.Now,
                IdDatosPersonales = datosPersonales.Id,
                IdSimulacion = simulacionId,
                IdSimulacionCliente = Guid.NewGuid(),
                NumeroPreaprobado = 0,
                TasaEa = tasaCredito,
                TasaFrech = 0,
                TasaMv = tasaMesVencido,
                TipoAbono = "N",
                TipoAlivio = "N",
                TipoVivienda = request.ViviendaNueva ? "N" : "U",
                TomaSeguro = "N",
                UsaRecursosAcumulados = recursosPropios>0?"S":"N",
                ValorPrestamo = 0,
                ValorPrestamosLeasing = (double)valorPrestamo,
                ValorVivienda = (double?)valorViviendaMaximo,
                ViviendaVis = viviendaVis
            });
            for (int i = 0; i <= plazoMax; i++)
            {
                if (i == 0)
                {
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        SaldoCapitalReducido = capitalReducido,
                        CapitalReducido=canonInicial,
                        TcrId = 1,
                        IdSimulacion = simulacionId,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        SaldoLeasing = valorPrestamo,
                        Cuota = i,
                        ViviendaVis = viviendaVis,
                        ValorVivienda = (double?)valorViviendaMaximo,
                        ValorPrestamo = valorPrestamo,
                        TotalCuota = (double)canonTradicional,
                        TotalCuotaSinSeguros = (double?)(canonTradicional - valorSeguroHogar-seguroVidaPromedio),
                        PlazoMeses = plazoMax,
                        PlazoAnos = plazoMax / 12,
                        ValorTasa = tasaCredito,
                        ValorTasaNominal = tasaMesVencido,
                        ValorDeudaRemanente=capitalReducido,
                        //añadir fecha corte y fecha pago
                        //Quemadas temporalmente
                        FechaCorte = DateTime.Now,
                        FechaPago = DateTime.Now
                    });

                }
                else
                {
                    decimal interesLeasing = (decimal)(planillaSimulacion[i - 1].SaldoLeasing * (decimal)tasaMesVencido);
                    decimal seguroVidaCuota = (decimal)((decimal)tasaSeguroVida * planillaSimulacion[i - 1].SaldoLeasing);
                    var capital = (canonTradicional - (valorSeguroHogar + seguroVidaCuota + interesLeasing));
                    var interesAPagar = planillaSimulacion[i - 1].SaldoCapitalReducido * (decimal)tasaMesVencido;
                    var interesesPorPagar = interesLeasing - interesAPagar;
                    var capitalAPagar= canonTradicional - interesAPagar - valorSeguroHogar - seguroVidaCuota;
                    var capitalPorPagar = capital - capitalAPagar;
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        IdSimulacion = simulacionId,
                        CuotaUnidadPagadora=canonReducido,
                        InteresesPorPagar= interesesPorPagar,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        CapitalPorPagar= capitalPorPagar>0?capitalPorPagar:0,
                        SaldoCapitalReducido= planillaSimulacion[i - 1].SaldoCapitalReducido-capitalAPagar,
                        CapitalReducido =capitalAPagar,
                        Cuota = i,
                        //añadir fecha corte y fecha pago
                        //Quemadas temporalmente
                        FechaCorte = DateTime.Now,
                        FechaPago = DateTime.Now,
                        SeguroHogar = (double)valorSeguroHogar,
                        InteresLeasing= (decimal)interesLeasing,
                        CapitalLeasing= capital,
                        CuotaLeasing= canonTradicional,
                        SaldoLeasing= planillaSimulacion[i - 1].SaldoLeasing - capital,
                        SeguroVidaLeasing= seguroVidaCuota,
                        TotalCuota= (double)canonTradicional
                    });
                }
            }
            foreach (var detalle in planillaSimulacion)
            {
                try
                {
                    var insercion = new Thread(async x => await _creditoBusinessLogic.CrearDetalleSimulacion(detalle));
                    insercion.Start();
                }
                catch (Exception ex)
                {
                    var exc = ex;
                }
            }
            for(var x=0; x<planillaSimulacion.Count(); x++)
            {
                planillaSimulacion[x].SaldoLeasing = planillaSimulacion[x].SaldoLeasing > 0 ? planillaSimulacion[x].SaldoLeasing : 0;
            }
            return new Response<IEnumerable<SimulacionDto>> { Data = planillaSimulacion };
        }

        private async Task<Response<IEnumerable<SimulacionDto>>> CrearSimulacionCreditoViviendaTradicional(CreacionSimulacionClienteDto request, SimulacionDatosPersonalesDto datosPersonales, Guid simulacionId)
        {
            List<SimulacionDto> planillaSimulacion = new();
            var equivalenciasSimuladoCredito = (await _creditoBusinessLogic.ObtenerEquivalenciasSimuladorCredito()).Data;
            //var cliente = (await this.ObtenerClienteProspeccion(new DataClienteProspeccionDto { TipoIdentificacion = request.tipoIdentificacion, NumeroDocumento = request.documento })).Data;
            var datosFinancieros = (await this._creditoBusinessLogic.ObtenerDatosFinancierosPersonales(request.documento)).Data;
            var tiposVivienda = (await _catalogsBusinessLogic.ObtenerTiposDeVivienda()).Data;
            var seguroVida = (double)(await _carteraBusinessLogic.ObtenerSeguroGeneral()).Data.First().seguroVida / 100;
            var tasaSeguroHogar = ((await _creditoBusinessLogic.ObtenerTasasHogarCiudad()).Data).First(t=>t.DpcId==datosPersonales.DpcIdInmueble).ValorTasa/100;
            var tasaSimulador = (await _carteraBusinessLogic.ObtenerTasasSimulador()).Data.First(t => t.IdSimulacion == request.simId.ToString());
            var tasaCredito = tasaSimulador.TasaEA / 100;
            var valorSeguro = (double)request.valor * (double)tasaSeguroHogar;
            var viviendaVis = "PENDIENTE";//verificar tipo de vivienda vis no vis
            var vivienda = 2;
            //ToDo: obtener excepciones
            //var excepcionesTipoActor = (await this._carteraBusinessLogic.ObtenerExcepcionesPlazo(new ParamGeneralesExcepcionPlazoDto { tipoCredito=1}).Data;
            //var excepcionesUEj = (await this.ObtenerExcepcionesPlazoUEj(request.simId, int.Parse(cliente.TipoAfiliacion))).Data;

            //Validar tasa minima y asignar a la tasa credito


            //obtengo la tasa mes vencido
            double primero = (double)(1 + tasaCredito);
            double segundo = ((double)0.0833333333333333);
            var tasaMesVencido = Math.Pow(primero, segundo) - 1;

            //Calcula tasa mixta(segurovida + tasa mes vencido)
            var tasaMixta = seguroVida + tasaMesVencido;

            //Asigno plazo maximo seguntabla
            var plazo = 0;
            if (request.plazo == null || request.plazo == 0)
                plazo = tasaSimulador.MaximoPlazoMeses;
            else
                plazo = request.plazo;


            //Calculo el factor (tasaMixta*((1+Tasamixta)^plazo))/((1+tasaMixta)^plazo)-1

            var factor = tasaMixta * Math.Pow((1 + tasaMixta), plazo) / (Math.Pow(1 + tasaMixta, plazo) - 1);

            //obtengo total ingresos y obtengo total egresos
            var totalIngesos = (double)datosFinancieros.TotalIngresos;
            var totalDescuentos = (double)datosFinancieros.TotalEgresos;

            //calculo cuota max totalIngresos*0.5-totalEgresos
            var cuotaMax = (totalIngesos * 0.5) - totalDescuentos;

            //calculo valor credito segun cuota (cuotaMax-valorSeguro)/factor
            var creditoSegunCuota = (cuotaMax - valorSeguro) / factor;
            //calculo valor credito segun vivienda 
            var creditoSegunVivienda = (double)0;
            if (vivienda == 1)
                creditoSegunVivienda = (double)(request.valor * 0.70);
            else
                creditoSegunVivienda = (double
                    )(request.valor * 0.80);

            //calculo el credito segun los intereses (cuotaMax-valorSeguro)/tasaMixta)*0.9999
            var creditoSegunIntereses = ((cuotaMax - (double)valorSeguro) / tasaMixta) * 0.9999;
            //selecciono el valor menos de los creditos y se lo asigno a valor prestamo
            var valorPrestamo = 0;
            if (creditoSegunCuota <= creditoSegunVivienda)
                valorPrestamo = (int)creditoSegunCuota;
            else if (creditoSegunVivienda <= creditoSegunIntereses)
                valorPrestamo = (int)creditoSegunVivienda;
            else
                valorPrestamo = (int)creditoSegunIntereses;

            //calculo la cuota del credito valorPrestamo*factor+valorSeguro
            var cuota = valorPrestamo * (double)factor + (double)valorSeguro;
            var solicitudSimulacion = await _creditoBusinessLogic.CrearSolicitudSimulacionCredito(new SolicitudSimulacionDto
            {
                Id = simulacionId,
                EnvioNotificacion = false,
                Estado = "I",
                FechaActualiza = DateTime.Now,
                FechaSolicitud = DateTime.Now,
                NumeroPreAprobado = 0,
                ProblemaEmail = false,
                UsuarioActualiza = Guid.NewGuid(),
                TcrId = equivalenciasSimuladoCredito.First(e => e.TipoSimulador == request.simId).TipoCredito
            });
            var simulacionCliente = await _creditoBusinessLogic.CrearSimulacionClienteSMC(new SMCSimulacionClienteDto()
            {
                Documento = request.documento,
                OpcionCompra = 0,
                TotalCuotas = plazo,
                FechaSimulacion = DateTime.Now,
                IdDatosPersonales = datosPersonales.Id,
                IdSimulacion = simulacionId,
                IdSimulacionCliente = Guid.NewGuid(),
                NumeroPreaprobado = 0,
                TasaEa = tasaCredito,
                TasaFrech = 0,
                TasaMv = tasaMesVencido,
                TipoAbono = "N",
                TipoAlivio = "N",
                TipoVivienda = request.ViviendaNueva ? "N" : "U",
                TomaSeguro = "N",
                UsaRecursosAcumulados = "N",
                ValorPrestamo = valorPrestamo,
                ValorPrestamosLeasing = 0,
                ValorVivienda = request.valor,
                ViviendaVis = viviendaVis
            });
            for (int i = 0; i <= plazo; i++)
            {
                if (i == 0)
                {
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        IdSimulacion = simulacionId,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        Saldo = valorPrestamo,
                        Cuota = i,
                        ViviendaVis = viviendaVis,
                        ValorVivienda = request.valor,
                        ValorPrestamo = valorPrestamo,
                        TotalCuota = cuota,
                        TotalCuotaSinSeguros = cuota - valorSeguro,
                        PlazoMeses = plazo,
                        PlazoAnos = plazo / 12,
                        ValorTasa = tasaCredito,
                        ValorTasaNominal = tasaMesVencido,
                        //añadir fecha corte y fecha pago
                        //Quemadas temporalmente
                        FechaCorte = DateTime.Now,
                        FechaPago = DateTime.Now,


                    });

                }
                else
                {
                    var seguroVidaCuota = planillaSimulacion[i - 1].Saldo * seguroVida;
                    var interesesCuota = planillaSimulacion[i - 1].Saldo * tasaMesVencido;
                    var seguroHogar = (double)tasaSeguroHogar * request.valor;
                    var capital = (cuota - seguroHogar - seguroVidaCuota - interesesCuota);
                    planillaSimulacion.Add(new SimulacionDto
                    {
                        IdSimulacion = simulacionId,
                        IdDetalleSimulacion = Guid.NewGuid(),
                        IdSimulacionCliente = simulacionCliente.Data.IdSimulacionCliente,
                        Cuota = i,
                        //añadir fecha corte y fecha pago
                        //Quemadas temporalmente
                        FechaCorte = DateTime.Now,
                        FechaPago = DateTime.Now,
                        Capital = (double)capital,
                        Saldo = (double)(planillaSimulacion[i - 1].Saldo - capital) < 1 ? 0 : (double)(planillaSimulacion[i - 1].Saldo - capital),
                        Intereses = interesesCuota,
                        SeguroVida = seguroVidaCuota,
                        SeguroHogar = (double)seguroHogar,
                        TotalCuota = cuota,
                        CuotaUnidadPagadora = (int)cuota

                    });
                }
                //var detalleSimulacion = (await _creditoBusinessLogic.CrearDetalleSimulacion(planillaSimulacion[i]));
            };
            foreach (var detalle in planillaSimulacion)
            {
                try
                {
                    var insercion = new Thread(async x => await _creditoBusinessLogic.CrearDetalleSimulacion(detalle));
                    insercion.Start();
                }
                catch (Exception ex)
                {
                    var exc = ex;
                }
            }
            return new Response<IEnumerable<SimulacionDto>> { Data = planillaSimulacion };
        }

        /// <summary>
        /// Genera datos prospeccion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<DatosProspeccionDto>> GenerarDatosProspeccion(DatosProspeccionDto request)
        {
            ClienteDto cliente = (await _requestProvider.ObtenerClientePorTipoIdentificationYNumero(request.TipoIdentificacion, request.NumeroDocumento)).Data;
            var datos = request;
            var estrato = (await _catalogsBusinessLogic.ObtenerEstrato()).Data.First(x => x.IdEstrato == request.IdEstrato).IdEstrato;
            var nivelEstudios = (await _catalogsBusinessLogic.ObtenerNivelAcademico()).Data.First(x => x.NivelAcademicoId == request.IdNivelAcademico).NivelAcademicoId;
            var personasACargo = (await _catalogsBusinessLogic.ObtenerPersonasCargo()).Data.First(x => x.Id == request.IdPersonasACargo).IdPersonasCargo;
            var tipoVivienda = (await _catalogsBusinessLogic.ObtenerTipoViviendaPropia()).Data.First(x => x.IdViviendaPropia == request.IdViviendaPropia).IdViviendaPropia;
            var tipoContrato = (await _catalogsBusinessLogic.ObtenerTipoContrato()).Data.First(x => x.IdTipoContrato == request.IdTipoContrato).IdTipoContrato;
            var simulacionPersonales = (await _creditoBusinessLogic.ObtenerSimulacionPersonales(request.NumeroDocumento)).Data;
            var estadoCivil = (await _catalogsBusinessLogic.ObtenerEstadosCiviles()).Data.First(x => x.Id == cliente.EstadoCivil).Id;
            var genero = (await _catalogsBusinessLogic.ObtenerTipoDeSexo()).Data.First(x => x.Codigo == cliente.Sexo).Codigo;
            var edad = cliente.FechaNacimiento == default(DateTime) || cliente.FechaNacimiento == DateTime.Parse("1900-01-01") ? 0 : DateTime.Today.AddTicks(-cliente.FechaNacimiento.Ticks).Year - 1;
            var antiguedad = DateTime.Today.AddTicks(-cliente.FechaAlta.Ticks).Year - 1;
            var ingresos = cliente.IngresoMensual + cliente.IngresoAdicional;/////////////////Pregunta
            var score = 0; //Averiguar donde esta el score
            //ToDO: Crear formaPago
            var formaPago = 0;
            //ToDo: Crear garantias
            var garantia = 0;
            double scoreRiesgo = 0;
            string DesicionHomologada = "VIABLE" /*string.Empty*/;
            //TODO: se deben ejecutar la integración con Transunion y tomar el valor del TAG <DecisionHomologada>


            datos.DesicionHomologadaTU = DesicionHomologada;
            //Si el resultado es “Viable” o “Pendiente”, debe ejecutar el modelo de consumo
            if (DesicionHomologada.ToUpper().Equals("VIABLE") || DesicionHomologada.ToUpper().Equals("PENDIENTE"))
            {
                /*-- Sumas o restas de la estimacion se deben hacer sobre el scoreRiesgo --*/

                //Estrato 3 o 4: -0.2420
                //Estrato 5 o 6: -0.5310
                if (estrato == 4 || estrato == 3)
                    scoreRiesgo -= 0.2420;
                else if (estrato == 6 || estrato == 5)
                    scoreRiesgo -= 0.5310;

                //Nivel de estudios = secundaria : -0.0961
                //Nivel de estudios = tecnico o tecnologo : -0.1142
                //Nivel de estudios = especializacion, maestria, doctorado, postdoctorado : -0.1767
                if (nivelEstudios == 2)
                    scoreRiesgo -= 0.0961;
                else if (nivelEstudios == 3 || nivelEstudios == 4)
                    scoreRiesgo -= 0.1142;
                else if (nivelEstudios > 5)
                    scoreRiesgo -= 0.1767;

                //Estado civil = Soltero: -0.0201
                //Estado civil = Casado: -0.0385
                //Estado civil = Divorciado: +0.0740
                //Estado civil = Viudo: -0.1417
                if (estadoCivil.Equals("S"))
                    scoreRiesgo -= 0.0201;
                else if (estadoCivil.Equals("C"))
                    scoreRiesgo -= 0.0385;
                else if (estadoCivil.Equals("D"))
                    scoreRiesgo += 0.0740;
                else if (estadoCivil.Equals("V"))
                    scoreRiesgo -= 0.1417;

                //Genero = Femenino: -0.5115
                if (genero.Equals("F"))
                    scoreRiesgo -= 0.5115;

                //Tipo vivienda = Propia: -0.9179
                if (tipoVivienda == 1)
                    scoreRiesgo -= 0.9179;

                //FormaPago=DebitoAutom: -0.4233
                //Forma Pago = Nomina: -0.4075 Defecto
                //TODO:Crear tabla y endpoint
                scoreRiesgo -= 0.4075;

                //garantia = pignoracion: -0.8002
                //garantia = Hipotecaria: -1.2189
                scoreRiesgo -= 1.2189;

                //TipoContrato = Prestacion = -0.0615
                //TipoContrato = Independiente = -0.3905
                //TipoContrato = TIndefinido = -0.2610
                //TipoContrato = Pensionado = -0.2813
                if (tipoContrato == 1)
                    scoreRiesgo -= 0.2610;
                else if (tipoContrato == 2)
                    scoreRiesgo -= 0.2813;
                else if (tipoContrato == 3)
                    scoreRiesgo -= 0.0615;
                else if (tipoContrato == 4)
                    scoreRiesgo -= 0.3905;

                //personas a cargo = Dos: -0.4468
                //personas a cargo = Una: -0.7615
                //personas a cargo = Ninguna: -1.1072
                if (personasACargo > 2)
                    scoreRiesgo -= 0.4468;
                else if (personasACargo == 1)
                    scoreRiesgo -= 0.7615;
                else if (personasACargo == 0)
                    scoreRiesgo -= -1.1072;

                //Edad 31 - 40: +0.3163
                //Edad 41 - 50: +0.3525
                //Edad 51 - 55: -0.2888
                //Edad 55 - 60: +0.1480
                //Edad > 60: +0.1807
                if (edad >= 31 && edad <= 40)
                    scoreRiesgo += 0.3163;
                else if (edad >= 41 && edad <= 50)
                    scoreRiesgo += 0.3525;
                else if (edad >= 51 && edad <= 55)
                    scoreRiesgo += 0.2888;
                else if (edad >= 55 && edad <= 60)
                    scoreRiesgo += 0.1480;
                else if (edad > 60)
                    scoreRiesgo += 0.1807;

                //Antiguedad afiliado 1: -0.3687 ////////////////////Preguntar si es uno o menos
                //Antiguedad afiliado 2-5: -0.8222
                //Antiguedad afiliado 6-34: -1.2003
                //Antiguedad afiliado > 34: -1.5906

                //Ingresos 1500000 - 3000000: -0.0625
                //Ingresos 3000000 - 5000000: -0.2466
                //Ingresos < 1500000: +0.7046

                //Score 700-800 : -0.5000
                //Score 800-900 : -1.4816
                //Score > 900 : -2.5416

                //Cesantias 2300000 - 6400000= -0.0431
                //Cesantias 6400000 - 12800000= -0.0045
                //Cesantias 12800000 - 24800000= -0.0275
                //Cesantias > 24800000= -0.2608

                //Activos > 150000000 = -0.9794
                if (request.TotalActivos > 150000000)
                    scoreRiesgo -= 0.9794;

                //Pasivos < 75000000: -1.2247
                if (request.TotalPasivos < 75000000)
                    scoreRiesgo -= 1.2247;

                //scoreRiesgo <=5 : viabilidad=>true
                //scoreRiesgo >5 : viabilidad=>false
                if (scoreRiesgo <= 5)
                    datos.Viabilidad = true;
                else datos.Viabilidad = false;

                datos.RiegoCredito = (decimal)scoreRiesgo;
            }


            //Retorna los datos almacenados
            return new Response<DatosProspeccionDto> { Data = datos };
        }

        public async Task<Response<object>> LlamadoIntegracionesAfiliado(RequestIntegracionesAfiliadoDto request)
        {
            Response<diffgram> validacionBiometria = new();
            try
            {
                validacionBiometria = await _fenixBusinessLogic.ValidarBiometria(request.Identificacion);
                validacionBiometria.ReturnMessage = "";
            }
            catch (Exception ex)
            {
                validacionBiometria = new()
                {
                    ReturnMessage = $"No se pudo realizar la validacion de biometria para el documento {request.Identificacion}"
                };
            }
            Response<ResultadoVerificacionTercero> verificacionTercero = new();
            try
            {
                verificacionTercero = await _vigiaBusinessLogic.VertificacionTercero(new Application.Dto.VerificacionTerceroRequest { Pe_Dato = request.Identificacion, Pe_TipoVerificacion = "1" });
                verificacionTercero.ReturnMessage = "";
            }
            catch (Exception ex)
            {
                verificacionTercero = new()
                {
                    ReturnMessage = $"No se pudo realizar la verificacion del tercero con documento {request.Identificacion}"
                };
            }
            var OptionsAqm = _optionsAqm.Value;
            RequestTuDto requestTrasnUnion = new()
            {
                IdValidation = Guid.NewGuid().ToString(),
                IdNumber = request.Identificacion,
                IdType = request.TipoIdentificacion,
                RecentPhoneNumber = request.Telefono,
                LastName = request.Apellidos,
                IdExpeditionDate = request.FechaExpedicionIdentificacion,
                usrId = OptionsAqm.usuarioAqm,
                pasword = OptionsAqm.claveAqm,
                solucionId = OptionsAqm.solucionIdAqm
            };

            GestorIdVisionBusinessLogic ConsultasTransUnion = new GestorIdVisionBusinessLogic();
            Response<ResponseTu> respuestaTransUnion = new();
            try
            {
                respuestaTransUnion = new Response<ResponseTu> { Data = await _gestorIdVision.validarCliente(requestTrasnUnion) };
                //respuestaTransUnion = new Response<FileResult> { Data = await _creditoBusinessLogic.ObtenerHistorialComercialBuro(requestTrasnUnion) };

            }
            catch (Exception ex)
            {
                respuestaTransUnion.ReturnMessage = $"Error al generar validaciones en TransUnion para el documento {request.Identificacion}";
            }

            if (!string.IsNullOrEmpty(verificacionTercero.ReturnMessage))
                return new Response<object> { ReturnMessage = verificacionTercero.ReturnMessage, IsSuccess = false };
            else if (!string.IsNullOrEmpty(validacionBiometria.ReturnMessage))
                return new Response<object> { ReturnMessage = validacionBiometria.ReturnMessage, IsSuccess = false };
            else if (!string.IsNullOrEmpty(respuestaTransUnion.ReturnMessage))
                return new Response<object> { ReturnMessage = respuestaTransUnion.ReturnMessage, IsSuccess = false };
            else
                return new Response<object> { IsSuccess = true, ReturnMessage = "Validaciones realizadas exitosamente" };

        }


        /// <summary>
        /// Obtiene el cliente para la prospeccion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<DataClienteProspeccionDto>> ObtenerClienteProspeccion(DataClienteProspeccionDto request)
        {
            DataClienteProspeccionDto cliente = await this.ObtenerClienteTipoNumero(request.TipoIdentificacion, request.NumeroDocumento);

            return new Response<DataClienteProspeccionDto> { Data = cliente };
        }

        public Task<Response<IEnumerable<object>>> ObtenerExcepcionesPlazoTipoActor(int simId, int v)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<object>>> ObtenerExcepcionesPlazoUEj(int simId, int v)
        {
            throw new NotImplementedException();
        }

        private async Task<DataClienteProspeccionDto> ObtenerClienteTipoNumero(int tipoIdentificacion, string identificacion)
        {
            ClienteDto cliente = (await _requestProvider.ObtenerClientePorTipoIdentificationYNumero(tipoIdentificacion, identificacion)).Data;
            var response = new DataClienteProspeccionDto()
            {
                NumeroDocumento = identificacion,
                TipoIdentificacion = tipoIdentificacion,
                CategoriaId = cliente.IdCategoria,
                TipoTelefonoId = cliente.IdTipoTelefono,
                Celular = cliente.Telefono,
                CiudadResidenciaId = cliente.IdCiudadResidencia,
                Direccion = cliente.Direccion,
                Email = cliente.Correo,
                FuerzaId = cliente.IdFuerza,
                GradoId = cliente.IdGrado,
                Nombres = $"{cliente.PrimerNombre} {cliente.SegundoNombre} {cliente.PrimerApellido} {cliente.SegundoApellido}",
                Regimen = cliente.Regimen.ToString(),
                CuotasAportadas = cliente.AportesCategoria.Count().ToString(),
                AntiguedadAños = DateTime.Now.Month - cliente.FechaAlta.Month >= 0 ? (DateTime.Now.Year - cliente.FechaAlta.Year) : (DateTime.Now.Year - cliente.FechaAlta.Year) - 1,
                FormaPago = "Nomina"
            };

            response.Categoria = (await _catalogsBusinessLogic.ObtenerCategorias()).Data.First(x => x.Id == response.CategoriaId).Descripcion;
            response.CiudadResidencia = (await _catalogsBusinessLogic.ObtenerCiudades()).Data.First(x => x.Id == response.CiudadResidenciaId).Nombre;
            response.Fuerza = (await _catalogsBusinessLogic.ObtenerFuerzas()).Data.First(x => x.Id == response.FuerzaId).Descripcion;
            response.Grado = (await _catalogsBusinessLogic.ObtenerGrados()).Data.First(x => x.Id == response.GradoId).Descripcion;
            //Temporalmente
            response.TipoContratoId = 1;

            return response;
        }

        public async Task<Response<SolicitudSimulacionDto>> CrearPreAprobado(SolicitudSimulacionDto request)
        {
            return await _creditoBusinessLogic.CrearPreAprobado(request);
        }

        public async Task<Response<SolicitudCreditoDto>> CrearSolicitudCredito(SolicitudCreditoDto request)
        {
            return new Response<SolicitudCreditoDto> { Data = _mapper.Map<SolicitudCreditoDto>(await this._creditoRepository.CrearSolicitudCredito(_mapper.Map<SolicitudCredito>(request))) };
        }
    }
}
