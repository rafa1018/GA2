using GA2.Application.Dto;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Metodo que crea los componenetes que extrae desde el archivo de carga de nómina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class CargaArchivoBusinessLogic : ICargaArchivoBusinessLogic
    {
        /// <summary>
        /// Interface descomposicion de archivo
        /// </summary>
        private readonly IDescomposicionArchivo _descomposicionArchivo;

        /// <summary>
        /// Constructor Carga archivo
        /// </summary>
        /// <param name="descomposicionArchivo">Interface descomposicion de archivos</param>
        public CargaArchivoBusinessLogic(IDescomposicionArchivo descomposicionArchivo)
        {
            _descomposicionArchivo = descomposicionArchivo;
        }

        /// <summary>
        /// Metodo que hace validaciones del archivo y lo descompone en componentes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ComponentesDTO> ValidacionArchivoNomina(Stream streamFile, string fileName,ParamCargueNomDTO parametros, DocumentoDto documento = default)
        {
            var lineasDatosArchivo = await ObtenerLineasDatosArchivoAsync(streamFile);
            NombreArchivoDto filenameDecomposed = await _descomposicionArchivo.DesgloseNombreArchivoAsync(fileName, parametros);
            FinDeArchivoDto finalIdentificatorDecomposed = await _descomposicionArchivo.DesgloseIdentificadorFinal(lineasDatosArchivo, parametros);
            EncabezadoArchivoDto headerDecomposed = await _descomposicionArchivo.DesgloseEncabezado(lineasDatosArchivo, parametros);
            IEnumerable<CuerpoArchivoDto> bodyDecomposed = await _descomposicionArchivo.DesgloseBody(lineasDatosArchivo, parametros);
            return new ComponentesDTO() { DOCUMENTO = documento, FILENAME = filenameDecomposed, HEADER = headerDecomposed, BODY = bodyDecomposed, END = finalIdentificatorDecomposed };
        }

        /// <summary>
        /// Obtener datos del archivo por lineas 
        /// </summary>
        /// <param name="fileStream">Archivo cargado</param>
        /// <returns></returns>
        internal async Task<List<string>> ObtenerLineasDatosArchivoAsync(Stream fileStream)
        {
            List<string> lineasDatos = new List<string>();
            using var reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
                lineasDatos.Add(await reader.ReadLineAsync());

            reader.Close();
            await Task.CompletedTask;

            return lineasDatos;
        }
    }
}

