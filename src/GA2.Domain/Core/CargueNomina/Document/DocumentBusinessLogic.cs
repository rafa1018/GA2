using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Descompone la informacion y crea el documento
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class DocumentoBusinessLogic : IDocumentoBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IDocumentoCargaRepository _documentoCargaRepository;
        private readonly ICargaArchivoBusinessLogic cargaArchivoBusinessLogic;

        public DocumentoBusinessLogic(IMapper mapper,
                                      IDocumentoCargaRepository documentoCargaRepository,
                                      ICargaArchivoBusinessLogic cargaArchivoBusinessLogic)
        {
            _mapper = mapper;
            _documentoCargaRepository = documentoCargaRepository;
            this.cargaArchivoBusinessLogic = cargaArchivoBusinessLogic;
        }

        /// <summary>
        /// Metodo que carga la informacion del documento a los componentes
        /// </summary>
        /// <param name="componentesDto">Componenes de cargua (header, body, finarchivo)</param>
        /// <param name="nombreArchivo">Nombre archivo</param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public async Task<DocumentoDto> RegistroDocumento(ComponentesDTO componentesDto, Guid userId, CuentaStorage cuentaStorage)
        {
            DocumentoDto documentoDtoo = new DocumentoDto()
            {
                DocumentoId = cuentaStorage.ID,
                Nombre = cuentaStorage.BLOBNAME,
                TipoDocumentoId = componentesDto.HEADER.FILE_TIPO,
                FechaInicialDocumento = DateTime.Now,
                EstadoDocumento = 1,
                CreadoPor = userId,
                UnidadEjecutora = componentesDto.FILENAME.FILE_UNIDAD_EJECUTORA,
                FechaCreacion = DateTime.Now
            };

            return this._mapper.Map<DocumentoDto>(await this._documentoCargaRepository.CrearDocumentoCarga(this._mapper.Map<Documento>(documentoDtoo)));
        }

        /// <summary>
        /// Obtiene todos los documentos cargados por estado documento
        /// </summary>
        /// <param name="estadoDocumento">Estado Documento</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/05/2021</date>
        /// <returns>Lista de documento por estado</returns>
        public async Task<Response<IEnumerable<DocumentoDto>>> ObtenerDocumentosCarga(int estadoDocumento)
        {
            return new Response<IEnumerable<DocumentoDto>>
            {
                Data = this._mapper.Map<IEnumerable<DocumentoDto>>(
                    await this._documentoCargaRepository.ObtenerDocumentosCarga(estadoDocumento))
            };
        }

        /// <summary>
        /// Validar archivo de carga
        /// </summary>
        /// <param name="stream">Stream del archivo cargado</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <param name="parametros">parametros para validar el archivo</param>
        /// <returns></returns>
        public async Task<ComponentesDTO> ValidarArchivoNomina(Stream stream, string nombreArchivo, ParamCargueNomDTO parametros, DocumentoDto documento= default)
        {
            ComponentesDTO componentes = await cargaArchivoBusinessLogic.ValidacionArchivoNomina(stream,
                                                                                                 nombreArchivo,
                                                                                                 parametros, documento);
            return componentes;
        }

        /// <summary>
        /// Obtiene los documentos por id
        /// </summary>
        /// <param name="documentoId">documentoId</param>
        /// <returns>Documento buscado por id</returns>
        /// <author>Oscar Julian Rojas</author>
        public async Task<Response<DocumentoDto>> ObtenerDocumentosPorId(int documentoId)
        {
            return new Response<DocumentoDto>
            {
                Data = this._mapper.Map<DocumentoDto>(
                   await this._documentoCargaRepository.ObtenerDocumentosPorId(documentoId))
            };
        }

        /// <summary>
        /// Cambiar estado a procesar documento cargue de nomina
        /// </summary>
        /// <param name="documentoId">id documento</param>
        /// <returns>Documento con cambio de estado</returns>
        /// <auhtor>Oscar Julian Rojas</auhtor>
        /// <date>30/09/2021</date>
        public async Task<Response<DocumentoDto>> CambiarEstadoAProcesar(int documentoId)
        {
            return new Response<DocumentoDto>
            {
                Data = this._mapper.Map<DocumentoDto>(
                   await this._documentoCargaRepository.CambiarEstadoAProcesar(documentoId))
            };
        }
    }
}
