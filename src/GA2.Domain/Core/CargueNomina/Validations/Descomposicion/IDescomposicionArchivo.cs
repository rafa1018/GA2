using GA2.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IDescomposicionArchivo
    {
        /// <summary>
        /// Metodo que 
        /// </summary>
        /// <param name="lineasDatos">Lista de datos cargados de archivo</param>
        /// <param name="param">Parametro de archivo</param>
        /// <returns>Lista de BodyFileReported</returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        Task<IEnumerable<CuerpoArchivoDto>> DesgloseBody(List<string> lineasDatos, ParamCargueNomDTO param);

        /// <summary>
        /// Metodo que descompone el encabezado dle archivo en sus variables 
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        /// <param name="file">Archivo recibido</param>
        /// <returns>HeaderFileReported</returns>
        Task<EncabezadoArchivoDto> DesgloseEncabezado(List<string> lineasDatos, ParamCargueNomDTO param);

        /// <summary>
        /// Valida el identificador final del archivo y lo compara con los registros
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        /// <param name="file">Archivo a evaluar</param>
        /// <param name="para">Parametros obtenidos de base datos</param>
        /// <returns>EndFileReported</returns>
        Task<FinDeArchivoDto> DesgloseIdentificadorFinal(List<string> LineasDatos, ParamCargueNomDTO param);

        /// <summary>
        /// Metodo que lee el nombre del archivo y lo descompone en variables
        /// </summary>
        /// <param name="file">Archivo recibido</param>
        /// <returns>FilenameReported</returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        Task<NombreArchivoDto> DesgloseNombreArchivoAsync(string fileName, ParamCargueNomDTO param);
    }
}