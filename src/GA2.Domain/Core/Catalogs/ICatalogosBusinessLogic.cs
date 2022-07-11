using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICatalogosBusinessLogic
    {
        Task<Response<IEnumerable<ActividadEconomicaDto>>> ObtenerActividadesEconomicas();
        Task<Response<IEnumerable<CatalogoDto>>> ObtenerCatalogosAsync();
        Task<Response<IEnumerable<CategoriaDto>>> ObtenerCategorias();
        Task<Response<IEnumerable<CiudadDto>>> ObtenerCiudades();
        Task<Response<IEnumerable<CiudadDto>>> ObtenerCiudadesPorDepartamento(int Id);
        Task<Response<IEnumerable<DepartamentoDto>>> ObtenerDepartamentos();
        Task<Response<IEnumerable<AbecedarioDto>>> ObtenerDireccionesAbecedario();
        Task<Response<IEnumerable<AbonoUnicoDto>>> ObtenerAbonoUnico();
        Task<Response<IEnumerable<CardinalidadDto>>> ObtenerDireccionesCardinal();
        Task<Response<IEnumerable<BisDto>>> ObtenerDireccionesBis();
        Task<Response<IEnumerable<TipoCalleDto>>> ObtenerDireccionesTipos();
        Task<Response<IEnumerable<EstadoCivilDto>>> ObtenerEstadosCiviles();
        Task<ActionResult<Response<CategoriaDto>>> ActualizarCategoria(CategoriaDto request);
        Task<Response<IEnumerable<FuerzasDto>>> ObtenerFuerzas();
        Task<Response<CategoriaDto>> CrearCategoria(CategoriaDto request);
        Task<Response<IEnumerable<GradoDto>>> ObtenerGrados();
        Task<Response<IEnumerable<GradoDto>>> ObtenerGradosPorFuerzaCategoria(GradoDto grado);
        Task<Response<IEnumerable<ConceptoNominaDto>>> ObtenerConceptoNomina();
        Task<Response<IEnumerable<ConceptoNominaDto>>> ObtenerConceptoNominaCat(ConceptoNominaDto concepto);
        Task<Response<TipoIdentificacionDto>> ActualizarDocumentoTipo(TipoIdentificacionDto request);
        Task<Response<IEnumerable<EstratoDto>>> ObtenerEstrato();
        Task<Response<IEnumerable<NivelAcademicoDto>>> ObtenerNivelAcademico();
        Task<Response<IEnumerable<PersonasCargoDto>>> ObtenerPersonasCargo();
        Task<Response<IEnumerable<TipoContratoDto>>> ObtenerTipoContrato();
        Task<Response<IEnumerable<TipoViviendaPropiaDto>>> ObtenerTipoViviendaPropia();
        Task<Response<SexoDto>> ActualizarSexo(SexoDto request);
        Task<Response<FuerzasDto>> ActualizarFuerza(FuerzasDto request);
        Task<Response<SexoDto>> CrearSexo(SexoDto request);
        Task<Response<FuerzasDto>> CrearFuerza(FuerzasDto request);
        Task<Response<IEnumerable<PaisDto>>> ObtenerPaises();
        Task<Response<IEnumerable<ProfesionDto>>> ObtenerProfesiones();
        Task<Response<TipoIdentificacionDto>> CrearDocumentoTipo(TipoIdentificacionDto request);
        Task<Response<IEnumerable<SexoDto>>> ObtenerTipoDeSexo();
        Task<Response<IEnumerable<TipoViviendaDto>>> ObtenerTiposDeVivienda();
        Task<Response<IEnumerable<TipoIdentificacionDto>>> ObtenerTiposIdentificacion();
        Task<Response<IEnumerable<TipoIdentificacionDto>>> ObtenerDocumentoTipo();
        Task<Response<IEnumerable<UnidadEjecutoraDto>>> ObtenerUnidadesEjecutoras();
        Task<Response<IEnumerable<CatalogoValorDto>>> ObtenerValoresCatalogos();
        Task<Response<IEnumerable<CatalogoValorDto>>> ObtenerValoresCatalogosPorIdCatalogo(int catalogoId);
        Task<Response<IEnumerable<TipoSubsidioDto>>> ObtenerTipoSubsidio();
        Task<Response<IEnumerable<TipoAbonoDto>>> ObtenerTipoAbono();
        Task<Response<IEnumerable<TipoCreditoDto>>> ObtenerTipoCredito();
        Task<Response<IEnumerable<TiViviendaDto>>> ObtenerTipoVivienda();
        Task<Response<IEnumerable<EstadoViviendaDto>>> ObtenerEstadoVivienda();
        Task<Response<IEnumerable<EstadoActividadDto>>> ObtenerEstadoActividad();
        Task<Response<TipoViviendaDto>> CrearTipoVivienda(TipoViviendaDto TipoVivienda);
        Task<Response<TipoViviendaDto>> ActualizarTipoVivienda(TipoViviendaDto TipoVivienda);
        Task<Response<TipoViviendaDto>> EliminarTipoViviendaPorid(string TipoViviendaId);
        Task<Response<TipoCreditoDto>> CrearTipoCredito(TipoCreditoDto TipoCredito);
        Task<Response<TipoCreditoDto>> ActualizarTipoCredito(TipoCreditoDto TipoCredito);
        Task<Response<TipoCreditoDto>> EliminarTipoCreditoPorid(string TipoCreditoId);
        Task<Response<IEnumerable<TipoCorreoDto>>> ObtenerTiposCorreo();
        Task<Response<IEnumerable<TipoTelefonoDto>>> ObtenerTiposTelefono();
        Task<Response<IEnumerable<TipoMonedaDto>>> ObtenerTiposMoneda();
        Task<Response<IEnumerable<DominiosCorreoDto>>> ObtenerDominiosCorreo();
        Task<Response<IEnumerable<TipoDireccionDto>>> ObtenerTiposDireccion();

        /// <summary>
        /// Obtener tipo de solicitud
        /// </summary>
        /// <param name="IdTipoActor">Filtro tipo actor</param>
        /// <returns>Lista de tipos de solicitud</returns>
        Task<Response<IEnumerable<TipoSolicitudDto>>> ObtenerTiposSolicitud(int IdTipoActor);

        /// <summary>
        /// Obtener tipo de modalidad
        /// </summary>
        /// <param name="IdTipoSolicitud"></param>
        /// <returns>Lista de tipos de modalidad</returns>
        Task<Response<IEnumerable<TipoModalidadDto>>> ObtenerTiposModalidad(string IdTipoSolicitud);

        /// <summary>
        /// Obtener tipo de submodalidad
        /// </summary>
        /// <param name="IdTipoModalidad"></param>
        /// <returns>Lista de tipos de submodalidad</returns>
        Task<Response<IEnumerable<TipoSubModalidadDto>>> ObtenerTiposSubModalidad(string IdTipoModalidad);
        Task<Response<IEnumerable<EstadoCarteraDto>>> ObtenerEstadoCartera();

        /// <summary>
        /// Obtener todos los tipos de cuenta
        /// </summary>
        /// <returns></returns>
        Task<Response<IEnumerable<TipoCuentaDto>>> ObtenerTipoCuenta();
        Task<Response<IEnumerable<EntidadBancariaDto>>> ObtenerEntidadBancaria();
        Task<Response<IEnumerable<FormatoDto>>> ObtenerFormato();
        Task<Response<IEnumerable<MedioDeEnvioDto>>> ObtenerMediosDeEnvio();

        #region EntidadEducativa
        Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativa();
        Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativaDto entidad);
        Task<Response<EntidadEducativaDto>> CrearEntidadEducativa(EntidadEducativaDto EntidadEducativa);
        Task<Response<EntidadEducativaDto>> ActualizarEntidadEducativa(EntidadEducativaDto EntidadEducativa);
        Task<Response<EntidadEducativaDto>> EliminarEntidadEducativaPorId(string idEntidadEducativa);
        Task<Response<IEnumerable<SedeEntidadEducativaDto>>> ObtenerSedesPorEntidadEducativa(string idEntidadEducativa);
        Task<Response<SedeEntidadEducativaDto>> CrearSedeEntidadEducativa(SedeEntidadEducativaDto sedeEntidadEducativa);
        Task<Response<SedeEntidadEducativaDto>> EliminarSedesEntidadEducativaPorId(string idSedeEntidadEducativa);
        Task<Response<BloqueoEntidadEducativaDto>> BloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto);
        Task<Response<BloqueoEntidadEducativaDto>> DesbloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto);
        Task<Response<IEnumerable<BloqueoEntidadEducativaDto>>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa);
        Task<Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>> ObtenerCuentaBancariaPorEntidad(Guid idEntidad);
        Task<Response<CuentaBancariaEntidadEducativaDto>> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativa);
        Task<Response<CuentaBancariaEntidadEducativaDto>> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativaDto);
        Task<Response<CuentaBancariaEntidadEducativaDto>> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta);

        #endregion EntidadEducativa


        /// <s
        /// Obtener programa educativo
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>Lista de programas educativos</returns>
        Task<Response<IEnumerable<ProgramaEducativoDto>>> ObtenerProgramaEducativo(Guid idEntidad);
        Task<Response<ProgramaEducativoDto>> CrearProgramaEducativo(ProgramaEducativoDto programaEducativo);

        /// <summary>
        /// Obtener nivel educativo
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <returns>Lista de niveles educativos</returns>
        Task<Response<IEnumerable<NivelEducativoDto>>> ObtenerNivelEducativoCesantias(Guid idPrograma);
        Task<Response<IEnumerable<EntidadSeguroEducativoDto>>> ObtenerEntidadSeguroEducativo();
        Task<Response<IEnumerable<ListarProgramaEducativoDto>>> ObtenerProgramaEducativoPorEntidad(Guid idEntidad);
        Task<Response<ProgramaEducativoDto>> EliminarProgramaEducativoPorId(string idProgramaEducativo);
        Task<Response<ProgramaEducativoDto>> ActualizarProgramaEducativo(ProgramaEducativoDto ProgramaEducativo);
        Task<Response<IEnumerable<TipoAfiliacionDto>>> ObtenerTiposAfiliacion();
        Task<Response<IEnumerable<EstadoAfiliacionDto>>> ObtenerEstadosAfiliacion();
        Task<Response<IEnumerable<CampoCalidadDto>>> ObtenerCampoCalidadAfiliacion();
        Task<Response<IEnumerable<TipoAfiliacionProcedenteDto>>> ObtenerTipoAfiliacionProcedente();
        Task<Response<IEnumerable<PorcentajeDescuentoDto>>> ObtenerPorcentajesDescuento();
        Task<Response<IEnumerable<GrupoInconsistenciaDto>>> ListarGruposInconsistencia();
        Task<Response<IEnumerable<TipoInconsistenciaDto>>> ObtenerInconsistencias(int GrupoInconsistencia);
        Task<Response<IEnumerable<HerramientaInconsistenciaDto>>> ObtenerHerramientaInconsistencia();
        Task<Response<IEnumerable<PuntosAtencionInconsistenciaDto>>> ObtenerPuntosAtencionInconsistencia();
        Task<Response<IEnumerable<CausalBloqueoDto>>> ObtenerCausalBloqueo();
        Task<Response<IEnumerable<TipoSolicitudNovedadMatriculaDto>>> ObtenerTipoSolicitudNovedadMatricula();

        Task<Response<IEnumerable<TipoCuentaCDto>>> ObtenerTipoCuentaC();
        Task<Response<IEnumerable<EstadoTareaSolicitudDto>>> ObtenerEstadoTareaSolicitud();
    }
}