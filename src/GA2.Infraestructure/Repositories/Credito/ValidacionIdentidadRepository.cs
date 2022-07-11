using Dapper;
using GA2.Domain.Entities;
using GA2.Domain.Entities.Credito.Simulador;
using GA2.Infraestructure.Data;
using GA2.Infraestructure.Data.Credito;
using GA2.Infraestructure.Data.Credito.Simulador;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{

    /// <summary>
    /// Implementacion Interface Validacion Identidad
    /// </summary>
    public class ValidacionIdentidadRepository : DapperGenerycRepository, IValidacionIdentidadRepository
    {
        public ValidacionIdentidadRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Crea la validación de Identidad
        /// Recibe como parametro un string
        /// /// <param name="valida"></param>
        /// </summary>
        public async Task<ValidacionIdentidad> CreateValidacionIdentidad(ValidacionIdentidad valida)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.TID_ID), valida.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_NUMERO_DOCUMENTO), valida.VLI_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_NUMERO_CELULAR), valida.VLI_NUMERO_CELULAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_FECHA_EXPEDICION), valida.VLI_FECHA_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_ACEPTA_HABEAS), valida.VLI_ACEPTA_HABEAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_ACEPTA_TERMINOS), valida.VLI_ACEPTA_TERMINOS);

            return await GetAsyncFirst<ValidacionIdentidad>("CrearValidacion", parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Obtener los datos personales del usuario
        /// Recibe como parametro un string
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<SimulacionDatosPersonales> ObtenerDatosPersonalesAsync(string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonales.SDP_NUMERO_DOCUMENTO), numeroDocumento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonales.SDP_ID), null);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonales.SLS_ID), null);
            parameters.Add("@IND", 3);

            var result= await GetAsyncFirst<SimulacionDatosPersonales>("ObtenerSimulacionPersonales", parameters, CommandType.StoredProcedure);
            return result;
        }


        /// <summary>
        /// Obtener Datos Financieros
        /// Recibe como parametro un string 
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<SimulacionDatosFinancieros> ObtenerDatosFinancierosAsync(string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosFinancieros.SDF_ID), null);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosFinancieros.SLS_ID), null);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_NUMERO_DOCUMENTO), numeroDocumento);
            parameters.Add("@IND", 3);

            return await GetAsyncFirst<SimulacionDatosFinancieros>("ObtenerInformacionFinanciera", parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Actualizar Validacion OTP
        /// Recibe como parametro un objeto de la clase ValidacionIdentidad
        /// /// <param name="valida"></param>
        /// </summary>
        public async Task<int> ActualizarValidacionOTP(ValidacionIdentidad valida)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_ID), valida.VLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_FECHA_VALIDA_OTP), valida.VLI_FECHA_VALIDA_OTP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_FECHA_VALIDA_IDEN), valida.VLI_FECHA_VALIDA_IDEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_CODIGO_OTP), valida.VLI_CODIGO_OTP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_PASO_VALIDACION), valida.VLI_PASO_VALIDACION);

            return await GetAsyncFirst<int>("ValidacionOtp", parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// ConsultarPreAprobado
        /// Recibe como parametro un string 
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<List<SimulacionSolicitud>> ConsultarPreAprobado(string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@NUMERO_DOCUMENTO", numeroDocumento);

            var resultado = await GetAsyncList<SimulacionSolicitud>("ConsultarPreAprobado", parameters, CommandType.StoredProcedure);
            return resultado.AsList();
        }


        /// <summary>
        /// ConsultarPreAprobado
        /// Recibe como parametro un string 
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<List<SocSolicitudCredito>> ConsultarSolicitudCredito (string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@NUMERO_DOCUMENTO", numeroDocumento);
            parameters.Add("@ESTADO", "C");

            var resultado = await GetAsyncList<SocSolicitudCredito>("ConsultarSolicitudCredito", parameters, CommandType.StoredProcedure);
            return resultado.AsList();
        }

        /// <summary>
        /// Crear Solicitud de Credito
        /// Recibe como parametro un objeto de la clase SimulacionDatosPersonalesDto
        /// /// <param name="datosPersonales"></param>
        /// </summary>
        public async Task<SimulacionDatosPersonales> CrearSimulacionDP(SimulacionDatosPersonales datos)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SLS_ID", datos.SLS_ID);
            parameters.Add("@SDP_ID", datos.SDP_ID);
            parameters.Add("@SLS_FECHA_SOLICITUD", DateTime.Now.Date);
            parameters.Add("@FRZ_ID", datos.FRZ_ID);
            parameters.Add("@CTG_ID", datos.CTG_ID);
            parameters.Add("@GRD_ID", datos.GRD_ID);
            parameters.Add("@SDP_NUMERO_DOCUMENTO", datos.SDP_NUMERO_DOCUMENTO);
            parameters.Add("@SDP_NOMBRES_APELLIDOS", datos.SDP_NOMBRES_APELLIDOS);
            parameters.Add("@SDP_EDAD", datos.SDP_EDAD);
            parameters.Add("@SDP_FECHA_AFILIACION", datos.SDP_FECHA_AFILIACION);
            parameters.Add("@DPD_ID", datos.DPD_ID);
            parameters.Add("@DPC_ID", datos.DPC_ID);
            parameters.Add("@SDP_DIRECCION", datos.SDP_DIRECCION);
            parameters.Add("@SDP_TELEFONO_FIJO", datos.SDP_TELEFONO_FIJO);
            parameters.Add("@SDP_TELEFONO_CELULAR", datos.SDP_TELEFONO_CELULAR);
            parameters.Add("@SDP_E_MAIL", datos.SDP_E_MAIL);
            parameters.Add("@SDP_CUOTAS", datos.SDP_CUOTAS);
            parameters.Add("@SDP_REGIMEN", datos.SDP_REGIMEN);
            parameters.Add("@SDP_VALOR_INMUEBLE", datos.SDP_VALOR_INMUEBLE); //Llega 0
            parameters.Add("@TVV_ID", datos.TVV_ID); //Llega 0
            parameters.Add("@DPD_ID_INMUEBLE", datos.DPD_ID_INMUEBLE); //Llega 0
            parameters.Add("@DPC_ID_INMUEBLE", datos.DPC_ID_INMUEBLE); //Llega 0
            parameters.Add("@SLS_USUARIO_ACTUALIZA", Guid.NewGuid());
            parameters.Add("@SLS_FECHA_ACTUALIZA", DateTime.Now);
            parameters.Add("@TCR_ID", 0);
            parameters.Add("@TPA_ID", datos.TPA_ID);
            parameters.Add("@UEJ_ID", datos.UEJ_ID);

            var resultado = await GetAsyncFirst<SimulacionDatosPersonales>("CrearSolicitudSimulacion", parameters, CommandType.StoredProcedure);
            return resultado;
        }
        /// <summary>
        /// Crear Solicitud de Credito
        /// Recibe como parametro un objeto de la clase SimulacionDatosFinancieros
        /// /// <param name="datosPersonales"></param>
        /// </summary>
        public async Task<SimulacionDatosFinancieros> CrearSimulacionDF(SimulacionDatosFinancieros datos)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SLS_ID", datos.SLS_ID);
            parameters.Add("@SDF_ID", datos.SDF_ID);
            parameters.Add("@SDF_VALOR_SALARIO", datos.SDF_VALOR_SALARIO);
            parameters.Add("@SDF_DESCRIPCION_SALARIO", datos.SDF_DESCRIPCION_SALARIO);
            parameters.Add("@SDF_DESCRIPCION_OTRO_INGRESOS", datos.SDF_DESCRIPCION_OTRO_INGRESOS);
            parameters.Add("@SDF_DESCRIPCION_OTRO_ING1", datos.SDF_DESCRIPCION_OTRO_ING1);
            parameters.Add("@SDF_DESCRIPCION_OTRO_ING2", datos.SDF_DESCRIPCION_OTRO_ING2);
            parameters.Add("@SDF_DESCRIPCION_OTRO_ING3", datos.SDF_DESCRIPCION_OTRO_ING3);
            parameters.Add("@SDF_DESCRIPCION_OTRO_ING4", datos.SDF_DESCRIPCION_OTRO_ING4);
            parameters.Add("@SDF_DESCRIPCION_OTRO_ING5", datos.SDF_DESCRIPCION_OTRO_ING5);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS", datos.SDF_VALOR_OTROS_INGRESOS);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS1", datos.SDF_VALOR_OTROS_INGRESOS1);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS2", datos.SDF_VALOR_OTROS_INGRESOS2);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS3", datos.SDF_VALOR_OTROS_INGRESOS3);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS4", datos.SDF_VALOR_OTROS_INGRESOS4);
            parameters.Add("@SDF_VALOR_OTROS_INGRESOS5", datos.SDF_VALOR_OTROS_INGRESOS5);
            parameters.Add("@SDF_VALOR_TOTAL_INGRESOS", datos.SDF_VALOR_TOTAL_INGRESOS);
            parameters.Add("@SDF_VALOR_TOTAL_EGRESOS", datos.SDF_VALOR_TOTAL_EGRESOS);
            parameters.Add("@SDF_USUARIO_ACTUALIZA", Guid.NewGuid());
            parameters.Add("@SDF_FECHA_ACTUALIZA", DateTime.Now);

            return await GetAsyncFirst<SimulacionDatosFinancieros>("CrearSimulacionFinan", parameters, CommandType.StoredProcedure);
            
        }
        /// <summary>
        /// Consultar los paramtros del Simulador
        /// </summary>
        /// <returns></returns>
        public async Task<ParametrosSimulador> ObtenerParametrosSimulador()
        {
            return await GetAsyncFirst<ParametrosSimulador>(ParametrosSimuladorQuery.QueryParametros, null, CommandType.Text);
        }
        /// <summary>
        /// Crear Solicitud de Credito
        /// Recibe como parametro un objeto de la clase SimulacionDatosFinancieros
        /// /// <param name="datosPersonales"></param>
        /// </summary>
        public async Task<ConsultaBuroCliente> CrearConsultaBuro(ConsultaBuroCliente datos)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_ID), datos.CBC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_FECHA_CONSULTA), datos.CBC_FECHA_CONSULTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CLI_IDENTIFICACION), datos.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_DECISION_BURO), datos.CBC_DECISION_BURO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_SCORE), datos.CBC_SCORE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_CAPACIDAD_ENDEUDAMIENTO), datos.CBC_CAPACIDAD_ENDEUDAMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_NIVEL_ENDEUDAMIENTO), datos.CBC_NIVEL_ENDEUDAMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_NIVEL_ENDEUDAMIENTO_CUOTA), datos.CBC_NIVEL_ENDEUDAMIENTO_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_HISTORIAL_CREDITO), datos.CBC_HISTORIAL_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_HUELLA_CONSULTA), datos.CBC_HUELLA_CONSULTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_CREADO_POR), datos.CBC_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultaBuroCliente.CBC_FECHA_CREACION), datos.CBC_FECHA_CREACION);

            return await GetAsyncFirst<ConsultaBuroCliente>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        #region "Pendientes Validar Que son"
        public async Task<ValidacionIdentidad> GetByIdSolicitudSimulacion(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_ID), id);
            return await GetAsyncFirst<ValidacionIdentidad>(SolicitudSimulacionQuery.QueryGetById, parameters, CommandType.Text);
        }

        public async Task<ValidacionIdentidad> GetByDocumentoSolicitudSimulacion(string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumValidacionIdentidad.VLI_NUMERO_DOCUMENTO), numeroDocumento);
            return await GetAsyncFirst<ValidacionIdentidad>(SolicitudSimulacionQuery.QueryGetById, parameters, CommandType.Text);
        }

        #endregion
    }
}