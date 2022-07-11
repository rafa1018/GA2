using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Domain.Core.Credito.WorkManager;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace GA2.Apis.GA2.Extensions
{
    /// <summary>
    /// Manejador de inyeccion de dependencias
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    public static class DIManager
    {
        /// <summary>
        /// Metodo que inyecta las dependencias del proyecto
        /// </summary>
        /// <param name="services">Proveedor de servicios</param>
        /// <returns>Proveedor de servicios</returns>
        internal static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {

            #region AutoMapper

            services.AddAutoMapper(typeof(IdentityMapper));
            services.AddAutoMapper(typeof(SerializedObjectMapper));
            services.AddAutoMapper(typeof(MapperNotification));
            services.AddAutoMapper(typeof(CatalogsMapper));
            services.AddAutoMapper(typeof(MapperParametrization));
            services.AddAutoMapper(typeof(MapperLock));
            services.AddAutoMapper(typeof(MapperMessage));
            services.AddAutoMapper(typeof(CarteraMapper));

            #endregion

            #region Main 

            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<ICryptoGA2, CryptoGA2>();
            services.AddTransient<IProviderRequestG2, ProviderRequestG2>();
            services.AddTransient<IIntegracionesGA2Bua, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2Vigia, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2WorkManager, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2Fenix, IntegracionesGA2>();
            services.AddTransient<IGestorTransUnionBusinessLogic, GestorTransUnionBusinessLogic>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region SignalR
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

            #endregion

            #region Domain

            services.AddTransient<ILogErrorBusinessLogic, LogErrorBusinessLogic>();
            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<IUsersBusinessLogic, UsersBusinessLogic>();
            services.AddTransient<IClientRequestProvider, ClientRequestProvider>();
            services.AddTransient<ICreditoBusinessLogic, CreditoBusinessLogic>();
            services.AddTransient<ICatalogosBusinessLogic, CatalogosBusinessLogic>();
            services.AddTransient<IParametrizacionBusinessLogic, ParametrizacionBusinessLogic>();
            services.AddTransient<IEstadoBusinessLogic, EstadoBusinessLogic>();
            services.AddTransient<IMovimientoBusinessLogic, MovimientoBusinessLogic>();
            services.AddTransient<IProductoBusinessLogic, ProductoBusinessLogic>();
            services.AddTransient<IBloqueoBusinessLogic, BloqueoBusinessLogic>();
            services.AddTransient<INotificacionBusinessLogic, NotificacionBusinessLogic>();
            services.AddTransient<IValidacionIdentidadBusinessLogic, ValidacionIdentidadBusinessLogic>();
            services.AddTransient<IGestorTransUnionBusinessLogic, GestorTransUnionBusinessLogic>();
            services.AddTransient<IGestorIdVisionBusinessLogic, GestorIdVisionBusinessLogic>();
            services.AddTransient<IGestorDocumentalBusinessLogic, GestorDocumentalBusinessLogic>();
            services.AddTransient<IEjemploDocumentos, EjemploDocumentos>();
            services.AddTransient<ICargaArchivoBusinessLogic, CargaArchivoBusinessLogic>();
            services.AddTransient<IDescomposicionArchivo, DescomposicionArchivo>();
            services.AddTransient<IDocumentoBusinessLogic, DocumentoBusinessLogic>();
            services.AddTransient<IIntegracionesGa2BuaBusinessLogic, IntegracionesGA2BuaBusinessLogic>();
            services.AddTransient<IIntegracionesGA2WorkManagerBusinessLogic, IntegracionesGA2WorkManagerBusinessLogic>();
            services.AddTransient<ICuentaBusinessLogic, CuentaBusinessLogic>();
            services.AddTransient<IVigiaBusinessLogic, VigiaBusinessLogic>();
            services.AddTransient<IIntegracionesGA2VgiaBusinessLogic, IntegracionesGA2VigiaBusinessLogic>();
            services.AddTransient<ICarteraBusinessLogic, CarteraBusinessLogic>();
            services.AddTransient<IFenixBusinessLogic, FenixBusinessLogic>();
            services.AddTransient<IIntegracionesGA2FenixBusinessLogic, IntegracionesGA2FenixBusinessLogic>();
            services.AddTransient<IIntegracionesGA2Haberes, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2HaberesBusinessLogic, IntegracionesGA2HaberesBusinessLogic>();
            services.AddTransient<IHaberesBusinessLogic, HaberesBusinessLogic>();
            services.AddTransient<ICesantiasBusinessLogic, CesantiasBusinessLogic>();
            services.AddTransient<ISolicitudBusinessLogic, SolicitudBusinessLogic>();
            services.AddTransient<IProcesoBusinessLogic, ProcesoBusinessLogic>();
            services.AddTransient<ICronogramaNovedadesBusinessLogic, CronogramaNovedadesBusinessLogic>();
            services.AddTransient<IMatriculasInmobiliariasLogic, MatriculasInmobilariasLogic>();
            services.AddTransient<IMatriculasInmobiliariasLogic, MatriculasInmobilariasLogic>();
            services.AddTransient<IEntidadesBusinessLogic,EntidadesBusinessLogic> ();
            services.AddTransient<IEmbargosBusinessLogic, EmbargosBusinessLogic>();
            services.AddTransient<IAuditoriaBusinessLogic, AuditoriaBusinessLogic>();
            services.AddTransient<ICuentasClientesBusinessLogic, CuentasClientesBusinessLogic>();
            
            services.AddTransient<IProspeccionBusinessLogic, ProspeccionBusinessLogic>();
            services.AddTransient<ICierreMensualBusinessLogic, CierreMensualBusinessLogic>();
            services.AddTransient<ICierreMensualRequestProvider, CierreMensualRequestProvider>();

            services.AddTransient<ICierreAnualBusinessLogic, CierreAnualBusinessLogic>();
            services.AddTransient<ICierreAnualRequestProvider, CierreAnualRequestProvider>();


            #endregion

            #region Inrfraestructure Repository

            services.AddTransient<ILogErrorRepository, LogErrorRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IBlobStorageGenericRepository, BlobStorageGenericRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<ICreditoRepository, CreditoRepository>();
            services.AddTransient<ICatalogosRepository, CatalogosRepository>();
            services.AddTransient<IParametrizacionRepository, ParametrizacionRepository>();
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IMovimientoRepository, MovimientoRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IParamCargueNominaRepository, ParamCargueNominaRepository>();
            services.AddTransient<IBloqueoRepository, BloqueoRepository>();
            services.AddTransient<IMensajeRepository, MensajeRepository>();
            services.AddTransient<INotificacionRepository, NotificacionRepository>();
            services.AddTransient<IValidacionIdentidadRepository, ValidacionIdentidadRepository>();
            services.AddTransient<ITransUnionRepository, TransUnionRepository>();
            services.AddTransient<IDocumentoCargaRepository, DocumentoCargaRepository>();
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<ICarteraRepository, CarteraRepository>();
            services.AddTransient<ITareaRepository, TareaRepository>();
            services.AddTransient<ICesantiasRepository, CesantiasRepository>();
            services.AddTransient<ISolicitudRepository, SolicitudRepository>();
            services.AddTransient<IProcesoRepository, ProcesoRepository>();
            services.AddTransient<ICronogramaRepository, CronogramaRepository>();
            services.AddTransient<IMatriculasInmobiliariasRepository, MatriculasInmobiliariasRepository>();
            services.AddTransient<IEntidadesRepository, EntidadesRepository>();
            services.AddTransient<IEmbargosRepository, EmbargosRepository>();
            services.AddTransient<IAuditoriaRepository, AuditoriaRepository>();
            services.AddTransient<ICuentasClientesRepository, CuentasClientesRepository>();
            services.AddTransient<ICierreMensualRepository, CierreMensualRepository>();
            services.AddTransient<ICierreAnualRepository, CierreAnualRepository>();



            #endregion

            return services;
        }
    }
}
