using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class TransUnionRepository : DapperGenerycRepository, ITransUnionRepository
    {
        public TransUnionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> ActualizarOtpValidacion(VLI_VALIDACION_IDENTIDAD valida)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_ID), valida.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_FECHA_VALIDA_OTP), valida.VLI_FECHA_VALIDA_OTP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_FECHA_VALIDA_IDEN), valida.VLI_FECHA_VALIDA_IDEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_CODIGO_OTP), valida.VLI_CODIGO_OTP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_PASO_VALIDACION), valida.VLI_PASO_VALIDACION);

            var response = await GetAsyncFirst<VLI_VALIDACION_IDENTIDAD>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response.VLI_PASO_VALIDACION;
        }

        public async Task<VLL_VALIDACION_LOG_OTP> CrearLogOTP(VLL_VALIDACION_LOG_OTP datosLog)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_ID), datosLog.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_ID), datosLog.VLL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_CODIGO_OTP), datosLog.VLL_CODIGO_OTP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_ID_APICACION), datosLog.VLL_ID_APICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_ESTADO_VALIDACION), datosLog.VLL_ESTADO_VALIDACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogOTPParameters.VLL_FECHA_ACTUALIZA), datosLog.VLL_FECHA_ACTUALIZA);

            return await GetAsyncFirst<VLL_VALIDACION_LOG_OTP>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SolicitudCreditoProductoGral> CrearLogTu(SolicitudCreditoProductoGral datosLog)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_ID), datosLog.VLT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLI_ID), datosLog.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_SERVICIO), datosLog.VLT_SERVICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_PASO_TRANSACCION), datosLog.VLT_PASO_TRANSACCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_XML_SOLICITUD), datosLog.VLT_XML_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_XML_RESPUESTA), datosLog.VLT_XML_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_ID_APICACION), datosLog.VLT_ID_APICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_CODIGO_RESPUESTA), datosLog.VLT_CODIGO_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_TIPO_RESPUESTA), datosLog.VLT_TIPO_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_DESCRIPCION_RESPUESTA), datosLog.VLT_DESCRIPCION_RESPUESTA);


            var response = await GetAsyncFirst<SolicitudCreditoProductoGral>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response;
        }


        public async Task<Guid> CrearValidacion(VLI_VALIDACION_IDENTIDAD validacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_ID), validacion.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.TID_ID), validacion.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_FECHA_EXPEDICION), validacion.VLI_FECHA_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_NUMERO_DOCUMENTO), validacion.VLI_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_NUMERO_CELULAR), validacion.VLI_NUMERO_CELULAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_ACEPTA_HABEAS), validacion.VLI_ACEPTA_HABEAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionParameters.VLI_ACEPTA_TERMINOS), validacion.VLI_ACEPTA_TERMINOS);

            var response = await GetAsyncFirst<VLI_VALIDACION_IDENTIDAD>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response.VLI_ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosLog"></param>
        /// <returns></returns>
        public async Task<SolicitudCreditoProductoGral> RegistroLogTU(SolicitudCreditoProductoGral datosLog)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_ID), datosLog.VLT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLI_ID), datosLog.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_SERVICIO), datosLog.VLT_SERVICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_PASO_TRANSACCION), datosLog.VLT_PASO_TRANSACCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_XML_SOLICITUD), datosLog.VLT_XML_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_XML_RESPUESTA), datosLog.VLT_XML_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_ID_APICACION), datosLog.VLT_ID_APICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_CODIGO_RESPUESTA), datosLog.VLT_CODIGO_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_TIPO_RESPUESTA), datosLog.VLT_TIPO_RESPUESTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionLogParameters.VLT_DESCRIPCION_RESPUESTA), datosLog.VLT_DESCRIPCION_RESPUESTA);

            var response = await GetAsyncFirst<SolicitudCreditoProductoGral>("CrearLogTu", parameters, CommandType.StoredProcedure);
            return response;
        }
    }
}
