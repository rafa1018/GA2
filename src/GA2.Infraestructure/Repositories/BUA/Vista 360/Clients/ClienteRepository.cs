using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repositorio para los metodos de informacion de clientes
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public class ClienteRepository : DapperGenerycRepository, IClienteRepository
    {
        /// <summary>
        /// Constructor del repositorio
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="configuration"></param>
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Metodo Obtener cliente mediante tipo y número de identificacion
        /// </summary>
        /// <param name="identificationType"></param>
        /// <param name="identificationNumber"></param>
        /// <returns>Client</returns>
        public async Task<Cliente> ObtenerClientePorTipoIdentificationYNumero(int identificationType, string identificationNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), identificationType);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), identificationNumber);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Metodo obtener info cliente por tipo y número de documento 
        /// </summary>
        /// <param name="identificationNumber">Identificacion del cliente</param>
        /// <param name="identificationType">Tipo identificacion</param>
        /// <uthor>Erwin Pantoja España</uthor>
        /// <date>4/10/2021</date>
        /// <returns>Modelo cliente</returns>
        public async Task<ClienteCesantias> ObtenerInformacionClientePorDocumentoYTipo(int identificationType, string identificationNumber, int idCLiente) {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), identificationType);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), identificationNumber);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), idCLiente);

            return await GetAsyncFirst<ClienteCesantias>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Obtener cliente mediante Id
        /// </summary>
        /// <author>Nicolas Florez Sarraola</author>
        /// <date>12/03/2021</date>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Cliente> ObtenerClienteInformacion(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), Id);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Metodo Obtener cliente filtrado por cedula
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <param name="identificacionCliente">Cedula del cliente</param>
        /// <date>08/10/2021</date>
        /// <returns></returns>
        public async Task<ClienteCedula> ObtenerInformacionClienteCedula(int identificacionCliente) {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), identificacionCliente);
            ClienteCedula clienteCedula = new ClienteCedula();

            clienteCedula = await GetAsyncFirst<ClienteCedula>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);


            return clienteCedula;
        }

        /// <summary>
        /// Metodo Actualizar datos del cliente
        /// </summary>
        /// <author>ONicolas Florez Sarraola</author>
        /// <date>12/03/2021</date>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Cliente> ActualizarCliente(Cliente client)
        {
            DynamicParameters parameters = new DynamicParameters();
            DateTime? fechaAltaCalculada = client.CTS_SLP;
            if(client.CTS_SLP.Year < 1800) { fechaAltaCalculada = null; }
            
            //Información básica cliente
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), client.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), client.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPA_ID), client.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), client.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_EXPEDICION), client.CLI_FECHA_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_IDENTIFICACION_EXPEDIDA), client.DPC_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_IDENTIFICACION_EXPEDIDA), client.DPD_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_LUGAR_EXPEDICION), client.CLI_LUGAR_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_NOMBRE), client.CLI_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_NOMBRE), client.CLI_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_APELLIDO), client.CLI_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_APELLIDO), client.CLI_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_NACIMIENTO), client.CLI_FECHA_NACIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_PAIS_NACIMIENTO), client.DPP_ID_PAIS_NACIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID), client.DPD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID), client.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_LUGAR_NACIMIENTO), client.CLI_LUGAR_NACIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_SEXO), client.CAT_SEXO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_ESTADO_CIVIL), client.CAT_ESTADO_CIVIL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PROFESION), client.CLI_PROFESION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.UEJ_ID), client.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.FRZ_ID), client.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTG_ID), client.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.GRD_ID), client.GRD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_INSCRIPCION), client.CLI_FECHA_INSCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_ALTA), client.CLI_FECHA_ALTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTS_SLP), fechaAltaCalculada);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_VALIDACION_BIOMETRICA), client.CLI_VALIDACION_BIOMETRICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_REGIMEN), client.CLI_REGIMEN);

            //Información económica
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.ACC_ID), client.ACC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_MENSUAL), client.CIE_INGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_EGRESO_MENSUAL), client.CIE_EGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_ACTIVOS), client.CIE_TOTAL_ACTIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PASIVOS), client.CIE_TOTAL_PASIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PATRIMONIO), client.CIE_TOTAL_PATRIMONIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_ADICIONAL), client.CIE_INGRESO_ADICIONAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_CONCEPTO_INGRESO_ADICIONAL), client.CIE_CONCEPTO_INGRESO_ADICIONAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TRANS_EXTRANJERO), client.CIE_TRANS_EXTRANJERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.MND_ID), client.MND_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_VALOR_TRANSFERENCIA), client.CIE_VALOR_TRANSFERENCIA);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_ID), client.DRC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_RESIDENCIA), client.DPP_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_RESIDENCIA), client.DPD_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_RESIDENCIA), client.DPC_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_CIUDAD_RESIDENCIA_EXTRANJERO), client.DRC_CIUDAD_RESIDENCIA_EXTRANJERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPC_TIPO_CALLE), client.TPC_TIPO_CALLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_NUMERO_1), client.DRC_NUMERO_1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.LTR_LETRA_1), client.LTR_LETRA_1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.BS_BIS_1), client.BS_BIS_1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CRD_CARDINAL_1), client.CRD_CARDINAL_1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_NUMERO_2), client.DRC_NUMERO_2);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.LTR_LETRA_2), client.LTR_LETRA_2);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.BS_BIS_2), client.BS_BIS_2);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CRD_CARDINAL_2), client.CRD_CARDINAL_2);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_NUMERO_3), client.DRC_NUMERO_3);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.LTR_LETRA_3), client.LTR_LETRA_3);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CRD_CARDINAL_3), client.CRD_CARDINAL_3);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_COMPLEMENTO_DIRECCION), client.DRC_COMPLEMENTO_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_DIRECCION), client.DRC_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_BARRIO), client.DRC_BARRIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_TIPO_DIR), client.TPD_ID);

            //Información de correo
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DCE_CORREO), client.DCE_CORREO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TCE_ID), client.TCE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DCE_ENVIO_INFORMACION), client.DCE_ENVIO_INFORMACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DCE_ACTIVO), client.DCE_ACTIVO);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_TELEFONO), client.DTL_TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPT_ID), client.TPT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_ENVIO_INFORMACION), client.DTL_ENVIO_INFORMACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_ACTIVO), client.DTL_ACTIVO);

            //Información cónyuge
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_TID_ID), client.CNY_TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_IDENTIFICACION), client.CNY_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_NOMBRE), client.CNY_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_NOMBRE), client.CNY_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_APELLIDO), client.CNY_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_APELLIDO), client.CNY_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_ACTIVO), client.CNY_ACTIVO);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener cliente login paa
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <param name="numeroIdentificacion"></param>
        /// <param name="numeroCelular"></param>
        /// <param name="fechaExpedicion"></param>
        /// <returns></returns>
        public async Task<Cliente> ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(string tipoDocumento, string numeroIdentificacion, string numeroCelular, DateTime fechaExpedicion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), tipoDocumento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), numeroIdentificacion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_EXPEDICION), fechaExpedicion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_TELEFONO), numeroCelular);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo que valida los registros de afiliados que deben ser creados
        /// </summary>
        /// <param name="json">Json con los clientes a crear</param>
        /// <returns>Lista de clientes sin confirmar</returns>
        public async Task<IEnumerable<ClienteSinCrear>> ValidarNomina(string json)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(HelpersEnums.GetEnumDescription(EnumEjecutorParameters.Json), json);
            return await GetAsyncTransaction<ClienteSinCrear>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameter, CommandType.StoredProcedure, IsolationLevel.ReadUncommitted);
        }

        /// <summary>
        /// Metodo que crea los afiliados apartir del archivo de carga
        /// </summary>
        /// <param name="clientes">Lista de clientes a ser creados</param>
        /// <returns>Confirmacion de creacion de clientes</returns>
        public async Task<IEnumerable<ClienteSinCrear>> CrearClientesPorCargaNomina(IEnumerable<ClienteSinCrear> clientes)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(HelpersEnums.GetEnumDescription(EnumEjecutorParameters.Json), JsonConvert.SerializeObject(clientes));
            return await GetAsyncTransaction<ClienteSinCrear>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameter, CommandType.StoredProcedure, IsolationLevel.ReadCommitted);
        }

        public async Task<Cliente> InsertarCliente(Cliente client)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Información básica cliente
            DateTime? fechaExpedicion = client.CLI_FECHA_EXPEDICION;
            DateTime? fechaAlta = client.CLI_FECHA_ALTA;
            DateTime? fechaInscripcion = client.CLI_FECHA_INSCRIPCION;
            DateTime? fechaAltaCalculada = client.CTS_SLP;
            DateTime? fechaNacimiento = client.CLI_FECHA_NACIMIENTO;
            int paisNacimiento = client.DPP_ID_PAIS_NACIMIENTO > 0 ? client.DPP_ID_PAIS_NACIMIENTO : 1;
            int paisResidencia = client.DPP_ID_RESIDENCIA > 0 ? client.DPP_ID_RESIDENCIA : 1;

            if (client.CLI_FECHA_EXPEDICION.Year < 1800) { fechaExpedicion = null; }
            if(client.CLI_FECHA_ALTA.Year < 1800) { fechaAlta = null; }
            if(client.CLI_FECHA_INSCRIPCION.Year < 1800) { fechaInscripcion = null; }
            if(client.CTS_SLP.Year < 1800) { fechaAltaCalculada = null; }
            if(client.CLI_FECHA_NACIMIENTO.Year < 1800) { fechaNacimiento = null; }


            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), client.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPA_ID), client.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), client.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_EXPEDICION), fechaExpedicion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_IDENTIFICACION_EXPEDIDA), client.DPP_ID_PAIS_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_IDENTIFICACION_EXPEDIDA), client.DPD_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_IDENTIFICACION_EXPEDIDA), client.DPC_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_NOMBRE), client.CLI_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_NOMBRE), client.CLI_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_APELLIDO), client.CLI_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_APELLIDO), client.CLI_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_NACIMIENTO), fechaNacimiento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_PAIS_NACIMIENTO), paisNacimiento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID), client.DPD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID), client.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_SEXO), client.CAT_SEXO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_ESTADO_CIVIL), client.CAT_ESTADO_CIVIL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PROFESION), 1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_UNIDAD), client.CLI_UNIDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.FRZ_ID), client.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.GRD_ID), client.GRD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTG_ID), client.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.UEJ_ID), client.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_INSCRIPCION), fechaInscripcion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_ALTA), fechaAlta);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTS_SLP), fechaAltaCalculada);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_VALIDACION_BIOMETRICA), 1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_REGIMEN), client.CLI_REGIMEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_INTEGRACION_GA2_PAYLOAD), client.CLI_INTEGRACION_GA2_PAYLOAD);

            //Información económica
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.ACC_ID), client.ACC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_MENSUAL), client.CIE_INGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_EGRESO_MENSUAL), client.CIE_EGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_ACTIVOS), client.CIE_TOTAL_ACTIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PASIVOS), client.CIE_TOTAL_PASIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PATRIMONIO), client.CIE_TOTAL_PATRIMONIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_ADICIONAL), client.CIE_INGRESO_ADICIONAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_CONCEPTO_INGRESO_ADICIONAL), client.CIE_CONCEPTO_INGRESO_ADICIONAL);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_RESIDENCIA), paisResidencia);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_RESIDENCIA), client.DPD_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_RESIDENCIA), client.DPC_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_DIRECCION), client.DRC_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_BARRIO), client.DRC_BARRIO);

            //Información de correo
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DCE_CORREO), client.DCE_CORREO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TCE_ID), client.TCE_ID);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_TELEFONO), client.DTL_TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPT_ID), client.TPT_ID);

            //Información cónyuge
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_TID_ID), client.CNY_TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_IDENTIFICACION), client.CNY_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_NOMBRE), client.CNY_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_NOMBRE), client.CNY_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_APELLIDO), client.CNY_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_APELLIDO), client.CNY_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_ACTIVO), 1);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Cliente> RestaurarIntegracionCliente(Cliente client)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Información básica cliente
            DateTime? fechaExpedicion = client.CLI_FECHA_EXPEDICION;
            DateTime? fechaAlta = client.CLI_FECHA_ALTA;
            DateTime? fechaInscripcion = client.CLI_FECHA_INSCRIPCION;
            DateTime? fechaAltaCalculada = client.CTS_SLP;
            DateTime? fechaNacimiento = client.CLI_FECHA_NACIMIENTO;
            int paisNacimiento = client.DPP_ID_PAIS_NACIMIENTO > 0 ? client.DPP_ID_PAIS_NACIMIENTO : 169;
            int paisResidencia = client.DPP_ID_RESIDENCIA > 0 ? client.DPP_ID_RESIDENCIA : 169;

            if (client.CLI_FECHA_EXPEDICION.Year < 1800) { fechaExpedicion = null; }
            if (client.CLI_FECHA_ALTA.Year < 1800) { fechaAlta = null; }
            if (client.CLI_FECHA_INSCRIPCION.Year < 1800) { fechaInscripcion = null; }
            if (client.CTS_SLP.Year < 1800) { fechaAltaCalculada = null; }
            if (client.CLI_FECHA_NACIMIENTO.Year < 1800) { fechaNacimiento = null; }


            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), client.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), client.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPA_ID), client.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), client.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_EXPEDICION), fechaExpedicion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_IDENTIFICACION_EXPEDIDA), client.DPP_ID_PAIS_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_IDENTIFICACION_EXPEDIDA), client.DPD_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_IDENTIFICACION_EXPEDIDA), client.DPC_ID_IDENTIFICACION_EXPEDIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_NOMBRE), client.CLI_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_NOMBRE), client.CLI_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_APELLIDO), client.CLI_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_APELLIDO), client.CLI_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_NACIMIENTO), fechaNacimiento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_PAIS_NACIMIENTO), paisNacimiento);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID), client.DPD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID), client.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_SEXO), client.CAT_SEXO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CAT_ESTADO_CIVIL), client.CAT_ESTADO_CIVIL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PROFESION), 1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_UNIDAD), client.CLI_UNIDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.FRZ_ID), client.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.GRD_ID), client.GRD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTG_ID), client.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.UEJ_ID), client.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_INSCRIPCION), fechaInscripcion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_ALTA), fechaAlta);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CTS_SLP), fechaAltaCalculada);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_VALIDACION_BIOMETRICA), 1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_REGIMEN), client.CLI_REGIMEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_INTEGRACION_GA2_PAYLOAD), client.CLI_INTEGRACION_GA2_PAYLOAD);

            //Información económica
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_ID), client.CIE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.ACC_ID), client.ACC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_MENSUAL), client.CIE_INGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_EGRESO_MENSUAL), client.CIE_EGRESO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_ACTIVOS), client.CIE_TOTAL_ACTIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PASIVOS), client.CIE_TOTAL_PASIVOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_TOTAL_PATRIMONIO), client.CIE_TOTAL_PATRIMONIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_INGRESO_ADICIONAL), client.CIE_INGRESO_ADICIONAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CIE_CONCEPTO_INGRESO_ADICIONAL), client.CIE_CONCEPTO_INGRESO_ADICIONAL);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_ID), client.DRC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPP_ID_RESIDENCIA), paisResidencia);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPD_ID_RESIDENCIA), client.DPD_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DPC_ID_RESIDENCIA), client.DPC_ID_RESIDENCIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_DIRECCION), client.DRC_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DRC_BARRIO), client.DRC_BARRIO);

            //Información de correo
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DCE_CORREO), client.DCE_CORREO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TCE_ID), client.TCE_ID);

            //Información de direccion
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_TELEFONO), client.DTL_TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TPT_ID), client.TPT_ID);

            //Información cónyuge
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_TID_ID), client.CNY_TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_IDENTIFICACION), client.CNY_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_NOMBRE), client.CNY_PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_NOMBRE), client.CNY_SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_PRIMER_APELLIDO), client.CNY_PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_SEGUNDO_APELLIDO), client.CNY_SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CNY_ACTIVO), 1);

            return await GetAsyncFirst<Cliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Cuenta> InsertarCuentaIntegracion(Cuenta cuenta)
        {
            DateTime? fechaCreacion = cuenta.CTA_FECHA_CREACION;
            DateTime? fechaCierre = cuenta.CTA_FECHA_CIERRE;
            DateTime? fechaPrimerAporte = cuenta.CTA_FECHA_PRIMER_APORTE;

            if (cuenta.CTA_FECHA_CREACION.Year < 1800) { fechaCreacion = null; }
            if (cuenta.CTA_FECHA_CIERRE.Year < 1800) { fechaCierre = null; }
            if (cuenta.CTA_FECHA_PRIMER_APORTE.Year < 1800) { fechaPrimerAporte = null; }

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID_INTEGRACION), cuenta.CTA_ID_INTEGRACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CLI_ID), cuenta.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_NUMERO), cuenta.CTA_NUMERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.ECT_ID), cuenta.ECT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CREACION), fechaCreacion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CIERRE), fechaCierre);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_PRIMER_APORTE), fechaPrimerAporte);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO), cuenta.CTA_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_CANJE), cuenta.CTA_SALDO_CANJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_DISPONIBLE), cuenta.CTA_SALDO_DISPONIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_CUOTAS), cuenta.CTA_CUOTAS);
            
            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Dependiente> InsertarDependienteIntegracion(Dependiente dependiente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumDependientParameters.CLI_ID), dependiente.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDependientParameters.TID_ID), dependiente.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDependientParameters.DPT_IDENTIFICACION), dependiente.DPT_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDependientParameters.DPT_NOMBRE), dependiente.DPT_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDependientParameters.DPT_PARTICIPACION), dependiente.DPT_PARTICIPACION);
            return await GetAsyncFirst<Dependiente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<AportesCliente> InsertarAportesIntegracion(AportesCliente aportesCliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            DateTime? fechaPrimera = aportesCliente.APC_FECHA_PRIMERA_CUOTA;
            DateTime? fechaUltima = aportesCliente.APC_FECHA_PRIMERA_CUOTA;
            if (aportesCliente.APC_FECHA_PRIMERA_CUOTA.Year < 1800){ fechaPrimera = null; }
            if (aportesCliente.APC_FECHA_PRIMERA_CUOTA.Year < 1800) { fechaUltima = null; }

            parameters.Add(HelpersEnums.GetEnumDescription(EnumAportesParameters.CLI_ID), aportesCliente.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAportesParameters.CGT_ID), aportesCliente.CGT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAportesParameters.APC_CUOTAS_ACUMULADAS), aportesCliente.APC_CUOTAS_ACUMULADAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAportesParameters.APC_FECHA_PRIMERA_CUOTA), fechaPrimera);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAportesParameters.APC_FECHA_ULTIMA_COUTA), fechaUltima);
            
            return await GetAsyncFirst<AportesCliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Cuenta>> ObtenerCuentas(int idCliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), idCliente);

            return await GetAsyncList<Cuenta>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AportesCliente>> ObtenerAportesCliente(int idCliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), idCliente);

            return await GetAsyncList<AportesCliente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Dependiente>> ObtenerDependientes(int idCliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_ID), idCliente);

            return await GetAsyncList<Dependiente>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Movimiento> InsertarMovimientoIntegracion(Movimiento movimiento)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.Concepto), movimiento.CNC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.Cuenta), movimiento.CTA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.Valor), movimiento.MVT_VALOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.TipoMovimiento), movimiento.CAT_TIPO_MOVIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.FechaProceso), movimiento.MVT_FECHA_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.FechaMovimiento), DateTime.Today);

            return await GetAsyncFirst<Movimiento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CuentaAfiliado>> ObtenerCuentasMovimientosAfiliado(string identificacion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), identificacion);

            return await GetAsyncList<CuentaAfiliado>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Cuenta> ObtenerCuentaById(string request)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaByIdParams.IDENTIFICACION), request);

            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Movimiento>> ObtenerMovimientosCuenta(int idCuenta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumMovimientoParameters.Cuenta), idCuenta);

            return await GetAsyncList<Movimiento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Application.Dto.CuerpoArchivoDto>> InsertarClienteNomina(Application.Dto.CuerpoArchivoDto cliente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_CODIGO_MILITAR), cliente.CODIGO_MILITAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.FRZ_ID), cliente.DIGITO_FUERZA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.GRD_ID), cliente.GRADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_APELLIDO), cliente.PRIMER_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_PRIMER_NOMBRE), cliente.PRIMER_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_APELLIDO), cliente.SEGUNDO_APELLIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_SEGUNDO_NOMBRE), cliente.SEGUNDO_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), cliente.TIPO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), cliente.IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.UEJ_ID), cliente.UNIDAD_EJECUTORA);

            return await GetAsyncList<Application.Dto.CuerpoArchivoDto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }



        public async Task<Cuenta> ObtenerCuentaClieteByIdNumeroCuenta(int numeroCuenta, int idCliente)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CLI_ID), idCliente);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_NUMERO), numeroCuenta);

            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<Cliente>> ObtenerClientesById(string clientesIds)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLIENTES_IDS), clientesIds);

            return await GetAsyncList<Cliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Cuenta>> ObtenerCuentaIdCuenta(string idCuenta)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaByIdParams.CTA_ID), idCuenta);

            return await GetAsyncList<Cuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
