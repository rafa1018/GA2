using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICarteraBusinessLogic
    {
        Task<Response<IEnumerable<ProductoClienteDto>>> ObtenerProductoCliente(SolicitudProductoPorClienteDto request);
        Task<Response<InformacionCreditoDto>> ObtenerCreditoCartera(int request);
        Task<Response<AplicacionPagoDto>> AplicarPago(PagoAplicarDto request);
        Task<Response<ParametrosAplicacionPagosDto>> ObtenerParametrosAplicacionPagos();
        Task<Response<ProductoClienteDto>> EjecutarDesembolso(RequestEjecucionDesembolsoDto request);
        Task<Response<ProductoClienteDto>> PrepararEjecucionDesembolso(SolicitudProductoPorClienteDto request);
        Task<Response<TasaSimuladorDto>> ActualizarTasasSimulacion(TasaSimuladorDto tasas);
        Task<Response<IEnumerable<TasaSimuladorDto>>> ObtenerTasasSimulador();
        Task<Response<IEnumerable<AplicacionPagoDto>>> ObtenerAplicacionPago(Guid request);
        Task<Response<TasaSimuladorDto>> CrearTasasSimulacion(TasaSimuladorDto tasas);
        Task<Response<TasaSimuladorDto>> EliminarRegistroSimuladorPorId(TasaSimuladorDto tasas);
        Task<Response<IEnumerable<TasaSimuladorDto>>> ConsultarTipoActorById(TasaSimuladorDto tasas);
        Task<Response<IEnumerable<TipoActorDto>>> ObtenerTipoActor();
        Task<Response<ParametrosTasaActorDto>> CrearTasaActor(ParametrosTasaActorDto actores);
        Task<Response<ParametrosTasaActorDto>> ActualizarTasaSimuladorActor(ParametrosTasaActorDto actores);
        Task<Response<ParametrosTasaActorDto>> EliminarParametroSimuladorActor(ParametrosTasaActorDto actores);
        Task<ActionResult> CargaMasivaLeasing(IFormFile request);
        Task<Response<DatosLiquidacionDto>> ObtenerLiquidacionGeneral();
        Task<Response<DatosLiquidacionDto>> ActualizarLiquidacionGeneral(DatosLiquidacionDto request);
        Task<Response<IEnumerable<UnidadesEjecutorasDto>>> ObtenerUnidadesEjecutorasPorId(UnidadesEjecutorasDto unidades);
        Task<Response<UnidadesEjecutorasDto>> CrearUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidades);
        Task<Response<IEnumerable<UnidadesEjecutorasDto>>> ConsultarUnidadEjecutora();
        Task<Response<UnidadesEjecutorasDto>> ActualizarUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidades);
        Task<Response<UnidadesEjecutorasDto>> EliminarUnidadEjecutoraSimulador(UnidadesEjecutorasDto unidades);
        Task<Response<ParamGeneralesCreditoYCarteraDto>> ObtenerParamGeneralesCreditoYCartera();
        Task<Response<ParamGeneralesCreditoYCarteraDto>> ActualizarParamGeneralesCreditoYCartera(ParamGeneralesCreditoYCarteraDto parametros);
        Task<Response<List<AplicacionPagoDto>>> CargarArchivoAplicacionPagoMasivo(IFormFile request, int unidadEjecutora);
        Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerParametrosGeneralesPlazoCredito();
        Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarParametrosGeneralesPlazoCredito(ParamGeneralesExcepcionPlazoDto plazos);
        Task<Response<ParamGeneralesExcepcionPlazoDto>> CrearExcepcionPlazo(ParamGeneralesExcepcionPlazoDto plazoCreate);
        Task<Response<ParamGeneralesExcepcionPlazoDto>> EliminarExcepcionPlazo(ParamGeneralesExcepcionPlazoDto plazoDelete);
        Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarExcepcionesPlazo(ParamGeneralesExcepcionPlazoDto plazos);
        Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerExcepcionesPlazo(ParamGeneralesExcepcionPlazoDto getPlazo);
        Task<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>> ObtenerExcepcionPlazoPorUnidadEjecutora(ParamGeneralesExcepcionPlazoDto getPlazo);
        Task<Response<ParamGeneralesExcepcionPlazoDto>> CrearExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazoDto plazoCreate);
        Task<Response<ParamGeneralesExcepcionPlazoDto>> ActualizarExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazoDto plazoUpdate);
        Task<Response<IEnumerable<ParamGeneralesSegurosDto>>> ObtenerSeguroGeneral();
        Task<Response<ParamGeneralesSegurosDto>> ActualizarSeguroGeneral(ParamGeneralesSegurosDto seguroUpdate);
        Task<Response<IEnumerable<ParamGeneralesSegurosDto>>> ObtenerExcepSeguroPorMunicipio();
        Task<Response<ParamGeneralesSegurosDto>> CrearExcepcionPorMunicipio(ParamGeneralesSegurosDto excepcionCreate);
        Task<Response<ParamGeneralesSegurosDto>> ActualizarExcepSeguroPorMunicipio(ParamGeneralesSegurosDto excepcionUpdate);
        Task<Response<ParamGeneralesSegurosDto>> EliminarExcepcionSeguroPorMunicipio(ParamGeneralesSegurosDto excepcionDelete);
    }
}