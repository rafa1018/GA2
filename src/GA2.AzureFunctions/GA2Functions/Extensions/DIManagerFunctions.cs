using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Mappers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace GA2.GA2Functions.Extensions
{
    public static class DIManagerFunctions
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
            services.AddAutoMapper(typeof(BpmProfile));

            #endregion

            #region Main 

            services.AddTransient<ITokenClaims, TokenClaims>();
            services.AddTransient<ICryptoGA2, CryptoGA2>();
            services.AddTransient<IProviderRequestG2, ProviderRequestG2>();
            services.AddTransient<IIntegracionesGA2Bua, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2Vigia, IntegracionesGA2>();
            services.AddTransient<IIntegracionesGA2WorkManager, IntegracionesGA2>();



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
            services.AddTransient<IEjemploDocumentos, EjemploDocumentos>();
            services.AddTransient<ICargaArchivoBusinessLogic, CargaArchivoBusinessLogic>();
            services.AddTransient<IDescomposicionArchivo, DescomposicionArchivo>();
            services.AddTransient<IDocumentoBusinessLogic, DocumentoBusinessLogic>();
            services.AddTransient<IIntegracionesGa2BuaBusinessLogic, IntegracionesGA2BuaBusinessLogic>();
            services.AddTransient<IIntegracionesGA2VgiaBusinessLogic, IntegracionesGA2VigiaBusinessLogic>();
            services.AddTransient<IIntegracionesGA2WorkManagerBusinessLogic, IntegracionesGA2WorkManagerBusinessLogic>();
            services.AddTransient<ICuentaBusinessLogic, CuentaBusinessLogic>();

            services.AddTransient<IAnadidosBusinessLogic, AnadidosBusinessLogic>();
            services.AddTransient<IProcesoBusinessLogic, ProcesoBusinessLogic>();
            services.AddTransient<IRestriccionesBusinessLogic, RestriccionesBusinessLogic>();
            services.AddTransient<IReglaBusinessLogic, ReglaBusinessLogic>();
            services.AddTransient<ITareaBusinessLogic, TareaBusinessLogic>();

            services.AddTransient<IRolBusinessLogic, RolBusinessLogic>();
            services.AddTransient<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddTransient<IFormularioBusinessLogic, FormularioBusinessLogic>();
            services.AddTransient<ILoginRequestProvider, LoginRequestProvider>();

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

            services.AddTransient<IAnadidosRepository, AnadidosRepository>();
            services.AddTransient<IProcesoRepository, ProcesoRepository>();
            services.AddTransient<IReglasRepository, ReglasRepository>();
            services.AddTransient<IRestriccionesRepository, RestriccionesRepository>();
            services.AddTransient<ITareaRepository, TareaRepository>();

            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<ILoginGA2Repository, LoginGA2Repository>();
            services.AddTransient<IFormularioRepository, FormularioRepository>();

            #endregion
            return services;
        }
    }
}
    
