﻿using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICatalogosRepository
    {
        Task<TipoCredito> ActualizarTipoCredito(TipoCredito TipoCredito);
        Task<TipoVivienda> ActualizarTipoVivienda(TipoVivienda TipoVivienda);
        Task<TipoCredito> CrearTipoCredito(TipoCredito TipoCredito);
        Task<TipoVivienda> CrearTipoVivienda(TipoVivienda TipoVivienda);
        Task<TipoCredito> EliminarTipoCreditoPorid(string TipoCreditoid);
        Task<TipoVivienda> EliminarTipoViviendaPorid(string TipoViviendaid);
        Task<IEnumerable<ActividadEconomica>> ObtenerActividadesEconomicas();
        Task<IEnumerable<Catalogo>> ObtenerCatalogos();
        Task<IEnumerable<Categoria>> ObtenerCategorias();
        Task<IEnumerable<Ciudad>> ObtenerCiudades();
        Task<IEnumerable<Ciudad>> ObtenerCiudadesPorDepartamento(int Id);
        Task<IEnumerable<ClasificacionArchivo>> ObtenerClasificacionesArchivo();
        Task<IEnumerable<ConceptoNomina>> ObtenerConceptoNominaCat(ConceptoNomina concepto);
        Task<IEnumerable<Concepto>> ObtenerConceptos();
        Task<IEnumerable<ConceptoHomologado>> ObtenerConceptosHomologados();
        Task<IEnumerable<Departamento>> ObtenerDepartamentos();
        Task<IEnumerable<Abecedario>> ObtenerDireccionesAbecedario();
        Task<IEnumerable<Bis>> ObtenerDireccionesBis();
        Task<IEnumerable<Cardinalidad>> ObtenerDireccionesCardinal();
        Task<IEnumerable<TipoCalle>> ObtenerDireccionesTipos();
        Task<IEnumerable<EstadoActividad>> ObtenerEstadoActividad();
        Task<IEnumerable<EstadoCivil>> ObtenerEstadoCuentasCliente();
        Task<IEnumerable<CatalogoValor>> ObtenerEstadosCiviles();
        Task<IEnumerable<EstadoVivienda>> ObtenerEstadoVivienda();
        Task<IEnumerable<Fuerzas>> ObtenerFuerzas();
        Task<IEnumerable<Grado>> ObtenerGrados();
        Task<IEnumerable<Grado>> ObtenerGradosPorFuerzaCategoria(Grado grado);
        Task<IEnumerable<Pais>> ObtenerPaises();
        Task<IEnumerable<Profesion>> ObtenerProfesiones();
        Task<IEnumerable<TipoCredito>> ObtenerTipoCredito();
        Task<IEnumerable<CatalogoValor>> ObtenerTipoDeSexo();
        Task<IEnumerable<TipoCorreo>> ObtenerTiposCorreo();
        Task<IEnumerable<TipoVivienda>> ObtenerTiposDeVivienda();
        Task<IEnumerable<TipoIdentificacion>> ObtenerTiposIdentificacion();
        Task<IEnumerable<TipoMoneda>> ObtenerTiposMoneda();
        Task<IEnumerable<TipoTelefono>> ObtenerTiposTelefono();
        Task<IEnumerable<TiVivienda>> ObtenerTipoVivienda();
        Task<IEnumerable<UnidadEjecutora>> ObtenerUnidadesEjecutoras();
        Task<IEnumerable<CatalogoValor>> ObtenerValoresCatalogos();
        Task<IEnumerable<CatalogoValor>> ObtenerValoresCatalogosPorIdCatalogo(int catalogoId);
        Task<IEnumerable<DominiosCorreo>> ObtenerDominiosCorreo();
        Task<IEnumerable<TipoDireccion>> ObtenerTiposDireccion();
        Task<IEnumerable<TipoAbono>> ObtenerTipoAbono();
        Task<IEnumerable<TipoSubsidio>> ObtenerTipoSubsidio();
        Task<IEnumerable<AbonoUnico>> ObtenerAbonoUnico();
        Task<IEnumerable<TipoSolicitud>> ObtenerTipoSolicitud(int IdTipoActor);
        Task<IEnumerable<TipoModalidad>> ObtenerTipoModalidad(string IdTipoSolicitud);
        Task<IEnumerable<TipoSubModalidad>> ObtenerTipoSubModalidad(string IdTipoModalidad);
        Task<IEnumerable<EstadoCartera>> ObtenerEstadoCartera();
        Task<Departamento> ObtenerDepartamentoById(int dpd);
        Task<Ciudad> ObtenerCiudadById(int dpc);
        Task<IEnumerable<TipoCuenta>> ObtenerTipoCuenta();
        Task<IEnumerable<EntidadBancaria>> ObtenerEntidadBancaria();
        Task<IEnumerable<Formato>> ObtenerFormato();
        Task<IEnumerable<MedioDeEnvio>> ObtenerMediosDeEnvio();
        Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativa();
        Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativa entidad);
        Task<IEnumerable<ProgramaEducativo>> ObtenerProgramaEducativo(Guid idEntidad);
        Task<ProgramaEducativo> CrearProgramaEducativo(ProgramaEducativo programaEducativo);
        Task<IEnumerable<NivelEducativo>> ObtenerNivelEducativoCesantias(Guid idPrograma);
        Task<IEnumerable<EntidadSeguroEducativo>> ObtenerEntidadSeguroEducativo();
        Task<IEnumerable<TipoIdentificacion>> ObtenerDocumentoTipo();
        Task<TipoIdentificacion> CrearDocumentoTipo(TipoIdentificacion data);
        Task<TipoIdentificacion> ActualizarDocumentoTipo(TipoIdentificacion data);
        Task<Fuerzas> CrearFuerza(Fuerzas data);
        Task<Fuerzas> ActualizarFuerza(Fuerzas data);
        Task<CatalogoValor> CrearSexo(CatalogoValor data);
        Task<CatalogoValor> ActualizarSexo(CatalogoValor data);
        Task<EntidadEducativa> CrearEntidadEducativa(EntidadEducativa entidadEducativa);
        Task<EntidadEducativa> ActualizarEntidadEducativa(EntidadEducativa entidadEducativa);
        Task<EntidadEducativa> EliminarEntidadEducativaPorId(string EntidadEducativaId);
        Task<IEnumerable<SedeEntidadEducativa>> ObtenerSedesPorEntidadEducativa(string entidadEducativaId);
        Task<SedeEntidadEducativa> CrearSedeEntidadEducativa(SedeEntidadEducativa sedeEntidadEducativa);
        Task<SedeEntidadEducativa> EliminarSedeEntidadEducativaPorId(string sedeEntidadEducativaId);
        Task<IEnumerable<ListarProgramaEducativo>> ObtenerProgramaEducativoPorEntidad(Guid idEntidad);
        Task<ProgramaEducativo> EliminarProgramaEducativoPorId(string idProgramaEducativo);
        Task<ProgramaEducativo> ActualizarProgramaEducativo(ProgramaEducativo programaEducativo);
        Task<BloqueoEntidadEducativa> BloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa);
        Task<BloqueoEntidadEducativa> DesbloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa);
        Task<IEnumerable<BloqueoEntidadEducativa>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa);
        Task<IEnumerable<CuentaBancariaEntidadEducativa>> ObtenerCuentaBancariaPorEntidad(Guid idEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta);
        Task<Categoria> CrearCategoria(Categoria data);
        Task<Categoria> ActualizarCategoria(Categoria data);
        Task<IEnumerable<TipoAfiliacion>> ObtenerTiposAfiliacion();
        Task<IEnumerable<EstadoAfiliacion>> ObtenerEstadosAfiliacion();
        Task<IEnumerable<CampoCalidad>> ObtenerCampoCalidadAfiliacion();
        Task<IEnumerable<TipoAfiliacionProcedente>> ObtenerTiposAfiliacionProcedente();
        Task<IEnumerable<PorcentajeDescuento>> ObtenerPorcentajesDescuento();
        Task<IEnumerable<TipoCuentaC>> ObtenerTipoCuentaC();
        Task<IEnumerable<PersonasCargo>> ObtenerPersonasCargo();
        Task<IEnumerable<TipoContrato>> ObtenerTipoContrato();
        Task<IEnumerable<TipoViviendaPropia>> ObtenerTipoViviendaPropia();
        Task<IEnumerable<Estrato>> ObtenerEstrato();
        Task<IEnumerable<GrupoInconsistencia>> ListarGruposInconsistencia();
        Task<IEnumerable<TipoInconsistencia>> ObtenerInconsistencia(int GrupoInconsistencia);
        Task<IEnumerable<HerramientaInconsistencia>> ObtenerHerramientaInconsistencia();
        Task<IEnumerable<PuntosAtencionInconsistencia>> ObtenerPuntosAtencionInconsistencia();
        Task<IEnumerable<NivelAcademico>> ObtenerNivelAcademico();

        Task<IEnumerable<NivelAcademicoCatalogo>>  ObtenerNivelEducativo(); 
        Task<IEnumerable<ConceptoNomina>> ObtenerConceptoNomina();
        Task<IEnumerable<CausalBloqueo>> ObtenerCausalBloqueo();
        Task<IEnumerable<TipoSolicitudNovedadMatricula>> ObtenerTipoSolicitudNovedadMatricula();
        Task<IEnumerable<EstadoTareaSolicitud>> ObtenerEstadoTareaSolicitud();
    }
}