using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICarteraRepository
    {
        Task<IEnumerable<ProductoCliente>> ObtenerProductoCliente(int tipoIdentificacion, string identificacion);
        Task<InformacionCredito> ObtenerCreditoCartera(int request);
        Task<InformacionCredito> ActualizarCredito(InformacionCredito updateCredito);
        Task<AplicacionPago> AplicarPago(AplicacionPago aplicacionPago);
        Task<ParametrosAplicacionPagos> ObtenerParametrosAplicacionPagos();
        Task<AbonoExtra> ObtenerAbonoExtra(string identificacion);
        Task<ProductoCliente> EjecutarDesembolso(ProductoCliente producto);
        Task<ProductoCliente> PrepararEjecucionDesembolso(int tipoIdentificacion, string identificacion);
        Task<TasaSimulador> ActualizarTasasSimulacion(TasaSimulador tasaUpdate);
        Task<IEnumerable<TasaSimulador>> ObtenerTasasSimulador();
        Task<TasaSimulador> CrearTasasSimulacion(TasaSimulador tasaCreate); 
        Task<TasaSimulador> EliminarRegistroSimuladorPorId(TasaSimulador tasaDelete);
        Task<IEnumerable<TasaSimulador>> ConsultarTipoActorById( TasaSimulador consultaExcepcion);
        Task<IEnumerable<TipoActor>> ObtenerTipoActor();
        Task<ParametrosTasaActor> CrearTasaActor(ParametrosTasaActor actorCreate);
        Task<ParametrosTasaActor> ActualizarTasaSimuladorActor(ParametrosTasaActor actorUpdate);
        Task<ParametrosTasaActor> EliminarParametroSimuladorActor(ParametrosTasaActor actorDelete);
        Task<IEnumerable<UnidadesEjecutoras>> ObtenerUnidadesEjecutorasPorId(UnidadesEjecutoras consultaUnidadEjecutora);
        Task<UnidadesEjecutoras> CrearUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraCreate);
        Task<IEnumerable<UnidadesEjecutoras>> ConsultarUnidadEjecutora();
        Task<UnidadesEjecutoras> ActualizarUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraUpdate);
        Task<UnidadesEjecutoras> EliminarUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraDelete);
        Task<ParamGeneralesCreditoYCartera> ObtenerParamGeneralesCreditoYCartera();
        Task<ParamGeneralesCreditoYCartera> ActualizarParamGeneralesCreditoYCartera(ParamGeneralesCreditoYCartera paramCreditoYCarteraUpdate);
        Task<InformacionCredito> ObtenerCreditoCarteraByIdentificacion(string identificacion);
        Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerParametrosGeneralesPlazoCredito( );
        Task<ParamGeneralesExcepcionPlazo> ActualizarParametrosGeneralesPlazoCredito(ParamGeneralesExcepcionPlazo plazo);
        Task<ParamGeneralesExcepcionPlazo> CrearExcepcionPlazo(ParamGeneralesExcepcionPlazo plazoCreate);
        Task<ParamGeneralesExcepcionPlazo> EliminarExcepcionPlazo(ParamGeneralesExcepcionPlazo plazoDelete);
        Task<ParamGeneralesExcepcionPlazo> ActualizarExcepcionesPlazo(ParamGeneralesExcepcionPlazo excepcionUpdate);
        Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerExcepcionesPlazo(ParamGeneralesExcepcionPlazo getPlazo);
        Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerExcepcionPlazoPorUnidadEjecutora(ParamGeneralesExcepcionPlazo getPlazo);
        Task<ParamGeneralesExcepcionPlazo> CrearExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazo plazoCreate);
        Task<ParamGeneralesExcepcionPlazo> ActualizarExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazo plazoUpdate);
        Task<IEnumerable<ParamGeneralesSeguros>> ObtenerSeguroGeneral();
        Task<ParamGeneralesSeguros> ActualizarSeguroGeneral(ParamGeneralesSeguros seguroUpdate);
        Task<IEnumerable<ParamGeneralesSeguros>> ObtenerExcepSeguroPorMunicipio();
        Task<ParamGeneralesSeguros> CrearExcepcionPorMunicipio(ParamGeneralesSeguros seguroExcepcionCreate);
        Task<ParamGeneralesSeguros> ActualizarExcepSeguroPorMunicipio(ParamGeneralesSeguros seguroExcepcionUpdate);
        Task<ParamGeneralesSeguros> EliminarExcepcionSeguroPorMunicipio(ParamGeneralesSeguros seguroExcepcionDelete);
        Task<DatosLiquidacion> ObtenerLiquidacionGeneral();
        Task<DatosLiquidacion> ActualizarLiquidacionGeneral(DatosLiquidacion request);
        Task<IEnumerable<AplicacionPago>> ObtenerAplicacionPago(Guid request);
    }
}