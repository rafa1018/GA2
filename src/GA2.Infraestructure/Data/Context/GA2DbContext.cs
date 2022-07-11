using GA2.Application.Dto;
using GA2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Contexto de base datos GA2
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/05/2021</date>
    public class GA2DbContext : DbContext
    {
        /// <summary>
        /// Tabla ActividadTramiteSolicitud
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/05/2021</date>
        public DbSet<ActividadTramiteSolicitud> ActividadTramiteSolicitudes { get; set; }
        /// <summary>
        /// Tabla CTG_CATEGORIA
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/05/2021</date>
        public DbSet<Domain.Entities.Categoria> Categorias { get; set; }
        /// <summary>
        /// Tabla DocumentosActRespuesta
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/05/2021</date>
        public DbSet<DocumentosActRespuesta> DocumentosActSolicitudes { get; set; }
        /// <summary>
        /// Tabla RespuestaFlujoDocumentos
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/05/2021</date>
        public DbSet<RespuestaFlujoDocumentos> PeticionesFlujoDocumentos { get; set; }
        /// <summary>
        /// Tabla RespuestaConsultaSolicitudCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<ConsultaSolicitudCreditoDto> ConsultasSolicitudCredito { get; set; }
        /// <summary>
        /// Tabla ActualizacionSolicCreditoRecomendacion
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoRecomendacionDto> ActualizacionesSolicCreditoRecomendacion { get; set; }

        /// Tabla ActualizacionSolicCreditoSeguro
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<ConsultaSolicitudCreditoDto> ActualizacionesSolicCreditoSeguro { get; set; }

        /// Tabla ConsultarSimulacionCliente
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SimulacionClienteDto> ConsultasSimulacionCliente { get; set; }

        /// Tabla CrearDocumentoSolicCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<ResponseDocumentoSolicCreditoDto> CreacionesDocumentoSolicCredito { get; set; }

        /// Tabla CrearSimulacionCliente
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<PlanillaSimulacionCreditoDto> CreacionesSimulacionCliente { get; set; }

        /// Tabla CrearSolicCreditoInfJuridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfJuridicaDto> CreacionesSolicCreditoInfJuridica { get; set; }

        /// Tabla CrearSolicCreditoInfJurInm
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfJurInmDto> CreacionesSolicCreditoInfJurInm { get; set; }

        /// Tabla CrearSolicCreditoInfTecnica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfTecnicaDto> CreacionesSolicCreditoInfTecnica { get; set; }

        /// Tabla CrearSolicCreditoInfJurInm
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfTecInmDto> CreacionesSolicCreditoInfTecInm { get; set; }

        /// Tabla ObtenerSolicCreditoBasica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<RespuestaCreditoBasicaDto> ObtencionesSolicCreditoBasica { get; set; }

        /// Tabla ObtenerSolicCreditoFinancieros
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<RespuestaCreditoFinancieroDto> ObtencionesSolicCreditoFinancieros { get; set; }

        /// Tabla ObtenerSolicCreditoInfJuridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfJuridicaDto> ObtencionesSolicCreditoInfJuridica { get; set; }

        /// Tabla ObtenerSolicCreditoInfJurInm
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>20/05/2021</date>
        public DbSet<SolicCreditoInfJurInmDto> ObtencionesSolicCreditoInfJurInm { get; set; }

        /// Tabla ObtenerComiteCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>25/05/2021</date>
        public DbSet<DatosComiteCreditoDto> ObtencionesComiteCredito { get; set; }

        /// Tabla AprobarComiteCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>25/05/2021</date>
        public DbSet<DatosComiteCreditoDto> AprobacionesComiteCredito { get; set; }

        /// Tabla ObtenerIntegranteComite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>25/05/2021</date>
        public DbSet<IntegranteComiteDto> ObtencionesIntegranteComite { get; set; }

        /// Tabla ObtenerIntegranteComite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>25/05/2021</date>
        public DbSet<TemaComiteDto> ObtencionesTemasComite { get; set; }

        /// Tabla ObtenerComiteCreditoIntegrante
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>25/05/2021</date>
        public DbSet<IntegrantePorComiteDto> ObtencionesComiteCreditoIntegrante { get; set; }

        /// Tabla CrearComiteCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/05/2021</date>
        public DbSet<DatosComiteCreditoDto> CreacionesComiteCredito { get; set; }

        /// Tabla CrearComiteCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/05/2021</date>
        public DbSet<ComiteIntegranteDto> CreacionesComiteCreditoIntegrante { get; set; }

        /// Tabla ObtenerComiteCreditoSolicitud
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/05/2021</date>
        public DbSet<SolicitudComiteDto> ObtenerComiteCreditoSolicitud { get; set; }

        /// Tabla CrearComiteCredito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/05/2021</date>
        public DbSet<TemaComiteCreditoDto> CreacionesComiteCreditoTemas { get; set; }

        /// Tabla CrearComiteCreditoSolicitud
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/05/2021</date>
        public DbSet<SolicitudComiteCreacionDto> CrearComiteCreditoSolicitud { get; set; }

        /// Tabla CTL_CATALOGOS
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Catalogo> ObtenerCatalogos { get; set; }
        /// Tabla ACC_ACTIVIDAD_ECONOMICA
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<ActividadEconomica> ObtenerActividadEconomica { get; set; }
        /// Tabla DPC_CIUDAD
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Ciudad> ObtenerCiudadPorDepartamento { get; set; }
        /// Tabla LTR_LETRA
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Abecedario> ObtenerAbecedario { get; set; }
        /// Tabla BS_BIS
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Bis> ObtenerBis { get; set; }
        /// Tabla CRD_CARDINALIDAD
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Cardinalidad> ObtenerCardinalidad { get; set; }
        /// Tabla TPC_TIPO_CALLE
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<TipoCalle> ObtenerTipoCalle { get; set; }
        /// Tabla ESA_ESTADO_ACTIVIDAD
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<EstadoActividad> ObtenerEstadoActividad { get; set; }
        /// Tabla TVV_TIPO_VIVIENDA
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<TipoVivienda> ObtenerTipoVivienda { get; set; }
        /// Tabla FRZ_FUERZA
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>21/05/2021</date>
        public DbSet<Domain.Entities.Fuerzas> ObtenerFuerza { get; set; }
        /// Tabla GRD_GRADO
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<Domain.Entities.Grado> ObtenerGrado { get; set; }
        /// Tabla DPP_PAIS
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<Domain.Entities.Pais> ObtenerPais { get; set; }
        /// Tabla PRF_PROFESION
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<Profesion> ObtenerProfesion { get; set; }
        /// Tabla TCR_TIPO_CREDITO
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<TipoCredito> ObtenerTipoCredito { get; set; }
        /// Tabla TCE_TIPO_CORREO
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<TipoCorreo> ObtenerTipoCorreo { get; set; }
        /// Tabla TID_TIPO_IDENTIFICACION
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<TipoIdentificacion> ObtenerTipoIdentificacion { get; set; }
        /// Tabla UEJ_UNIDADES_EJECUTORAS
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<UnidadEjecutora> ObtenerUnidadEjecutora { get; set; }
        /// Tabla TPT_TIPO_TELEFONO
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<TipoTelefono> ObtenerTipoTelefono { get; set; }
        /// Tabla MND_MONEDA
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/05/2021</date>
        public DbSet<TipoMoneda> ObtenerTipoMoneda { get; set; }

        /// <summary>
        /// Construnctor del contexto de base datos GA2
        /// </summary>
        /// <param name="options">Opciones de contexto</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/05/2021</date>
        public GA2DbContext(DbContextOptions<GA2DbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
