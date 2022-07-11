using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Dto.Producto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper Cartera
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class CarteraMapper : Profile
    {
        public CarteraMapper()
        {
            // Model Producto Dto Producto
            CreateMap<ProductoDTO, Producto>()
                .ForMember(x => x.TCR_ID, map => map.MapFrom(dto => dto.TCR_ID))
                .ForMember(x => x.PRD_NUMERO_CREDITO, map => map.MapFrom(dto => dto.PRD_NUMERO_CREDITO))
                .ForMember(x => x.PRD_FECHA_ALTA, map => map.MapFrom(dto => dto.PRD_ESTADO))
                .ForMember(x => x.PRD_ESTADO, map => map.MapFrom(dto => dto.PRD_ESTADO))
                .ForMember(x => x.PRD_FECHA_ESTADO, map => map.MapFrom(dto => dto.PRD_FECHA_ESTADO))
                .ForMember(x => x.PRD_FECHA_PAGO, map => map.MapFrom(dto => dto.PRD_FECHA_PAGO))
                .ForMember(x => x.PRD_DIAS_MORA, map => map.MapFrom(dto => dto.PRD_DIAS_MORA))
                .ForMember(x => x.PRD_VALOR, map => map.MapFrom(dto => dto.PRD_VALOR))
                .ForMember(x => x.TIV_VIVIENDA_ID, map => map.MapFrom(dto => dto.TIV_VIVIENDA_ID))
                .ForMember(x => x.ESV_ESTADO_VIVIENDA, map => map.MapFrom(dto => dto.ESV_ESTADO_VIVIENDA))
                .ForMember(x => x.PRD_CREDITO, map => map.MapFrom(dto => dto.PRD_CREDITO))
                .ForMember(x => x.PRD_DEUDA, map => map.MapFrom(dto => dto.PRD_DEUDA))
                .ForMember(x => x.PRD_MORA, map => map.MapFrom(dto => dto.PRD_MORA))
                .ForMember(x => x.PRD_CUOTA_ANO, map => map.MapFrom(dto => dto.PRD_CUOTA_ANO))
                .ForMember(x => x.PRD_CUOTA_MES, map => map.MapFrom(dto => dto.PRD_CUOTA_MES))
                .ForMember(x => x.PRD_SEGURO_VIDA, map => map.MapFrom(dto => dto.PRD_SEGURO_VIDA))
                .ForMember(x => x.PRD_SEGURO_TODO_RIESGO, map => map.MapFrom(dto => dto.PRD_SEGURO_TODO_RIESGO))
                .ForMember(x => x.PRD_TASA_EFECTIVA_ANUAL, map => map.MapFrom(dto => dto.PRD_TASA_EFECTIVA_ANUAL))
                .ForMember(x => x.PRD_TASA_NOMINAL_MENSUAL, map => map.MapFrom(dto => dto.PRD_TASA_NOMINAL_MENSUAL))
                .ForMember(x => x.PRD_TASA_FRECH_APLICA, map => map.MapFrom(dto => dto.PRD_TASA_FRECH_APLICA))
                .ForMember(x => x.PRD_TASA_FRECH, map => map.MapFrom(dto => dto.PRD_TASA_FRECH))
                .ForMember(x => x.PRD_ALIVIO_CUOTA_APLICA, map => map.MapFrom(dto => dto.PRD_ALIVIO_CUOTA_APLICA))
                .ForMember(x => x.PRD_ALIVIO_CUOTA, map => map.MapFrom(dto => dto.PRD_ALIVIO_CUOTA))
                .ReverseMap();

            CreateMap<ProductoClienteDto, ProductoCliente>()
                .ForMember(x => x.CRE_ID, map => map.MapFrom(dto => dto.IdCredito))
                .ForMember(x => x.CRE_FECHA_DESEMBOLSO, map => map.MapFrom(dto => dto.FechaDesembolso))
                .ForMember(x => x.CRE_VALOR_DESEMBOLSO, map => map.MapFrom(dto => dto.ValorDesembolso))
                .ForMember(x => x.CRE_VALOR_CUOTA, map => map.MapFrom(dto => dto.ValorCuota))
                .ForMember(x => x.CRE_PLAZO_TOTAL, map => map.MapFrom(dto => dto.PlazoTotal))
                .ForMember(x => x.TCR_ID, map => map.MapFrom(dto => dto.IdTipoCredito))
                .ForMember(x => x.CRE_DIA_PAGO, map => map.MapFrom(dto => dto.DiaPago))
                .ForMember(x => x.ESC_ID, map => map.MapFrom(dto => dto.IdEstadoCredito))
                .ForMember(x => x.CRE_FECHA_ESTADO, map => map.MapFrom(dto => dto.FechaEstadoCredito))
                .ForMember(x => x.CRE_DIAS_MORA, map => map.MapFrom(dto => dto.DiasMora))
                .ForMember(x => x.CRE_VALOR_VIVIENDA, map => map.MapFrom(dto => dto.ValorVivienda))
                .ForMember(x => x.TIV_ID, map => map.MapFrom(dto => dto.IdEstadoVivienda))
                .ForMember(x => x.TVV_ID, map => map.MapFrom(dto => dto.IdTipoVivienda))
                .ForMember(x => x.CRE_SALDO_CAPITAL, map => map.MapFrom(dto => dto.SaldoCapital))
                .ForMember(x => x.CRE_SALDO_CAPITAL_MORA, map => map.MapFrom(dto => dto.SaldoCapitalMora))
                .ForMember(x => x.CRE_PLAZO_ACTUAL, map => map.MapFrom(dto => dto.PlazoActual))
                .ForMember(x => x.CRE_TASA_SEGURO_VIDA, map => map.MapFrom(dto => dto.TasaSeguroVida))
                .ForMember(x => x.CRE_TASA_SEGURO_HOGAR, map => map.MapFrom(dto => dto.TasaSeguroHogar))
                .ForMember(x => x.CRE_TASA_CREDITO_EA, map => map.MapFrom(dto => dto.TasaCreditoEA))
                .ForMember(x => x.CRE_TASA_CREDITO_PER, map => map.MapFrom(dto => dto.TasaCreditoPer))
                .ForMember(x => x.CRE_TASA_FRECH, map => map.MapFrom(dto => dto.TasaFrech))
                .ForMember(x => x.CRE_VALOR_ALIVIO_CUOTA, map => map.MapFrom(dto => dto.ValorAlivioCuota))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO, map => map.MapFrom(dto => dto.FechaUltimoPago))
                .ForMember(x => x.CRE_FECHA_PROXIMO_PAGO, map => map.MapFrom(dto => dto.FechaProximoPago))
                .ForMember(x => x.CRE_TIPO_ABONO_EXTRA, map => map.MapFrom(dto => dto.TipoAbonoExtra))
                .ForMember(x => x.CRE_VALOR_ABONO_EXTRA, map => map.MapFrom(dto => dto.ValorAbonoExtra))
                .ForMember(x => x.CRE_VALOR_DEUDA_REMANENTE, map => map.MapFrom(dto => dto.ValorDeudaRemanente))
                .ForMember(x => x.CRE_VALOR_CANON_INICIAL, map => map.MapFrom(dto => dto.ValorCanonInicial))
                .ForMember(x => x.CRE_VALOR_OPCION_COMPRA, map => map.MapFrom(dto => dto.ValorOpcionCompra))
                .ForMember(x => x.CRE_POR_CANON_INICIAL, map => map.MapFrom(dto => dto.PorcentajeCanonInicial))
                .ForMember(x => x.CRE_POR_OPCION_COMPRA, map => map.MapFrom(dto => dto.PorcentajeOpcionCompra))
                .ForMember(x => x.CRE_ACUMULADO_INTERES_MORA, map => map.MapFrom(dto => dto.AcumuladoInteresMora))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA, map => map.MapFrom(dto => dto.UltimoPagoInteresMora))
                .ForMember(x => x.CRE_ACUMULADO_INTERES_CORRIENTE, map => map.MapFrom(dto => dto.AcumuladoInteresCorriente))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE, map => map.MapFrom(dto => dto.UltimoPagoInteresCorriente))
                .ForMember(x => x.CRE_ACUMULADO_SEGURO_HOGAR, map => map.MapFrom(dto => dto.AcumuladoSeguroHogar))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR, map => map.MapFrom(dto => dto.UltimoPagoSeguroHogar))
                .ForMember(x => x.CRE_ACUMULADO_SEGURO_VIDA, map => map.MapFrom(dto => dto.AcumuladoSeguroVida))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA, map => map.MapFrom(dto => dto.UltimoPagoSeguroVida))
                .ForMember(x => x.CRE_ALIVIO_FRECH, map => map.MapFrom(dto => dto.AlivioFrech))
                .ForMember(x => x.CRE_NUMERO_CUOTAS_CANCELADAS, map => map.MapFrom(dto => dto.NumeroCuotasCanceladas))
                .ForMember(x => x.CRE_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.CRE_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.CRE_MODIFICADO_POR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ForMember(x => x.CRE_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ForMember(x => x.CRE_NRO_CREDITO, map => map.MapFrom(dto => dto.NumeroCredito))
                .ForMember(x => x.CLI_IDENTIFICACION, map => map.MapFrom(dto => dto.Identificacion))
                .ForMember(x => x.TIPO_IDENTIFICACION, map => map.MapFrom(dto => dto.TipoIdentificacion))
                .ForMember(x => x.CLI_EDAD, map => map.MapFrom(dto => dto.Edad))
                .ForMember(x => x.CATEGORIA, map => map.MapFrom(dto => dto.Categoria))
                .ForMember(x => x.GRADO, map => map.MapFrom(dto => dto.Grado))
                .ForMember(x => x.CRE_DIRECCION_INMUEBLE, map => map.MapFrom(dto => dto.DireccionInmueble))
                .ForMember(x => x.CIUDAD_INMUEBLE, map => map.MapFrom(dto => dto.CiudadInmueble))
                .ForMember(x => x.NUMERO_MATRICULA, map => map.MapFrom(dto => dto.NoMatricula))
                .ForMember(x => x.ESCRITURA_INMUEBLE, map => map.MapFrom(dto => dto.Escritura))
                .ForMember(x => x.FECHA_ESCRITURA, map => map.MapFrom(dto => dto.FechaEscritura))
                .ForMember(x => x.NOTARIA, map => map.MapFrom(dto => dto.Notaria))
                .ForMember(x => x.SIJ_LINDEROS, map => map.MapFrom(dto => dto.Linderos))
                .ForMember(x => x.DESCRIPCION_INMUEBLE, map => map.MapFrom(dto => dto.DescripcionInmueble))
                .ForMember(x => x.SOC_SCORE, map => map.MapFrom(dto => dto.Score))
                .ForMember(x => x.FECHA_SOLICITUD, map => map.MapFrom(dto => dto.FechaSolicitud))
                .ForMember(x => x.CRE_FECHA_FINALIZA_PAGOS, map => map.MapFrom(dto => dto.FechaFinPagos))
                .ForMember(x => x.CRE_CANON_EXTRAORDINARIO, map => map.MapFrom(dto => dto.CanonExtraordinario))
                .ForMember(x => x.TIPO_VIVIENDA, map => map.MapFrom(dto => dto.TipoVivienda))
                .ForMember(x => x.CLASE_INMUEBLE, map => map.MapFrom(dto => dto.ClaseInmueble))
                .ForMember(x => x.ESTADO_CREDITO, map => map.MapFrom(dto => dto.EstadoCredito))
                .ReverseMap();


            CreateMap<InformacionCreditoDto, InformacionCredito>()
                .ForMember(x => x.CRE_ID, map => map.MapFrom(dto => dto.IdCredito))
                .ForMember(x => x.CRE_NRO_CREDITO, map => map.MapFrom(dto => dto.NumeroCredito))
                .ForMember(x => x.CRE_FECHA_DESEMBOLSO, map => map.MapFrom(dto => dto.FechaDesembolso))
                .ForMember(x => x.CRE_VALOR_DESEMBOLSO, map => map.MapFrom(dto => dto.ValorDesembolso))
                .ForMember(x => x.CRE_VALOR_CUOTA, map => map.MapFrom(dto => dto.ValorCuota))
                .ForMember(x => x.CRE_PLAZO_TOTAL, map => map.MapFrom(dto => dto.PlazoTotal))
                .ForMember(x => x.TCR_ID, map => map.MapFrom(dto => dto.IdTipoCredito))
                .ForMember(x => x.CRE_DIA_PAGO, map => map.MapFrom(dto => dto.DiaPago))
                .ForMember(x => x.ESC_ID, map => map.MapFrom(dto => dto.IdEstadoCartera))
                .ForMember(x => x.CRE_FECHA_ESTADO, map => map.MapFrom(dto => dto.FechaEstado))
                .ForMember(x => x.CRE_DIAS_MORA, map => map.MapFrom(dto => dto.DiasMora))
                .ForMember(x => x.CRE_VALOR_VIVIENDA, map => map.MapFrom(dto => dto.ValorVivienda))
                .ForMember(x => x.TIV_ID, map => map.MapFrom(dto => dto.IdTipoVivienda))
                .ForMember(x => x.TVV_ID, map => map.MapFrom(dto => dto.IdEstadoVivienda))
                .ForMember(x => x.CRE_SALDO_CAPITAL, map => map.MapFrom(dto => dto.SaldoCapital))
                .ForMember(x => x.CRE_SALDO_CAPITAL_MORA, map => map.MapFrom(dto => dto.SaldoCapitalMora))
                .ForMember(x => x.CRE_PLAZO_ACTUAL, map => map.MapFrom(dto => dto.PlazoActual))
                .ForMember(x => x.CRE_TASA_SEGURO_VIDA, map => map.MapFrom(dto => dto.TasaSeguroVida))
                .ForMember(x => x.CRE_TASA_SEGURO_HOGAR, map => map.MapFrom(dto => dto.TasaSeguroHogar))
                .ForMember(x => x.CRE_TASA_CREDITO_EA, map => map.MapFrom(dto => dto.TasaCreditoEfectivaAnual))
                .ForMember(x => x.CRE_TASA_CREDITO_PER, map => map.MapFrom(dto => dto.TasaCreditoPer))
                .ForMember(x => x.CRE_TASA_FRECH, map => map.MapFrom(dto => dto.TasaFrech))
                .ForMember(x => x.CRE_VALOR_ALIVIO_CUOTA, map => map.MapFrom(dto => dto.ValorAlivioCuota))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO, map => map.MapFrom(dto => dto.FechaUltimoPago))
                .ForMember(x => x.CRE_FECHA_PROXIMO_PAGO, map => map.MapFrom(dto => dto.FechaProximoPago))
                .ForMember(x => x.CRE_TIPO_ABONO_EXTRA, map => map.MapFrom(dto => dto.TipoAbonoExtra))
                .ForMember(x => x.CRE_VALOR_ABONO_EXTRA, map => map.MapFrom(dto => dto.ValorAbonoExtra))
                .ForMember(x => x.CRE_VALOR_DEUDA_REMANENTE, map => map.MapFrom(dto => dto.ValorDeudaRemanente))
                .ForMember(x => x.CRE_VALOR_CANON_INICIAL, map => map.MapFrom(dto => dto.ValorCanonInicial))
                .ForMember(x => x.CRE_VALOR_OPCION_COMPRA, map => map.MapFrom(dto => dto.ValorOpcionCompra))
                .ForMember(x => x.CRE_POR_CANON_INICIAL, map => map.MapFrom(dto => dto.PorcentajeCanonInicial))
                .ForMember(x => x.CRE_POR_OPCION_COMPRA, map => map.MapFrom(dto => dto.PorcentajePorOpcionCompra))
                .ForMember(x => x.CRE_ACUMULADO_INTERES_MORA, map => map.MapFrom(dto => dto.AcumuladoInteresMora))
                .ForMember(x => x.CRE_ACUMULADO_INTERES_CORRIENTE, map => map.MapFrom(dto => dto.AcumuladoSeguroHogar))
                .ForMember(x => x.CRE_ACUMULADO_SEGURO_HOGAR, map => map.MapFrom(dto => dto.AcumuladoSeguroHogar))
                .ForMember(x => x.CRE_ACUMULADO_SEGURO_VIDA, map => map.MapFrom(dto => dto.AcumuladoSeguroVida))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA, map => map.MapFrom(dto => dto.FechaUltimoPagoInteresMora))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE, map => map.MapFrom(dto => dto.FechaUltimoPagoInteresCorriente))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR, map => map.MapFrom(dto => dto.FechaUltimoPagoSeguroHogar))
                .ForMember(x => x.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA, map => map.MapFrom(dto => dto.FechaUltimoPagoSeguroVida))
                .ForMember(x => x.CRE_ALIVIO_FRECH, map => map.MapFrom(dto => dto.AlivioFrech))
                .ForMember(x => x.CRE_NUMERO_CUOTAS_CANCELADAS, map => map.MapFrom(dto => dto.NumeroCuotasCanceladas))
                .ForMember(x => x.CRE_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.CRE_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.CRE_MODIFICADO_POR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ForMember(x => x.CRE_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ForMember(x => x.CRE_CANON_EXTRAORDINARIO, map => map.MapFrom(dto => dto.CanonExtraordinario))
                .ReverseMap();

            CreateMap<AplicacionPagoDto, AplicacionPago>()
                .ForMember(x => x.CPG_ID, map => map.MapFrom(dto => dto.IdAplicacionPago))
                .ForMember(x => x.CRE_ID, map => map.MapFrom(dto => dto.IdCredito))
                .ForMember(x => x.CPG_FECHA_PAGO, map => map.MapFrom(dto => dto.FechaPago))
                .ForMember(x => x.CPG_FECHA_APLICACION, map => map.MapFrom(dto => dto.FechaAplicacion))
                .ForMember(x => x.CPG_ABONO_SEGURO_HOGAR, map => map.MapFrom(dto => dto.AbonoSeguroHogar))
                .ForMember(x => x.CPG_ABONO_SEGURO_VIDA, map => map.MapFrom(dto => dto.AbonoSeguroVida))
                .ForMember(x => x.CPG_ABONO_INTERES_CORRIENTE, map => map.MapFrom(dto => dto.AbonoInteresCorriente))
                .ForMember(x => x.CPG_ABONO_INTERES_MORA, map => map.MapFrom(dto => dto.AbonoInteresMora))
                .ForMember(x => x.CPG_ABONO_CAPITAL, map => map.MapFrom(dto => dto.AbonoCapital))
                .ForMember(x => x.CPG_VALOR_PAGO, map => map.MapFrom(dto => dto.ValorPago))
                .ForMember(x => x.DCT_ID, map => map.MapFrom(dto => dto.IdDct))
                .ForMember(x => x.CPG_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.CPG_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.CPG_MODIFICADO_POR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ForMember(x => x.CPG_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ReverseMap();


            CreateMap<ParametrosAplicacionPagosDto, ParametrosAplicacionPagos>()
                .ForMember(x => x.PARAM_ID, map => map.MapFrom(dto => dto.IdParametros))
                .ForMember(x => x.PARAM_TASA_MORA, map => map.MapFrom(dto => dto.TasaMora))
                .ForMember(x => x.PARAM_FACTOR_DIAS, map => map.MapFrom(dto => dto.FactorDias))
                .ForMember(x => x.PARAM_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.PARAM_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.PARAM_MODIFICADO_POR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ForMember(x => x.PARAM_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ReverseMap();

            CreateMap<TasaSimuladorDto, TasaSimulador>()
                .ForMember(x => x.SIM_ID, map => map.MapFrom(dto => dto.IdSimulacion))
                .ForMember(x => x.SIM_DESCRIPCION, map => map.MapFrom(dto => dto.Descripcion))
                .ForMember(x => x.SIM_TASA_EA, map => map.MapFrom(dto => dto.TasaEA))
                .ForMember(x => x.SIM_MINIMO_MESES_PLAZO, map => map.MapFrom(dto => dto.MinimoPlazoMeses))
                .ForMember(x => x.SIM_MAXIMO_MESES_PLAZO, map => map.MapFrom(dto => dto.MaximoPlazoMeses))
                .ForMember(x => x.SIM_ESTADO, map => map.MapFrom(dto => dto.Estado))
                .ForMember(x => x.SIM_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.SIM_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.SIM_MODIFICADO_POR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ForMember(x => x.SIM_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ForMember(x => x.PAR_ID, map => map.MapFrom(dto => dto.ParametroId))
                .ForMember(x => x.PAR_TASA_EA, map => map.MapFrom(dto => dto.ParametroTasaEa))
                .ForMember(x => x.TPA_ID, map => map.MapFrom(dto => dto.TipoParametroId))
                .ForMember(x => x.TPA_DESCRIPCION, map => map.MapFrom(dto => dto.TipoParametroDescripcion))
                .ForMember(x => x.PAR_ESTADO, map => map.MapFrom(dto => dto.EstadoParametro))

                .ReverseMap();

            CreateMap<TipoActorDto, TipoActor>()


                .ForMember(x => x.TPA_ID, map => map.MapFrom(dto => dto.IdTipoActor))
                .ForMember(x => x.TPA_DESCRIPCION, map => map.MapFrom(dto => dto.DescripcionTipoActor))
                .ForMember(x => x.TPA_ACTIVO, map => map.MapFrom(dto => dto.ActivoTipoActor))
                .ForMember(x => x.TPA_APLICA_CUENTA, map => map.MapFrom(dto => dto.AplicaCuentaTipoActor))
                .ForMember(x => x.TPA_APLICA_CLIENTE, map => map.MapFrom(dto => dto.AplicaClienteTipoActor))
                .ForMember(x => x.TPA_APLICA_BLOQUEO, map => map.MapFrom(dto => dto.AplicaBloqueoTipoActor))
                .ForMember(x => x.TPA_APLICA_USUARIO, map => map.MapFrom(dto => dto.AplicaUsuarioTipoActor))
                .ForMember(x => x.TPA_ORDEN_PAGO, map => map.MapFrom(dto => dto.OrdenPagoTipoActor))

                .ReverseMap();
            
            CreateMap<ParametrosTasaActorDto, ParametrosTasaActor>()


                .ForMember(x => x.PAR_ID, map => map.MapFrom(dto => dto.ParametroId))
                .ForMember(x => x.SIM_ID, map => map.MapFrom(dto => dto.SimuladorId))
                .ForMember(x => x.TPA_ID, map => map.MapFrom(dto => dto.TipoId))
                .ForMember(x => x.PAR_TASA_EA, map => map.MapFrom(dto => dto.ParametroTasaEa))
                .ForMember(x => x.PAR_ESTADO, map => map.MapFrom(dto => dto.ParametroEstado))
                .ForMember(x => x.PAR_CREADO_POR, map => map.MapFrom(dto => dto.ParametroCreadoPor))
                .ForMember(x => x.PAR_MODIFICADO_POR, map => map.MapFrom(dto => dto.ParametroModificadoPor))

                .ReverseMap(); 
            
            CreateMap<UnidadesEjecutorasDto, UnidadesEjecutoras>()


                .ForMember(x => x.PAR_ID, map => map.MapFrom(dto => dto.idParametro))
                .ForMember(x => x.SIM_ID, map => map.MapFrom(dto => dto.idSimulacion))
                .ForMember(x => x.UEJ_ID, map => map.MapFrom(dto => dto.idUnidadEjecutora))
                .ForMember(x => x.PAR_TASA_EA, map => map.MapFrom(dto => dto.tasaEa))
                .ForMember(x => x.PAR_ESTADO, map => map.MapFrom(dto => dto.estado))
                .ForMember(x => x.UEJ_NOMBRE, map => map.MapFrom(dto => dto.nombreUnidadEjecutora))                
                .ForMember(x => x.UEJ_IDENTIFICACION, map => map.MapFrom(dto => dto.NitUnidadEjecutora))                
                .ForMember(x => x.UEJ_SIGLA, map => map.MapFrom(dto => dto.SiglaUnidadEjecutora))                

                .ReverseMap();
            
            CreateMap<ParamGeneralesCreditoYCarteraDto, ParamGeneralesCreditoYCartera>()


                .ForMember(x => x.PRM_SMLV, map => map.MapFrom(dto => dto.parametroSalarioMinimo))
                .ForMember(x => x.PRM_PORC_INFLACION, map => map.MapFrom(dto => dto.porcentajeInflacion))
                .ForMember(x => x.PRM_PORC_FINANCIA_VIS, map => map.MapFrom(dto => dto.porcentajeViviendaVis))
                .ForMember(x => x.PRM_PORC_FINANCIA_NO_VIS, map => map.MapFrom(dto => dto.porcentajeViviendaNoVis))
                .ForMember(x => x.PRM_NO_SALARIO_MIN_VIS, map => map.MapFrom(dto => dto.limiteSalariosVis))
                .ForMember(x => x.PRM_DIAS_VALIDO_PREAPROB, map => map.MapFrom(dto => dto.diasPreaprobado))                
                .ForMember(x => x.PRM_SCORE_MINIMO, map => map.MapFrom(dto => dto.puntajeMinimoCentrales))                
                .ForMember(x => x.PRM_PORC_CAPACIDAD_ENDEUDA, map => map.MapFrom(dto => dto.porcentajeMinimoEndeudamiento))                
                .ForMember(x => x.PRM_VIGENCIA_CONSULTA_BURO, map => map.MapFrom(dto => dto.vigenciaDiasConsultaCentrales))                
                .ForMember(x => x.PRM_PORC_CANON_INI_LSG, map => map.MapFrom(dto => dto.porcentajeMinimoCanonInicial))                
                .ForMember(x => x.PRM_PORC_CANON_FIN_LSG, map => map.MapFrom(dto => dto.porcentajeMaximoCanonInicial))                
                .ForMember(x => x.PRM_PORC_OPC_COMPRA_LSG, map => map.MapFrom(dto => dto.porcentajeMaximoOpcionCompra))                
                .ForMember(x => x.PRM_MESES_LEY_FRECH, map => map.MapFrom(dto => dto.maximoMesesAlivioTasa))                
                .ForMember(x => x.PRM_MESES_SUBSIDIO_CUOTA, map => map.MapFrom(dto => dto.numeroMesesAlivio))                

                .ReverseMap();
            
            CreateMap<ParamGeneralesExcepcionPlazoDto, ParamGeneralesExcepcionPlazo>()


                .ForMember(x => x.PLAZ_ID, map => map.MapFrom(dto => dto.plazoId))
                .ForMember(x => x.PLAZ_YEAR_MIN, map => map.MapFrom(dto => dto.plazoMinimoAnio))
                .ForMember(x => x.PLAZ_MONTH_MIN, map => map.MapFrom(dto => dto.plazoMinimoMes))
                .ForMember(x => x.PLAZ_YEAR_MAX, map => map.MapFrom(dto => dto.plazoMaximoAnio))
                .ForMember(x => x.PLAZ_MONTH_MAX, map => map.MapFrom(dto => dto.plazoMaximoMes))
                .ForMember(x => x.PLAZ_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.plazoFechaModificacion))                
                .ForMember(x => x.PLAZ_MODIFICADO_POR, map => map.MapFrom(dto => dto.plazoModificadoPor))                
                .ForMember(x => x.PLAZ_ESTADO, map => map.MapFrom(dto => dto.plazoEstado))                           
                .ForMember(x => x.TPA_ID, map => map.MapFrom(dto => dto.IdTipoActor))                           
                .ForMember(x => x.ID_EXE_PLAZO, map => map.MapFrom(dto => dto.idExcepcion))                           
                .ForMember(x => x.TCR_ID, map => map.MapFrom(dto => dto.tipoCredito))                           
                .ForMember(x => x.UEJ_ID, map => map.MapFrom(dto => dto.unidadEjecutoraId))                           
                .ForMember(x => x.ID_EXC_PLAZO, map => map.MapFrom(dto => dto.idExcepcionPlazo))                           
                .ForMember(x => x.TPA_DESCRIPCION, map => map.MapFrom(dto => dto.DescripcionTipoActor))                           
                .ForMember(x => x.UEJ_NOMBRE, map => map.MapFrom(dto => dto.NombreUnidadEjecutora))                           

                .ReverseMap(); 
            
            CreateMap<ParamGeneralesSegurosDto, ParamGeneralesSeguros>()


                .ForMember(x => x.SEG_ID, map => map.MapFrom(dto => dto.idSeguro))
                .ForMember(x => x.SEG_VIDA, map => map.MapFrom(dto => dto.seguroVida))
                .ForMember(x => x.SEG_TODO_RIESGO, map => map.MapFrom(dto => dto.seguroTodoRiesgo))
                .ForMember(x => x.SEG_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.seguroFechaModificacion))
                .ForMember(x => x.SEG_MODIFICADO_POR, map => map.MapFrom(dto => dto.seguroModificadoPor))
                .ForMember(x => x.SEG_ESTADO, map => map.MapFrom(dto => dto.seguroEstado))                
                .ForMember(x => x.ID_EXC_SEGURO, map => map.MapFrom(dto => dto.idExcepcionSeguro))                
                .ForMember(x => x.DPP_ID, map => map.MapFrom(dto => dto.departamentoId))                
                .ForMember(x => x.DPD_CODIGO, map => map.MapFrom(dto => dto.departamentoCodigo))                
                .ForMember(x => x.DPC_ID, map => map.MapFrom(dto => dto.ciudadId))                
                .ForMember(x => x.DPC_CODIGO, map => map.MapFrom(dto => dto.ciudadCodigo))                
                .ReverseMap();
            
            CreateMap<DatosLiquidacionDto, DatosLiquidacion>()
                .ForMember(x=>x.LIQ_ID, map =>map.MapFrom(dto => dto.IdLiquidacion))
                .ForMember(x=>x.LIQ_FECHA_CORTE, map =>map.MapFrom(dto => dto.FechaCorte))
                .ForMember(x=>x.LIQ_FECHA_PAGO, map =>map.MapFrom(dto => dto.FechaPago))
                .ForMember(x=>x.LIQ_FECHA_MODIFICACION, map =>map.MapFrom(dto => dto.FechaModificacion))
                .ForMember(x => x.LIQ_ESTADO, map => map.MapFrom(dto => dto.Estado))
                .ReverseMap();

            

        }
    }
}
