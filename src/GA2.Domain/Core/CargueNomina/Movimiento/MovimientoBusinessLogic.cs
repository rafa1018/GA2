using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Logica de negocio para el movimiento de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class MovimientoBusinessLogic : IMovimientoBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IParamCargueNominaRepository _paramCargueNominaRepository;
        private readonly IBlobStorageGenericRepository _blobStorageGenericRepository;
        private readonly IDocumentoBusinessLogic _documentoBusinessLogic;
        private readonly IMensajeRepository _mensajeRepository;
        private readonly ICuentaRepository _cuentaRepository;

        /// <summary>
        /// Movimiento de logica de negocio carga de archivos
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="paramCargueNominaRepository"></param>
        /// <param name="blobStorageGenericRepository"></param>
        /// <param name="documentoBusinessLogic"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>22/05/2021</date>
        public MovimientoBusinessLogic(IMapper mapper,
                                       IParamCargueNominaRepository paramCargueNominaRepository,
                                       IBlobStorageGenericRepository blobStorageGenericRepository,
                                       IDocumentoBusinessLogic documentoBusinessLogic,
                                       IClientRequestProvider clientRequestProvider,
                                       IMensajeRepository mensajeRepository,
                                       ICuentaRepository cuentaRepository)
        {
            _mapper = mapper;
            _paramCargueNominaRepository = paramCargueNominaRepository;
            _blobStorageGenericRepository = blobStorageGenericRepository;
            _documentoBusinessLogic = documentoBusinessLogic;
            _mensajeRepository = mensajeRepository;
            _cuentaRepository = cuentaRepository;
        }

        /// <summary>
        /// Metodo para relaizar la validacion de la nomina cargada
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public async Task<Response<DocumentoDto>> CargarArchivoNomina(IFormFile file, Guid userId)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            var version = 1;

            var parametros = this._mapper.Map<ParamCargueNomDTO>(
                await this._paramCargueNominaRepository.ObtenerParametrosCargueNomina(version));

            var componentes = await _documentoBusinessLogic.ValidarArchivoNomina(file.OpenReadStream(),
                                                                                 file.FileName,
                                                                                 parametros);

            var fileJson = JsonConvert.SerializeObject(componentes);
            byte[] buffer = Encoding.ASCII.GetBytes(fileJson);
            MemoryStream ms = new(buffer);


            var blob = await _blobStorageGenericRepository.SubirArchivoStorage(new CuentaStorage
            {
                FILE = ms,
                BLOBNAME = file.FileName.ToLower(),
                MODULO = CargueNominaConstans.BlobName,
                CONTAINERNAME = CargueNominaConstans.BlobName
            });

            if (blob != null)
            {
                componentes.DOCUMENTO = await this._documentoBusinessLogic.RegistroDocumento(componentes, userId, blob);
                componentes.DOCUMENTO.Nombre = blob.BLOBNAME;
                return new Response<DocumentoDto> { Data = componentes.DOCUMENTO, ReturnMessage = CargueNominaConstans.ArchivoCargado };
            }
            return new Response<DocumentoDto> { Data = null, ReturnMessage = CargueNominaConstans.ErrorCargaArchivo };
        }

        /// <summary>
        /// Metodo para rechazar la nomina cargada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public async Task<Response<DocumentoDto>> RechazarCargueNomina(Guid id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para rechazar la nomina cargada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public async Task<Response<IEnumerable<DocumentoDto>>> AprobarCargueNomina(IEnumerable<DocumentoDto> documentos)
        {
            if (documentos == null) throw new ArgumentNullException(nameof(documentos));
            foreach (var item in documentos)
            {
                await _documentoBusinessLogic.CambiarEstadoAProcesar(item.DocumentoId);
            }

            var mensaje = await _mensajeRepository.ObtenerMensaje("25");
            var listaDocumento = await this._documentoBusinessLogic.ObtenerDocumentosCarga(1);

            return new Response<IEnumerable<DocumentoDto>> { Data = listaDocumento?.Data, ReturnMessage = mensaje.MSJ_MENSAJE };
        }

        /// <summary>
        /// Obtener lista de documento por estado documento
        /// </summary>
        /// <param name="estadoDocumento">Estado de documento carga</param>
        /// <returns>Lista de documento cargados por estado</returns>
        public async Task<Response<IEnumerable<DocumentoDto>>> ObtenerDocumentosCarga(int estadoDocumento = 6 & 7)
        {
            return await this._documentoBusinessLogic.ObtenerDocumentosCarga(estadoDocumento);
        }
    }
}
