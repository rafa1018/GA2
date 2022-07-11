using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Logica
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    /// </summary>
    /// 
    public class SolicitudRepository : DapperGenerycRepository, ISolicitudRepository
    {
        public SolicitudRepository(IConfiguration configuration) : base(configuration) { }


        /// <summary>
        /// Obtiene tramite solicitud
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<ObtenerTramiteSolicitud> CrearSolicitud(CrearSolicitud crearSolicitud)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.clienteId), crearSolicitud.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.creadoPor), crearSolicitud.SOL_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.cuentaId), crearSolicitud.CTA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.tipoSubModalidadId), crearSolicitud.TPS_SUB_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.tareaId), crearSolicitud.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.solEstadoSolicitud), crearSolicitud.SOL_ESTADO_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.stlEstadoSolicitud), crearSolicitud.STL_ESTADO_SOLICITUD);


            ObtenerTramiteSolicitud response = new ObtenerTramiteSolicitud();
            response = await GetAsyncFirst<ObtenerTramiteSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<ObtenerTramiteSolicitud> ConsultarExisteSolicitud(ConsultarSolicitud consultareSolicitudDto) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaSolicitudParameters.clienteId), consultareSolicitudDto.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaSolicitudParameters.tipoSubModalidadId), consultareSolicitudDto.TPS_SUB_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaSolicitudParameters.solEstadoAnulado), consultareSolicitudDto.SOL_ESTADO_ANULADO);

            ObtenerTramiteSolicitud response = new ObtenerTramiteSolicitud();
            response = await GetAsyncFirst<ObtenerTramiteSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<RespuestaTerceroApoderado> ConsultarTerceroRazonSocial(string numeroDocumento)
        {
            RespuestaTerceroApoderado solicitudTerceroApoderado = new RespuestaTerceroApoderado();
            solicitudTerceroApoderado.TER_NUMERO_DOCUMENTO = numeroDocumento;

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.NumeroDocumento), solicitudTerceroApoderado.TER_NUMERO_DOCUMENTO);

            RespuestaTerceroApoderado response = new RespuestaTerceroApoderado();
            response = await GetAsyncFirst<RespuestaTerceroApoderado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        // Consultar propietarios entre solicitudes para integridad de datos, provisional mientras se fusiona tabla props con terceros.
        public async Task<SolicitudPropietario> ConsultarPropietarioIntegridad(string numeroIdentificacion)
        {
            SolicitudPropietario solicitudPropietario = new SolicitudPropietario();
            solicitudPropietario.PRP_NUMERO_IDENTIFICACION = numeroIdentificacion;

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.NumeroIdentificacion), solicitudPropietario.PRP_NUMERO_IDENTIFICACION);

            SolicitudPropietario response = new SolicitudPropietario();
            response = await GetAsyncFirst<SolicitudPropietario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }


        /// <summary>
        /// Método encargado de crear la matrícula de solicitud de vivienda 
        /// </summary>
        /// <param name="solicitudMatricula"></param>
        /// <returns></returns>
        public async Task<SolicitudMatricula> InsertarSolicitudMatricula(SolicitudMatricula solicitudMatricula)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.SolicitudId), solicitudMatricula.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.NumeroMatricula), solicitudMatricula.MAI_NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.FechaRegistro), solicitudMatricula.MAI_FECHA_REGISTRO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.Direccion), solicitudMatricula.MAI_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.CiudadId), solicitudMatricula.DPC_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.Principal), solicitudMatricula.MAI_PRINCIPAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudMatriculaParameters.CreadoPor), solicitudMatricula.CREATEDO_POR);


            SolicitudMatricula response = new SolicitudMatricula();
            response = await GetAsyncFirst<SolicitudMatricula>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el propietario de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudPropietario"></param>
        /// <returns></returns>
        public async Task<SolicitudPropietario> InsertarSolicitudPropietario(SolicitudPropietario solicitudPropietario)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.SolicitudId), solicitudPropietario.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.TipoIdentificacion), solicitudPropietario.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.RazonSocial), solicitudPropietario.PRP_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.NumeroIdentificacion), solicitudPropietario.PRP_NUMERO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioParameters.CreadoPor), solicitudPropietario.CREATEDO_POR);


            SolicitudPropietario response = new SolicitudPropietario();
            response = await GetAsyncFirst<SolicitudPropietario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el apoderado de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudApoderado"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroApoderado> InsertarSolicitudTerceroApoderado(SolicitudTerceroApoderado solicitudApoderado)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.SolicitudId), solicitudApoderado.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.TipoIdentificacion), solicitudApoderado.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.NumeroDocumento), solicitudApoderado.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.RazonSocial), solicitudApoderado.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.CreadoPor), solicitudApoderado.CREATEDO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.TipoTercero), solicitudApoderado.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.EsAutorizado), solicitudApoderado.TER_ESAUTORIZADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.Parentesco), solicitudApoderado.TER_PARENTESCO);


            SolicitudTerceroApoderado response = new SolicitudTerceroApoderado();
            response = await GetAsyncFirst<SolicitudTerceroApoderado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el beneficiario de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudBeneficiario"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroBeneficiario> InsertarSolicitudTerceroBeneficiario(SolicitudTerceroBeneficiario solicitudBeneficiario)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.SolicitudId), solicitudBeneficiario.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.TipoIdentificacion), solicitudBeneficiario.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.NumeroDocumento), solicitudBeneficiario.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.RazonSocial), solicitudBeneficiario.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.Entidad), solicitudBeneficiario.ENT_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.TipoCuenta), solicitudBeneficiario.TER_TIPO_CUENTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.NumeroCuenta), solicitudBeneficiario.TER_NUMERO_CUENTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.CreadoPor), solicitudBeneficiario.CREATEDO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.TipoTercero), solicitudBeneficiario.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.ValorRetirarDos), solicitudBeneficiario.TER_VALOR_RETIRAR);


            SolicitudTerceroBeneficiario response = new SolicitudTerceroBeneficiario();
            response = await GetAsyncFirst<SolicitudTerceroBeneficiario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el constructor de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudConstructor"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroConstructor> InsertarSolicitudTerceroConstructor(SolicitudTerceroConstructor solicitudConstructor)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.SolicitudId), solicitudConstructor.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.TipoIdentificacion), solicitudConstructor.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.NumeroDocumento), solicitudConstructor.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.RazonSocial), solicitudConstructor.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.NumeroLicencia), solicitudConstructor.TER_NUMERO_LICENCIA_CONSTRUCCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.CreadoPor), solicitudConstructor.CREATEDO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroConstructorParameters.TipoTercero), solicitudConstructor.TER_TIPO_TERCERO_FK);

            SolicitudTerceroConstructor response = new SolicitudTerceroConstructor();
            response = await GetAsyncFirst<SolicitudTerceroConstructor>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el constructor de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudVendedor"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroVendedor> InsertarSolicitudTerceroVendedor(SolicitudTerceroVendedor solicitudVendedor)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.SolicitudId), solicitudVendedor.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.TipoIdentificacion), solicitudVendedor.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.NumeroDocumento), solicitudVendedor.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.RazonSocial), solicitudVendedor.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.Direccion), solicitudVendedor.TER_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.Ciudad), solicitudVendedor.DPC_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.CorreoElectronico), solicitudVendedor.TER_CORREO_ELECTRONICO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.Telefono), solicitudVendedor.TER_TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.CreadoPor), solicitudVendedor.CREATEDO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroVendedorParameters.TipoTercero), solicitudVendedor.TER_TIPO_TERCERO_FK);

            SolicitudTerceroVendedor response = new SolicitudTerceroVendedor();
            response = await GetAsyncFirst<SolicitudTerceroVendedor>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de insertar archivos de solicitud
        /// </summary>
        /// <param name="insertarArchivo"></param>
        /// <returns></returns>
        public async Task<InsertarArchivo> InsertarArchivoPorSolicitudTarea(InsertarArchivo insertarArchivo)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.NombreArchivo), insertarArchivo.AST_NOMBRE_ARCHIVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.RutaArchivo), insertarArchivo.AST_RUTA_STORAGE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.ExtensionArchivo), insertarArchivo.AST_EXTENSION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.Solicitud), insertarArchivo.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.Parametrizacion), insertarArchivo.PAM_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.CreadoPor), insertarArchivo.AST_CREATEDOPOR);

            InsertarArchivo response = new InsertarArchivo();
            response = await GetAsyncFirst<InsertarArchivo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Método encargado de crear el autorizado de solicitud de vivienda
        /// </summary>
        /// <param name="solicitudAutorizado"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroAutorizado> InsertarSolicitudTerceroAutorizado(SolicitudTerceroAutorizado solicitudAutorizado)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroAutorizadoParameters.SolicitudId), solicitudAutorizado.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroAutorizadoParameters.TipoIdentificacion), solicitudAutorizado.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroAutorizadoParameters.NumeroDocumento), solicitudAutorizado.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroAutorizadoParameters.RazonSocial), solicitudAutorizado.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroAutorizadoParameters.CreadoPor), solicitudAutorizado.CREATEDO_POR);


            SolicitudTerceroAutorizado response = new SolicitudTerceroAutorizado();
            response = await GetAsyncFirst<SolicitudTerceroAutorizado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> ActualizarSolicitudTarea(ActualizarSolicitudTarea actualizarSolicitudTarea) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaId), actualizarSolicitudTarea.SLT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaEstadoId), actualizarSolicitudTarea.SLT_ESTADO_SOLICITUD);
          
            bool response = new bool();
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<RespuestaMatricula>> ConsultarSolicitudMatricula(Guid solicitudId) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudMatriculaParameters.SolicitudId), solicitudId);

            IEnumerable<RespuestaMatricula> response;
            response = await GetAsyncList<RespuestaMatricula>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }


        public async Task<IEnumerable<RespuestaPropietario>> ConsultarSolicitudPropietario(Guid solicitudId) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudMatriculaParameters.SolicitudId), solicitudId);

            IEnumerable<RespuestaPropietario> response;
            response = await GetAsyncList<RespuestaPropietario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }


        public async Task<IEnumerable<RespuestaTerceroVendedor>> ConsultarTerceroVendedor(Guid solicitudId, int tipoTercero) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.TipoTercero), tipoTercero);

            IEnumerable<RespuestaTerceroVendedor> response;
            response = await GetAsyncList<RespuestaTerceroVendedor>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<RespuestaTerceroBeneficiario>> ConsultarTerceroBeneficiario(Guid solicitudId, int tipoTercero) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioParameters.TipoTercero), tipoTercero);

            IEnumerable<RespuestaTerceroBeneficiario> response;
            response = await GetAsyncList<RespuestaTerceroBeneficiario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<RespuestaTerceroApoderado>> ConsultarTerceroApoderado(Guid solicitudId, int tipoTercero) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroApoderadoParameters.TipoTercero), tipoTercero);

            IEnumerable<RespuestaTerceroApoderado> response;
            response = await GetAsyncList<RespuestaTerceroApoderado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<RespuestaTerceroBeneficiarioEstudio>> ConsultarTerceroBeneficiarioEstudio(Guid solicitudId, int tipoTercero)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.TipoTerceroBeneficiarioEstudioId), tipoTercero);

            IEnumerable<RespuestaTerceroBeneficiarioEstudio> response;
            response = await GetAsyncList<RespuestaTerceroBeneficiarioEstudio>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<RespuestaTerceroEntidadEducativa> ConsultarTerceroEntidadEducativa(Guid solicitudId, int tipoTercero)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.TipoTerceroEntidadEducativa), tipoTercero);

            RespuestaTerceroEntidadEducativa response;
            response = await GetAsyncFirst<RespuestaTerceroEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<RespuestaTerceroEntidadSeguroEducativo> ConsultarTerceroEntidadSeguroEducativo(Guid solicitudId, int tipoTercero)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.TipoTerceroEntidadSeguroId), tipoTercero);

            RespuestaTerceroEntidadSeguroEducativo response;
            response = await GetAsyncFirst<RespuestaTerceroEntidadSeguroEducativo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<RespuestaTerceroTenedorAcciones> ConsultarTerceroTenedorAcciones(Guid solicitudId, int tipoTercero)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.SolicitudId), solicitudId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.TipoTercero), tipoTercero);

            RespuestaTerceroTenedorAcciones response;
            response = await GetAsyncFirst<RespuestaTerceroTenedorAcciones>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <param name="solicitudPropietarioMatricula"></param>
        /// <returns></returns>
        public async Task<SolicitudPropietarioMatricula> InsertarSolicitudPropietarioMatricula(SolicitudPropietarioMatricula solicitudPropietarioMatricula)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioMatriculaParameters.PropietarioId), solicitudPropietarioMatricula.PRP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioMatriculaParameters.MatriculaId), solicitudPropietarioMatricula.MAI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudPropietarioMatriculaParameters.CreadoPor), solicitudPropietarioMatricula.PMA_CREATEDOPOR);


            SolicitudPropietarioMatricula response = new SolicitudPropietarioMatricula();
            response = await GetAsyncFirst<SolicitudPropietarioMatricula>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <param name="solicitudTerceroEntidadEducativa"></param>
        /// <returns></returns>
        public async Task<SolicitudTerceroEntidadEducativa> InsertarSolicitudTerceroEntidadEducativa(SolicitudTerceroEntidadEducativa solicitudTerceroEntidadEducativa)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.EntidadId), solicitudTerceroEntidadEducativa.ENE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.Nit), solicitudTerceroEntidadEducativa.ENE_NIT);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.RazonSocial), solicitudTerceroEntidadEducativa.ENE_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.NivelId), solicitudTerceroEntidadEducativa.PRN_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.ReciboPago), solicitudTerceroEntidadEducativa.TER_NUM_RECIBO_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.FechaPago), solicitudTerceroEntidadEducativa.TER_FECHA_LIMITE_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.CreadoPor), solicitudTerceroEntidadEducativa.ENE_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.TipoTerceroEntidadEducativa), solicitudTerceroEntidadEducativa.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.SolicitudId), solicitudTerceroEntidadEducativa.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudEntidadEducativaParameters.TipoIdentificacionNit), solicitudTerceroEntidadEducativa.TID_ID_FK);


            SolicitudTerceroEntidadEducativa response = new SolicitudTerceroEntidadEducativa();
            response = await GetAsyncFirst<SolicitudTerceroEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        // <summary>
        /// Método encargado de crear el beneficiario estudio para entidad educativa
        /// </summary>
        public async Task<SolicitudTerceroBeneficiarioEstudio> InsertarSolicitudTerceroBeneficiarioEstudio(SolicitudTerceroBeneficiarioEstudio solicitudBeneficiarioEstudio)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.numDoc), solicitudBeneficiarioEstudio.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.razonSocialEstudiante), solicitudBeneficiarioEstudio.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.parentescoId), solicitudBeneficiarioEstudio.TER_PARENTESCO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.CreadoPor), solicitudBeneficiarioEstudio.CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.TipoTerceroBeneficiarioEstudioId), solicitudBeneficiarioEstudio.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.SolicitudId), solicitudBeneficiarioEstudio.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioParameters.tipoDocId), solicitudBeneficiarioEstudio.TID_ID_FK);


            SolicitudTerceroBeneficiarioEstudio response = new SolicitudTerceroBeneficiarioEstudio();
            response = await GetAsyncFirst<SolicitudTerceroBeneficiarioEstudio>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        // <summary>
        /// Método encargado de crear el beneficiario estudio entidad educativa
        /// </summary>
        //public async Task<SolicitudTerceroBeneficiarioEstudioEntidadEducativa> InsertarSolicitudTerceroBeneficiarioEstudioEntidadEducativa(SolicitudTerceroBeneficiarioEstudioEntidadEducativa solicitudBeneficiarioEstudioEntidadEducativa)
        //{
        //    DynamicParameters parameters = new DynamicParameters();

        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.SolicitudId), solicitudBeneficiarioEstudioEntidadEducativa.SOL_ID_FK);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.TipoTerceroBeneficiarioEstudioEntidadEducativaId), solicitudBeneficiarioEstudioEntidadEducativa.TER_TIPO_TERCERO_FK);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.tipoDocId), solicitudBeneficiarioEstudioEntidadEducativa.TID_ID_FK);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.numDoc), solicitudBeneficiarioEstudioEntidadEducativa.TER_NUMERO_DOCUMENTO);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.razonSocialEstudiante), solicitudBeneficiarioEstudioEntidadEducativa.TER_NOMBRE_RAZON_SOCIAL);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.parentescoId), solicitudBeneficiarioEstudioEntidadEducativa.TER_PARENTESCO);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.EntidadId), solicitudBeneficiarioEstudioEntidadEducativa.ENE_ID);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.Nit), solicitudBeneficiarioEstudioEntidadEducativa.ENE_NIT);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.RazonSocial), solicitudBeneficiarioEstudioEntidadEducativa.ENE_NOMBRE_RAZON_SOCIAL);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.NivelId), solicitudBeneficiarioEstudioEntidadEducativa.PRN_ID_FK);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.ReciboPago), solicitudBeneficiarioEstudioEntidadEducativa.TER_NUM_RECIBO_PAGO);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.valorRetirar), solicitudBeneficiarioEstudioEntidadEducativa.SOL_VALOR_A_RETIRAR);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.FechaPago), solicitudBeneficiarioEstudioEntidadEducativa.TER_FECHA_LIMITE_PAGO);
        //    parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters.CreadoPor), solicitudBeneficiarioEstudioEntidadEducativa.ENE_CREATEDOPOR);


        //    SolicitudTerceroBeneficiarioEstudioEntidadEducativa response = new SolicitudTerceroBeneficiarioEstudioEntidadEducativa();
        //    response = await GetAsyncFirst<SolicitudTerceroBeneficiarioEstudioEntidadEducativa>(HelperDBParameters.BuilderFunction(
        //        HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        //    return response;
        //}

        // <summary>
        /// Método encargado de crear la entidad de seguro o poliza educativa
        /// </summary>
        public async Task<SolicitudTerceroEntidadSeguroEducativo> InsertarSolicitudTerceroEntidadSeguroEducativo(SolicitudTerceroEntidadSeguroEducativo solicitudEntidadSeguroEducativo)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.numDoc), solicitudEntidadSeguroEducativo.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.razonSocialAseguradora), solicitudEntidadSeguroEducativo.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.CreadoPor), solicitudEntidadSeguroEducativo.TER_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.TipoTerceroEntidadSeguroId), solicitudEntidadSeguroEducativo.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.SolicitudId), solicitudEntidadSeguroEducativo.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.tipoDocId), solicitudEntidadSeguroEducativo.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.entidadSeguroEducativoId), solicitudEntidadSeguroEducativo.ESE_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroEntidadSeguroEducativoParameters.numeroPoliza), solicitudEntidadSeguroEducativo.TER_NUM_POLIZA);


            SolicitudTerceroEntidadSeguroEducativo response = new SolicitudTerceroEntidadSeguroEducativo();
            response = await GetAsyncFirst<SolicitudTerceroEntidadSeguroEducativo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }
        
        // <summary>
        /// Método encargado de crear el tercero tenedor de acciones
        /// </summary>
        public async Task<SolicitudTerceroTenedorAcciones> InsertarSolicitudTerceroTenedorAcciones(SolicitudTerceroTenedorAcciones solicitudTerceroTenedorAcciones)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.SolicitudId), solicitudTerceroTenedorAcciones.SOL_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.TipoIdentificacion), solicitudTerceroTenedorAcciones.TID_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.NumeroDocumento), solicitudTerceroTenedorAcciones.TER_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.RazonSocial), solicitudTerceroTenedorAcciones.TER_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.Direccion), solicitudTerceroTenedorAcciones.TER_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.Ciudad), solicitudTerceroTenedorAcciones.DPC_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.CorreoElectronico), solicitudTerceroTenedorAcciones.TER_CORREO_ELECTRONICO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.Telefono), solicitudTerceroTenedorAcciones.TER_TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.CreadoPor), solicitudTerceroTenedorAcciones.TER_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.TipoTercero), solicitudTerceroTenedorAcciones.TER_TIPO_TERCERO_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudTerceroTenedorAccionesParameters.RazonSocialEmisor), solicitudTerceroTenedorAcciones.TER_EMISOR_NOMBRE_RAZON_SOCIAL);


            SolicitudTerceroTenedorAcciones response = new SolicitudTerceroTenedorAcciones();
            response = await GetAsyncFirst<SolicitudTerceroTenedorAcciones>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }
        
        public async Task<bool> EliminarTerceroSolicitud(Guid solicitudId) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.SolicitudId), solicitudId);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> EliminarMatriculaPropietarioSolicitud(Guid solicitudId) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.SolicitudId), solicitudId);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> EliminarPropietarioSolicitud(Guid solicitudId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.SolicitudId), solicitudId);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> EliminarMatriculaInmobiliaria(Guid solicitudId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.SolicitudId), solicitudId);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<ObtenerTramiteSolicitud> AprobarSolicitudTarea(AprobarSolicitudTarea aprobarSolicitudTarea) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaId), aprobarSolicitudTarea.SLT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaEstadoId), aprobarSolicitudTarea.SLT_ESTADO_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaEstadoNuevoId), aprobarSolicitudTarea.SLT_ESTADO_SOLICITUD_NUEVO);

            ObtenerTramiteSolicitud response;
            response = await GetAsyncFirst<ObtenerTramiteSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> RechazarSolicitudTarea(RechazarSolicitudTarea rechazarSolicitudTarea)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaId), rechazarSolicitudTarea.SLT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaEstadoId), rechazarSolicitudTarea.SLT_ESTADO_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudTareaEstadoNuevoId), rechazarSolicitudTarea.SLT_ESTADO_SOLICITUD_NUEVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudTareaParameters.SolicitudEstadoId), rechazarSolicitudTarea.SOL_ESTADO_SOLICITUD);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<RespuestaDocumentosPorSubModalidad>> ConsultarDocumentosPorSubModalidad(Guid idSubModalidad, Guid idSolicitudtarea) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumGeneralParameters.SubModalidad), idSubModalidad);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGeneralParameters.SolicitudTarea), idSolicitudtarea);

            IEnumerable<RespuestaDocumentosPorSubModalidad> response;
            response = await GetAsyncList<RespuestaDocumentosPorSubModalidad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<ConsultarArchivoPorSolicitud>> ConsultarArchivoPorSolicitud(Guid solicitudId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.Solicitud), solicitudId);

            IEnumerable<ConsultarArchivoPorSolicitud> response;
            response = await GetAsyncList<ConsultarArchivoPorSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> EliminarArchivoPorSolicitud (EliminarArchivoPorSolicitud eliminarArchivoPorSolicitud)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoParameters.ArchivoSolicitudId), eliminarArchivoPorSolicitud.AST_ID);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> ActualizarSolicitud(ActualizarSolicitud actualizarSolicitud)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.SolicitudId), actualizarSolicitud.SOL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudParameters.valorRetirar), actualizarSolicitud.SOL_VALOR_A_RETIRAR);

            bool response;
            response = await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// InsertarInconsistenciaSolicitud
        /// </summary>
        /// <param name="insertarInconsistenciaSolicitud"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>01/06/2022</date>
        public async Task<InconsistenciaSolicitud> InsertarInconsistenciaSolicitud(InconsistenciaSolicitud insertarInconsistenciaSolicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.ListaInconsistenciaId), insertarInconsistenciaSolicitud.LIN_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.HerramientaId), insertarInconsistenciaSolicitud.HER_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.PuntoAtencionId), insertarInconsistenciaSolicitud.PTA_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.SolicitudId), insertarInconsistenciaSolicitud.SOL_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.TecnicoId), insertarInconsistenciaSolicitud.USR_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.ObjetoEstudio), insertarInconsistenciaSolicitud.INC_OBJETO_ESTUDIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Analisis), insertarInconsistenciaSolicitud.INC_ANALISIS_REALIZADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Observacion), insertarInconsistenciaSolicitud.INC_OBSERVACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Estado), insertarInconsistenciaSolicitud.INC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.CreadoPor), insertarInconsistenciaSolicitud.INC_CREATEDOPOR);

            return await GetAsyncFirst<InconsistenciaSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarInconsistenciaSolicitud
        /// </summary>
        /// <param name="actualizarInconsistenciaSolicitud"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>01/06/2022</date>
        public async Task<InconsistenciaSolicitud> ActualizarInconsistenciaSolicitud(InconsistenciaSolicitud actualizarInconsistenciaSolicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.InconsistenciaId), actualizarInconsistenciaSolicitud.INC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.ListaInconsistenciaId), actualizarInconsistenciaSolicitud.LIN_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.HerramientaId), actualizarInconsistenciaSolicitud.HER_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.PuntoAtencionId), actualizarInconsistenciaSolicitud.PTA_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.SolicitudId), actualizarInconsistenciaSolicitud.SOL_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.TecnicoId), actualizarInconsistenciaSolicitud.USR_ID_FK);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.ObjetoEstudio), actualizarInconsistenciaSolicitud.INC_OBJETO_ESTUDIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Analisis), actualizarInconsistenciaSolicitud.INC_ANALISIS_REALIZADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Observacion), actualizarInconsistenciaSolicitud.INC_OBSERVACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.Estado), actualizarInconsistenciaSolicitud.INC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.ModificadoPor), actualizarInconsistenciaSolicitud.INC_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.FechaModificacion), actualizarInconsistenciaSolicitud.INC_FECHAMODIFICACION);

            return await GetAsyncFirst<InconsistenciaSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InconsistenciaSolicitud>> ConsultarInconsistenciaSolicitud(Guid solicitudId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInconsistenciaSolicitudParameters.SolicitudId), solicitudId);

            IEnumerable<InconsistenciaSolicitud> response;
            response = await GetAsyncList<InconsistenciaSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

        /// <summary>
        /// Consulta solicitudes de cesantías
        /// </summary>
        /// <author>Hanson Restrepo</author>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RespuestaConsultarSolicitudCesantias>> ConsultarSolicitudCesantias(PeticionConsultarSolicitudCesantias solicitud)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudCesantiasParameters.EstadoSolicitud), solicitud.CVL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudCesantiasParameters.TipoSolicitud), solicitud.PCS_ID);

            var response = await GetAsyncList<RespuestaConsultarSolicitudCesantias>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response;
        }
    }
}