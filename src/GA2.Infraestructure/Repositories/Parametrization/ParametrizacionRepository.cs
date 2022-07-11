using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.Parametrization;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repository de parametrizacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionRepository : DapperGenerycRepository, IParametrizacionRepository
    {
        public ParametrizacionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Metodo Obtener seguro
        /// </summary>
        /// <author>Edgar Andrés Riaño Suarez</author>
        /// <date>12/03/2021</date>
        /// <returns></returns>
        public async Task<SeguroParametrizacion> ObtenerSeguro()
        {
            return await GetAsyncFirst<SeguroParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Metodo Actualizar y Crear seguro mediante el Dto
        /// </summary>
        /// <author>Edgar Andrés Riaño Suarez</author>
        /// <date>12/03/2021</date>
        /// <param name="insuraceparametrizacion"></param>
        /// <returns></returns>
        public async Task<SeguroParametrizacion> CrearSeguro(SeguroParametrizacion insuraceparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.ID), insuraceparametrizacion.PAR_SEG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.VIDA), insuraceparametrizacion.PAR_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.TODORIESGO), insuraceparametrizacion.PAR_TODO_RIESGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.MODIFICADOPOR), insuraceparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroParameters.ESTADO), 1);

            return await GetAsyncFirst<SeguroParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Obtener tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>08/04/2021</date>
        /// <returns></returns>
        public async Task<TasaParametrizacion> ObtenerTasa()
        {
            return await GetAsyncFirst<TasaParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Actualizar y Crear plazo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="rateparametrizacion"></param>
        /// <returns></returns>
        public async Task<TasaParametrizacion> CrearTasa(TasaParametrizacion rateparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.ID), rateparametrizacion.PAR_TAS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.TASAUSURAEA), rateparametrizacion.PAR_USURA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.TASAUSURANM), rateparametrizacion.PAR_USURA_NM);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.TASACORRIENTEEA), rateparametrizacion.PAR_CORRIENTE_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.TASACORRIENTENM), rateparametrizacion.PAR_CORRIENTE_NM);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.MODIFICADOPOR), rateparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRateParameters.ESTADO), 1);

            return await GetAsyncFirst<TasaParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Obtener plazo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns></returns>
        public async Task<PlazoParametrizacion> ObtenerPlazo()
        {
            return await GetAsyncFirst<PlazoParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Actualizar y Crear plazo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="deadlineparametrizacion"></param>
        /// <returns></returns>
        public async Task<PlazoParametrizacion> CrearPlazo(PlazoParametrizacion deadlineparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.ID), deadlineparametrizacion.PAR_PLA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.YEARMIN), deadlineparametrizacion.PAR_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.MONTHMIN), deadlineparametrizacion.PAR_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.YEARMAX), deadlineparametrizacion.PAR_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.MONTHMAX), deadlineparametrizacion.PAR_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.MODIFICADOPOR), deadlineparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumPlazoParameters.ESTADO), 1);

            return await GetAsyncFirst<PlazoParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo obtener legal tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>¿
        /// <returns></returns>
        public async Task<IEnumerable<LegalTasaParametrizacion>> ObtenerLegalTasa()
        {
            return await GetAsyncList<LegalTasaParametrizacion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Crear legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="legaltasaparametrizacion"></param>
        /// <returns></returns>
        public async Task<LegalTasaParametrizacion> CrearLegalTasa(LegalTasaParametrizacion legaltasaparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ID), legaltasaparametrizacion.PAR_LET_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.TASAFRECH), legaltasaparametrizacion.PAR_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.VIGENCIATASAFRECH), legaltasaparametrizacion.PAR_VIGENCIA_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.MODIFICADOPOR), legaltasaparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ESTADO), 1);

            return await GetAsyncFirst<LegalTasaParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Actualizar legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="legaltasaparametrizacion"></param>
        /// <returns></returns>
        public async Task<LegalTasaParametrizacion> ActualizarLegalTasa(LegalTasaParametrizacion legaltasaparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ID), legaltasaparametrizacion.PAR_LET_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.TASAFRECH), legaltasaparametrizacion.PAR_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.VIGENCIATASAFRECH), legaltasaparametrizacion.PAR_VIGENCIA_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.MODIFICADOPOR), legaltasaparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ESTADO), 1);

            return await GetAsyncFirst<LegalTasaParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Eliminar legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="legaltasaparametrizacion"></param>
        /// <returns></returns>
        public async Task<LegalTasaParametrizacion> EliminarLegalTasa(LegalTasaParametrizacion legaltasaparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ID), legaltasaparametrizacion.PAR_LET_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.TASAFRECH), legaltasaparametrizacion.PAR_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.VIGENCIATASAFRECH), legaltasaparametrizacion.PAR_VIGENCIA_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.MODIFICADOPOR), legaltasaparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalTasaParameters.ESTADO), 1);

            return await GetAsyncFirst<LegalTasaParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Obtener legal alivio
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns></returns>
        public async Task<LegalAlivioParametrizacion> ObtenerLegalAlivio()
        {
            return await GetAsyncFirst<LegalAlivioParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Metodo Actualizar y Crear legal alivio mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="legalalivioparametrizacion"></param>
        /// <returns></returns>
        public async Task<LegalAlivioParametrizacion> CrearLegalAlivio(LegalAlivioParametrizacion legalalivioparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.ID), legalalivioparametrizacion.PAR_LEA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.ALIVIOCUOTA), legalalivioparametrizacion.PAR_ALIVIO_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.VIGENCIAALIVIOCUOTA), legalalivioparametrizacion.PAR_VIGENCIA_ALIVIO_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.MODIFICADOPOR), legalalivioparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalAlivioParameters.ESTADO), 1);

            return await GetAsyncFirst<LegalAlivioParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo obtener legal gmf
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns></returns>
        public async Task<LegalGmfParametrizacion> ObtenerLegalGmf()
        {
            return await GetAsyncFirst<LegalGmfParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Metodo Actualizar y Crear legal gmf mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="legalgmfparametrizacion"></param>
        /// <returns></returns>
        public async Task<LegalGmfParametrizacion> CrearLegalGmf(LegalGmfParametrizacion legalgmfparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.ID), legalgmfparametrizacion.PAR_LEG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.GMF), legalgmfparametrizacion.PAR_GMF);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.VIGENCIAGMF), legalgmfparametrizacion.PAR_VIGENCIA_GMF);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.MODIFICADOPOR), legalgmfparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLegalGmfParameters.ESTADO), 1);

            return await GetAsyncFirst<LegalGmfParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo obtener liquidacion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns></returns>
        public async Task<LiquidacionParametrizacion> ObtenerLiquidacion()
        {
            return await GetAsyncFirst<LiquidacionParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Metodo Actualizar y Crear liquidacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="settlementparametrizacion"></param>
        /// <returns></returns>
        public async Task<LiquidacionParametrizacion> CrearLiquidacion(LiquidacionParametrizacion settlementparametrizacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.ID), settlementparametrizacion.PAR_LIQ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.FECHACORTE), settlementparametrizacion.PAR_FECHA_CORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.FECHAPAGO), settlementparametrizacion.PAR_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.MODIFICADOPOR), settlementparametrizacion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLiquidacionParameters.ESTADO), 1);

            return await GetAsyncFirst<LiquidacionParametrizacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener parametros de transaccion
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ParametroTransaccion>> ObtenerParametrosTransaccion()
        {
            return await GetAsyncList<ParametroTransaccion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualizar parametro transaccion
        /// </summary>
        /// <param name="parametrotransaccion"></param>
        /// <returns></returns>
        public async Task<ParametroTransaccion> ActualizarParametroTransaccion(ParametroTransaccion parametrotransaccion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_TRA_ID), parametrotransaccion.PAR_TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CONCEPTO), parametrotransaccion.PAR_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CODIGO), parametrotransaccion.PAR_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_PROCESO), parametrotransaccion.PAR_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CREADO_POR), parametrotransaccion.PAR_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_FECHA_CREACION), parametrotransaccion.PAR_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_MODIFICADO_POR), parametrotransaccion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_FECHA_MODIFICACION), parametrotransaccion.PAR_FECHA_MODIFICACION);

            return await GetAsyncFirst<ParametroTransaccion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Instalar
        /// </summary>
        /// <param name="parametrotransaccion"></param>
        /// <returns></returns>
        public async Task<ParametroTransaccion> CrearParametroTransaccion(ParametroTransaccion parametrotransaccion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CONCEPTO), parametrotransaccion.PAR_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CODIGO), parametrotransaccion.PAR_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_PROCESO), parametrotransaccion.PAR_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_PROCESO), parametrotransaccion.PAR_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_CREADO_POR), parametrotransaccion.PAR_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_FECHA_CREACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_MODIFICADO_POR), parametrotransaccion.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamTransactionParameters.PAR_FECHA_MODIFICACION), DateTime.Now);

            return await GetAsyncFirst<ParametroTransaccion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Metodo para obtener los archivos parametrizados por modalidad
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>14/10/202</date>
        /// <returns>Lista de archivos parametrizados</returns>
        public async Task<IEnumerable<ParametrizacionArchivoModalidad>> ObtenerParametrizacionArchivosModalidad(int tipoModalidadId) {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumParametrizacionArchivosModalidad.TIM_ID), tipoModalidadId);

            return await GetAsyncList<ParametrizacionArchivoModalidad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo para obtener los archivos parametrizados por entidad
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>14/10/202</date>
        /// <returns>Lista de archivos parametrizados</returns>
        public async Task<IEnumerable<ParametrizacionArchivoEntidadEducativa>> ObtenerParametrizacionArchivosEntidadEducativa(string entidadId)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumParametrizacionArchivosEntidadEducativa.ENE_ID), entidadId);

            return await GetAsyncList<ParametrizacionArchivoEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
