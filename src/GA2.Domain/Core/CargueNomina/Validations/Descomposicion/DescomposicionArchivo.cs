using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class DescomposicionArchivo : IDescomposicionArchivo
    {
        private readonly ICatalogosRepository _catalogosRepository;
        private readonly IMensajeRepository _mensajeRepository;

        public DescomposicionArchivo(ICatalogosRepository catalogosRepository, IMensajeRepository mensajeRepository)
        {
            _catalogosRepository = catalogosRepository;
            _mensajeRepository = mensajeRepository;
        }

        /// <summary>
        /// Metodo que 
        /// </summary>
        /// <param name="lineasDatos">Lista de datos cargados de archivo</param>
        /// <param name="param">Parametro de archivo</param>
        /// <returns>Lista de BodyFileReported</returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        public async Task<IEnumerable<CuerpoArchivoDto>> DesgloseBody(List<string> lineasDatos, ParamCargueNomDTO param)
        {
            List<CuerpoArchivoDto> cuerpoArchivo = new List<CuerpoArchivoDto>();
            var primeraLinea = lineasDatos.First();
            int linea = default;

            var validacionesTablas = new ValidacionesTablas
            {
                UnidadesEjecutoras = await this._catalogosRepository.ObtenerUnidadesEjecutoras(),
                Grados = await this._catalogosRepository.ObtenerGrados(),
                //var unidadesOperativas =await  this._catalogosRepository.ObtenerUnidadesOperativas();
                TiposIdentificacion = await this._catalogosRepository.ObtenerTiposIdentificacion(),
                Fuerzas = await this._catalogosRepository.ObtenerFuerzas()
            };

            var mensaje5 = await _mensajeRepository.ObtenerMensaje("30");
            var mensaje6 = await _mensajeRepository.ObtenerMensaje("31");
            var mensaje7 = await _mensajeRepository.ObtenerMensaje("32");

            var mensajeValidacion = new MensajeValidaciones
            {
                Mensaje5 = mensaje5,
                Mensaje6 = mensaje6,
                Mensaje7 = mensaje7
            };

            lineasDatos.ForEach(async x =>
            {
                ++linea;
                if (lineasDatos.First() != x)
                {
                    if (lineasDatos.Last() != x)
                    {
                        var cuerpo = new CuerpoArchivoDto
                        {
                            CONSECUTIVE = int.Parse(x.Substring(param.PAR_CUER_CONSEC_INI, param.PAR_CUER_CONSEC_LEN), CultureInfo.InvariantCulture),
                            DIGITO_FUERZA = int.Parse(x.Substring(param.PAR_CUER_DIGITO_FUERZA_INI, param.PAR_CUER_DIGITO_FUERZA_LEN), CultureInfo.InvariantCulture),
                            UNIDAD_EJECUTORA = int.Parse(x.Substring(param.PAR_CUER_UNI_EJECUTORA_INI, param.PAR_CUER_UNI_EJECUTORA_LEN), CultureInfo.InvariantCulture),
                            TIPO_IDENTIFICACION = int.Parse(x.Substring(param.PAR_CUER_TIPO_ID_INI, param.PAR_CUER_TIPO_ID_LEN), CultureInfo.InvariantCulture),
                            IDENTIFICACION = int.Parse(x.Substring(param.PAR_CUER_IDENTIFICACION_INI, param.PAR_CUER_IDENTIFICACION_LEN).Trim()).ToString(),
                            CODIGO_MILITAR = int.Parse(x.Substring(param.PAR_CUER_COD_MILITAR_INI, param.PAR_CUER_COD_MILITAR_LEN), CultureInfo.InvariantCulture),
                            PRIMER_NOMBRE = x.Substring(param.PAR_CUER_PRIMER_NOMBRE_INI, param.PAR_CUER_PRIMER_NOMBRE_LEN).Trim(),
                            SEGUNDO_NOMBRE = x.Substring(param.PAR_CUER_SEGUNDO_NOMBRE_INI, param.PAR_CUER_SEGUNDO_NOMBRE_LEN).Trim(),
                            PRIMER_APELLIDO = x.Substring(param.PAR_CUER_PRIMER_APELLIDO_INI, param.PAR_CUER_PRIMER_APELLIDO_LEN).Trim(),
                            SEGUNDO_APELLIDO = x.Substring(param.PAR_CUER_SEGUNDO_APELLIDO_INI, param.PAR_CUER_SEGUNDO_APELLIDO_LEN).Trim(),
                            EMBARGO = int.Parse(x.Substring(param.PAR_CUER_EMBARGO_INI, param.PAR_CUER_EMBARGO_LEN), CultureInfo.InvariantCulture),
                            INGRESO_BASE_CALCULO = decimal.Parse(x.Substring(param.PAR_CUER_INGRESO_BASE_INI, param.PAR_CUER_INGRESO_BASE_LEN), CultureInfo.InvariantCulture),
                            VALOR = decimal.Parse(x.Substring(param.PAR_CUER_VALOR_INI, param.PAR_CUER_VALOR_LEN), CultureInfo.InvariantCulture),
                            PERIODO = DateTime.ParseExact(x.Substring(param.PAR_CUER_PERIODO_INI, param.PAR_CUER_PERIODO_LEN), "yyyy/MM/dd", CultureInfo.CurrentCulture),
                            GRADO = int.Parse(x.Substring(param.PAR_CUER_GRADO_INI, param.PAR_CUER_GRADO_LEN), CultureInfo.InvariantCulture),
                            UNIDAD_OPERATIVA = int.Parse(x.Substring(param.PAR_CUER_UNIDAD_OPERATIVA_INI, param.PAR_CUER_UNIDAD_OPERATIVA_LEN), CultureInfo.InvariantCulture)
                        };
                        await this.ValidacionesCuerpoArchivoAsync(validacionesTablas, cuerpo, linea, mensajeValidacion);
                        cuerpoArchivo.Add(cuerpo);
                    }
                }
            });

            await Task.CompletedTask;
            return cuerpoArchivo;
        }

        /// <summary>
        /// Metodo que lee el nombre del archivo y lo descompone en variables
        /// </summary>
        /// <param name="file">Archivo recibido</param>
        /// <returns>FilenameReported</returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        public async Task<NombreArchivoDto> DesgloseNombreArchivoAsync(string fileName, ParamCargueNomDTO param)
        {
            if (param == null) throw new ArgumentNullException(nameof(param));

            var tipoArchivo = fileName.Substring(param.PAR_NOM_TIPO_ARCHIVO_REPORTADO_INI, param.PAR_NOM_TIPO_ARCHIVO_REPORTADO_LEN);
            var categoria = fileName.Substring(param.PAR_NOM_CLASIF_ARCHIVO_INI, param.PAR_NOM_CLASIF_ARCHIVO_LEN);
            var periodoAportes = fileName.Substring(param.PAR_NOM_PERIODO_APORTES_INI, param.PAR_NOM_PERIODO_APORTES_LEN);
            var unidadEjecutora = fileName.Substring(param.PAR_NOM_COD_UNID_EJECUTORA_INI, param.PAR_NOM_COD_UNID_EJECUTORA_LEN);
            var fechaEnvio = fileName.Substring(param.PAR_NOM_FECHA_ENVIO_INI, param.PAR_NOM_FECHA_ENVIO_LEN);

            var archivo = new NombreArchivoDto
            {
                FILE_TIPO = tipoArchivo,
                FILE_CATEGORIA = categoria,
                FILE_PERIODOS_APORTES = DateTime.ParseExact(periodoAportes, CargueNominaConstans.FormatTimeStringPeriodoAportes, CultureInfo.CurrentCulture),
                FILE_UNIDAD_EJECUTORA = int.Parse(unidadEjecutora, CultureInfo.InvariantCulture),
                FILE_FECHA_ENVIO = DateTime.ParseExact(fechaEnvio, CargueNominaConstans.FormatTimeStringFechaEnvio, CultureInfo.CurrentCulture)
            };

            await Task.CompletedTask;

            return archivo;
        }

        /// <summary>
        /// Valida el identificador final del archivo y lo compara con los registros
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        /// <param name="file">Archivo a evaluar</param>
        /// <param name="para">Parametros obtenidos de base datos</param>
        /// <returns>EndFileReported</returns>
        public async Task<FinDeArchivoDto> DesgloseIdentificadorFinal(List<string> LineasDatos, ParamCargueNomDTO param)
        {
            decimal sumatoriaAportes = default, comparacionValores = default;
            long consecutivo = default, indicadorControl = default;
            string codigoFinal = default, valorBase = default;

            var lineaFinal = LineasDatos.Last();
            LineasDatos.ForEach(x =>
            {
                if (x != LineasDatos.FirstOrDefault())
                    if (!string.IsNullOrWhiteSpace(x))
                        if (x != lineaFinal)
                        {
                            valorBase = x.Substring(param.PAR_CUER_VALOR_INI, param.PAR_CUER_VALOR_LEN);
                            sumatoriaAportes += decimal.Parse(valorBase, CultureInfo.InvariantCulture);
                        }
            });

            await Task.CompletedTask;

            var totalValorlineaFinal = lineaFinal.Substring(param.PAR_FIN_SUM_APORTES_INI, param.PAR_FIN_SUM_APORTES_LEN);
            comparacionValores = decimal.Parse(totalValorlineaFinal, CultureInfo.InvariantCulture);
            var mensaje1 = await _mensajeRepository.ObtenerMensaje("26");
            var mensaje2 = await _mensajeRepository.ObtenerMensaje("27");
            var mensaje3 = await _mensajeRepository.ObtenerMensaje("28");
         

            if (comparacionValores != sumatoriaAportes) throw new Exception(mensaje1.MSJ_MENSAJE);
            consecutivo = long.Parse(lineaFinal.Substring(param.PAR_FIN_CONSEC_INI, param.PAR_FIN_CONSEC_LEN));
            if (!consecutivo.Equals(LineasDatos.Count())) throw new Exception(mensaje2.MSJ_MENSAJE);

            indicadorControl = long.Parse(lineaFinal.Substring(param.PAR_FIN_INDICADOR_CONTROL_INI, param.PAR_FIN_INDICADOR_CONTROL_LEN));
            codigoFinal = lineaFinal.Substring(param.PAR_FIN_COD_FIN_INI, param.PAR_FIN_COD_FIN_LEN);

            if (!string.IsNullOrWhiteSpace(codigoFinal))
                if (codigoFinal != "999") throw new Exception(mensaje3.MSJ_MENSAJE);

            return new FinDeArchivoDto
            {
                CONSECUTIVE = consecutivo,
                FILE_CONTROL_INDICATOR = indicadorControl,
                END_FILE_CODE = int.Parse(codigoFinal, CultureInfo.InvariantCulture),
                SUM_CONTRIBUTIONS = sumatoriaAportes
            };
        }

        /// <summary>
        /// Metodo que descompone el encabezado dle archivo en sus variables 
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        /// <param name="file">Archivo recibido</param>
        /// <returns>HeaderFileReported</returns>
        public async Task<EncabezadoArchivoDto> DesgloseEncabezado(List<string> lineasDatos, ParamCargueNomDTO param)
        {
            var primeraLinea = lineasDatos.First();

            string consecutivo = primeraLinea.Substring(param.PAR_ENC_CONSEC_INI, param.PAR_ENC_CONSEC_LEN);
            string tipoArchivo = primeraLinea.Substring(param.PAR_ENC_TIPO_ARCHIVO_INI, param.PAR_ENC_TIPO_ARCHIVO_LEN);
            string nombreNominaUnidad = primeraLinea.Substring(param.PAR_ENC_NOMB_NOMINA_UNI_EJECUTORA_INI, param.PAR_ENC_NOMB_NOMINA_UNI_EJECUTORA_LEN);
            string codigoUnidad = primeraLinea.Substring(param.PAR_ENC_COD_UNI_EJECUTORA_INI, param.PAR_ENC_COD_UNI_EJECUTORA_LEN);
            string periodoAportes = primeraLinea.Substring(param.PAR_ENC_PERIODO_APORTES_INI, param.PAR_ENC_PERIODO_APORTES_LEN);


            var conceptos = await this._catalogosRepository.ObtenerConceptos();
            var conceptoHomologados = await this._catalogosRepository.ObtenerConceptosHomologados();
            var conceptoExiste = (from i in conceptos
                                  join h in conceptoHomologados on i.CNC_ID equals h.CNC_ID
                                  where h.CNH_CONCEPTO_CARGA.Contains(tipoArchivo)
                                  select new Concepto
                                  {
                                      CNC_ID = i.CNC_ID,
                                      CAT_TIPO_CONCEPTO = i.CAT_TIPO_CONCEPTO,
                                      CNC_DESCRIPCION = i.CNC_DESCRIPCION,
                                      CNC_FORMULA_CALCULO = i.CNC_FORMULA_CALCULO,
                                      CNC_INTERES = i.CNC_INTERES,
                                      CNC_ORDEN = i.CNC_ORDEN
                                  });

            var mensaje4 = await _mensajeRepository.ObtenerMensaje("29");
          

            if (conceptoExiste == null) throw new Exception(mensaje4.MSJ_MENSAJE);


            return new EncabezadoArchivoDto
            {
                CONSECUTIVE = int.Parse(consecutivo, CultureInfo.InvariantCulture),
                FILE_TIPO = int.Parse(tipoArchivo, CultureInfo.InvariantCulture),
                ID_UNIDAD_EJECUTORA = int.Parse(codigoUnidad, CultureInfo.InvariantCulture),
                NOMBRE_NOMINA_UNIDAD_EJECUTORA = nombreNominaUnidad,
                FECHA_APORTES = DateTime.ParseExact(periodoAportes, "yyyyMM", CultureInfo.CurrentCulture)
            };
        }

        private async Task ValidacionesCuerpoArchivoAsync(ValidacionesTablas validaciones, CuerpoArchivoDto cuerpo, int linea, MensajeValidaciones mensajes)
        {
            //var grado = validaciones.Grados.Where(x => x.GRD_ID == cuerpo.GRADO).FirstOrDefault();
            //if (grado == null) throw new Exception($"linea:{linea}:Grado no existe en los catalagos");
            var unidadEjecutora = validaciones.UnidadesEjecutoras.Where(x => x.UEJ_ID == cuerpo.UNIDAD_EJECUTORA).FirstOrDefault();
            if (unidadEjecutora == null) throw new Exception($"linea:{linea}: {mensajes.Mensaje5.MSJ_MENSAJE}");
            var fuerza = validaciones.Fuerzas.Where(x => x.FRZ_DIGITO == cuerpo.DIGITO_FUERZA).FirstOrDefault();
            if (fuerza == null) throw new Exception($"linea:{linea}: {mensajes.Mensaje6.MSJ_MENSAJE}");
            var tipoIdentificacion = validaciones.TiposIdentificacion.Where(x => x.TID_ID == cuerpo.TIPO_IDENTIFICACION).FirstOrDefault();
            if (tipoIdentificacion == null) throw new Exception($"linea:{linea}: {mensajes.Mensaje7.MSJ_MENSAJE}");
            await Task.CompletedTask;
        }

        public class ValidacionesTablas
        {
            public IEnumerable<Entities.Grado> Grados { get; set; }
            public IEnumerable<UnidadEjecutora> UnidadesEjecutoras { get; set; }
            //public IEnumerable<UnidadesOperativas> UnidadesOperativas { get; set; }
            public IEnumerable<TipoIdentificacion> TiposIdentificacion { get; set; }
            public IEnumerable<Entities.Fuerzas> Fuerzas { get; set; }

        }

        public class MensajeValidaciones
        {
            public Mensaje Mensaje5 { get; set; }
            public Mensaje Mensaje6 { get; set; }
            public Mensaje Mensaje7 { get; set; }

        }
    }
}
