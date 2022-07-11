using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IMovimientoBusinessLogic
    {
        /// <summary>
        /// Obtener lista de documento por estado documento
        /// </summary>
        /// <param name="estadoDocumento">Estado de documento carga</param>
        /// <returns>Lista de documento cargados por estado</returns>
        Task<Response<IEnumerable<DocumentoDto>>> ObtenerDocumentosCarga(int estadoDocumento = 0);

        /// <summary>
        /// Metodo para rechazar la nomina cargada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        Task<Response<DocumentoDto>> RechazarCargueNomina(Guid id);

        /// <summary>
        /// Metodo para rechazar la nomina cargada
        /// </summary>
        /// <param name="documentos">documentos a procesar</param>
        /// <returns>Lista de documento aprobados</returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        Task<Response<IEnumerable<DocumentoDto>>> AprobarCargueNomina(IEnumerable<DocumentoDto> documentos);

        /// <summary>
        /// Metodo para relaizar la validacion de la nomina cargada
        /// </summary>
        /// <param name="file"></param>
        /// <param name="userId">Usuario id que realiza el cargue de archivos</param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        Task<Response<DocumentoDto>> CargarArchivoNomina(IFormFile file, Guid userId);
    }
}