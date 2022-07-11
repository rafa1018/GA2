using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Catalogs Core Negocio
    /// <author>Edgar Andrés Riaño</author>
    /// <date>8/03/2021</date>
    /// </summary>
    public class EntidadesBusinessLogic : IEntidadesBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IEntidadesRepository _entidadesRepository;
        private readonly IOptions<BlobStorageOptions> _options;
        private readonly IBlobStorageGenericRepository _blobStorageGenericRepository;

        public EntidadesBusinessLogic(IMapper mapper, IEntidadesRepository entidadesRepository)
        {
            _mapper = mapper;
            _entidadesRepository = entidadesRepository;
        }

        #region EntidadEducativa

        public async Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativa()
        {
            var arespuestaEntidades = await this._entidadesRepository.ObtenerEntidadEducativa();
            IEnumerable<EntidadEducativaDto> entidadEducativaTypes = this._mapper.Map<IEnumerable<EntidadEducativaDto>>(arespuestaEntidades);
            return new Response<IEnumerable<EntidadEducativaDto>> { Data = entidadEducativaTypes };
        }

        /// <summary>
        /// Obtener entidades educativas
        /// </summary>
        /// <author>Hanson Restrepo</author>
        /// <date26/01/2022</date>
        /// <returns>Catalogo direcciones abecedarios</returns>
        public async Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativaDto entidadEducativa)
        {
            var entidadEnt = _mapper.Map<EntidadEducativa>(entidadEducativa);
            IEnumerable<EntidadEducativaDto> entidad = _mapper.Map<IEnumerable<EntidadEducativaDto>>(await _entidadesRepository.ObtenerEntidadEducativaPorNombreNit(entidadEnt));
            return new Response<IEnumerable<EntidadEducativaDto>> { Data = entidad };
        }

        /// <summary>
        /// CrearEntidadEducativa
        /// </summary>
        /// <param name="EntidadEducativa"></param>
        /// <returns></returns>
        public async Task<Response<EntidadEducativaDto>> CrearEntidadEducativa(EntidadEducativaDto EntidadEducativa)
        {
            return new Response<EntidadEducativaDto>
            {
                Data = _mapper.Map<EntidadEducativaDto>(
                    await _entidadesRepository.CrearEntidadEducativa(
                         _mapper.Map<EntidadEducativa>(EntidadEducativa)))
            };
        }

        public async Task<Response<EntidadEducativaDto>> ActualizarEntidadEducativa(EntidadEducativaDto EntidadEducativa)
        {
            return new Response<EntidadEducativaDto>
            {
                Data = _mapper.Map<EntidadEducativaDto>(
                    await _entidadesRepository.ActualizarEntidadEducativa(
                         _mapper.Map<EntidadEducativa>(EntidadEducativa)))
            };
        }

        /// <summary>
        /// EliminarEntidadEducativaPorId
        /// </summary>
        /// <param name="IdEntidadEducativa"></param>
        /// <returns></returns>
        public async Task<Response<EntidadEducativaDto>> EliminarEntidadEducativaPorId(string idEntidadEducativa)
        {
            return new Response<EntidadEducativaDto>
            {
                Data = _mapper.Map<EntidadEducativaDto>(
                    await this._entidadesRepository.EliminarEntidadEducativaPorId(idEntidadEducativa))
            };
        }

        public async Task<Response<IEnumerable<SedeEntidadEducativaDto>>> ObtenerSedesPorEntidadEducativa(string entidadEducativaId)
        {
            IEnumerable<SedeEntidadEducativaDto> sedes = _mapper.Map<IEnumerable<SedeEntidadEducativaDto>>(await _entidadesRepository.ObtenerSedesPorEntidadEducativa(entidadEducativaId));
            return new Response<IEnumerable<SedeEntidadEducativaDto>> { Data = sedes };

        }

        public async Task<Response<SedeEntidadEducativaDto>> CrearSedeEntidadEducativa(SedeEntidadEducativaDto sedeEntidadEducativa)
        {
            return new Response<SedeEntidadEducativaDto>
            {
                Data = _mapper.Map<SedeEntidadEducativaDto>(
                    await _entidadesRepository.CrearSedeEntidadEducativa(
                         _mapper.Map<SedeEntidadEducativa>(sedeEntidadEducativa)))
            };
        }

        public async Task<Response<SedeEntidadEducativaDto>> EliminarSedesEntidadEducativaPorId(string idSedeEntidadEducativa)
        {
            return new Response<SedeEntidadEducativaDto>
            {
                Data = _mapper.Map<SedeEntidadEducativaDto>(
                    await this._entidadesRepository.EliminarSedeEntidadEducativaPorId(idSedeEntidadEducativa))
            };
        }

        public async Task<Response<BloqueoEntidadEducativaDto>> BloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto)
        {
            return new Response<BloqueoEntidadEducativaDto>
            {
                Data = _mapper.Map<BloqueoEntidadEducativaDto>(
                    await _entidadesRepository.BloqueoEntidadEducativa(
                         _mapper.Map<BloqueoEntidadEducativa>(bloqueoEntidadEducativaDto)))
            };
        }

        public async Task<Response<BloqueoEntidadEducativaDto>> DesbloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto)
        {
            return new Response<BloqueoEntidadEducativaDto>
            {
                Data = _mapper.Map<BloqueoEntidadEducativaDto>(
                    await _entidadesRepository.DesbloqueoEntidadEducativa(
                         _mapper.Map<BloqueoEntidadEducativa>(bloqueoEntidadEducativaDto)))
            };
        }

        public async Task<Response<IEnumerable<BloqueoEntidadEducativaDto>>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa)
        {
            IEnumerable<BloqueoEntidadEducativaDto> bloqueo = _mapper.Map<IEnumerable<BloqueoEntidadEducativaDto>>(await _entidadesRepository.ObtenerBloqueoEntidadEducativa(idEntidadEducativa));
            return new Response<IEnumerable<BloqueoEntidadEducativaDto>> { Data = bloqueo };
        }

        public async Task<Response<CuentaBancariaEntidadEducativaDto>> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativa)
        {
            return new Response<CuentaBancariaEntidadEducativaDto>
            {
                Data = _mapper.Map<CuentaBancariaEntidadEducativaDto>(
                    await _entidadesRepository.CrearCuentaBancariaEntidadEducativa(
                         _mapper.Map<CuentaBancariaEntidadEducativa>(cuentaBancariaEntidadEducativa)))
            };
        }

        public async Task<Response<CuentaBancariaEntidadEducativaDto>> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativaDto)
        {
            return new Response<CuentaBancariaEntidadEducativaDto>
            {
                Data = _mapper.Map<CuentaBancariaEntidadEducativaDto>(
                    await _entidadesRepository.ActualizarCuentaBancariaEntidadEducativa(
                         _mapper.Map<CuentaBancariaEntidadEducativa>(cuentaBancariaEntidadEducativaDto)))
            };
        }

        public async Task<Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>> ObtenerCuentaBancariaPorEntidad(string idEntidad)
        {
            IEnumerable<CuentaBancariaEntidadEducativaDto> cuenta = _mapper.Map<IEnumerable<CuentaBancariaEntidadEducativaDto>>(await _entidadesRepository.ObtenerCuentaBancariaPorEntidad(idEntidad));
            return new Response<IEnumerable<CuentaBancariaEntidadEducativaDto>> { Data = cuenta };
        }
        public async Task<Response<CuentaBancariaEntidadEducativaDto>> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta)
        {
            return new Response<CuentaBancariaEntidadEducativaDto>
            {
                Data = _mapper.Map<CuentaBancariaEntidadEducativaDto>(
                    await this._entidadesRepository.EliminarCuentaBancariaEntidadEducativa(idCuenta))
            };
        }


        #endregion EntidadEducativa

        /// <summary>
        /// Obtener programas educativos
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>Lista de programas educativos</returns>
        public async Task<Response<IEnumerable<ProgramaEducativoDto>>> ObtenerProgramaEducativo(Guid idEntidad)
        {
            return new Response<IEnumerable<ProgramaEducativoDto>> { Data = this._mapper.Map<IEnumerable<ProgramaEducativoDto>>(await this._entidadesRepository.ObtenerProgramaEducativo(idEntidad)) };
        }

        /// <summary>
        /// Obtener niveles educativos
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <returns>Lista de niveles educativos</returns>
        public async Task<Response<IEnumerable<NivelEducativoDto>>> ObtenerNivelEducativoCesantias(Guid idPrograma)
        {
            return new Response<IEnumerable<NivelEducativoDto>> { Data = this._mapper.Map<IEnumerable<NivelEducativoDto>>(await this._entidadesRepository.ObtenerNivelEducativoCesantias(idPrograma)) };
        }
        public async Task<Response<IEnumerable<ListarProgramaEducativoDto>>> ObtenerProgramaEducativoPorEntidad(string idEntidad)
        {
            return new Response<IEnumerable<ListarProgramaEducativoDto>> { Data = this._mapper.Map<IEnumerable<ListarProgramaEducativoDto>>(await _entidadesRepository.ObtenerProgramaEducativoPorEntidad(idEntidad)) };
        }
        public async Task<Response<ProgramaEducativoDto>> CrearProgramaEducativo(ProgramaEducativoDto programaEducativo)
        {
            return new Response<ProgramaEducativoDto>
            {
                Data = _mapper.Map<ProgramaEducativoDto>(
             await _entidadesRepository.CrearProgramaEducativo(
                  _mapper.Map<ProgramaEducativo>(programaEducativo)))
            };
        }
        public async Task<Response<ProgramaEducativoDto>> EliminarProgramaEducativoPorId(string idProgramaEducativo)
        {
            return new Response<ProgramaEducativoDto>
            {
                Data = _mapper.Map<ProgramaEducativoDto>(
                    await this._entidadesRepository.EliminarProgramaEducativoPorId(idProgramaEducativo))
            };
        }
        public async Task<Response<ProgramaEducativoDto>> ActualizarProgramaEducativo(ProgramaEducativoDto programaEducativo)
        {
            return new Response<ProgramaEducativoDto>
            {
                Data = _mapper.Map<ProgramaEducativoDto>(
                    await _entidadesRepository.ActualizarProgramaEducativo(
                         _mapper.Map<ProgramaEducativo>(programaEducativo)))
            };
        }

        public async Task<Response<bool>> CargarDocumentosEntidad(List<CargarDocumentosEntidadDto> cargarDocumentosEntidadDto, Guid idEntidad)
        {
            foreach (var x in cargarDocumentosEntidadDto)
            {
                foreach (var y in x.ArchivosCargados)
                {
                    FileStreamResult fileStreamResult = new FileStreamResult(y.OpenReadStream(), y.ContentType);

                    FileInfo fi = new FileInfo(y.FileName);
                    var newName = Path.GetRandomFileName() + fi.Extension.ToLower();
                    var result = await _blobStorageGenericRepository.SubirArchivoBlobStorage("entidades", newName.ToString(), fileStreamResult);

                    InsertarArchivoEntidad insertarArchivoEntidad = new();

                    insertarArchivoEntidad.ENE_NOMBRE_ARCHIVO = fi.Name;
                    insertarArchivoEntidad.ENE_RUTA_STORAGE = newName;
                    insertarArchivoEntidad.ENE_EXTENSION = fi.Extension;
                    insertarArchivoEntidad.ENE_ID = idEntidad;
                    insertarArchivoEntidad.ENE_PAM_ID = x.ArchivoParametrizadoId;
                    insertarArchivoEntidad.ENE_PAM_CREATEDOPOR = new Guid();

                    await _entidadesRepository.InsertarArchivoPorEntidad(insertarArchivoEntidad);
                }
            }
            return new Response<bool> { Data = true };
        }

        public async Task<Response<IEnumerable<ConsultarArchivoPorEntidadDto>>> ConsultarArchivoPorEntidad(Guid IdEntidad)
        {
            IEnumerable<ConsultarArchivoPorEntidadDto> archivo = _mapper.Map<IEnumerable<ConsultarArchivoPorEntidadDto>>(await this._entidadesRepository.ConsultarArchivoPorEntidad(IdEntidad));
            return new Response<IEnumerable<ConsultarArchivoPorEntidadDto>> { Data = archivo, IsSuccess = true, ReturnMessage = "" };
        }

        public async Task<FileResult> DescargarArchivoPorId(string rutaStorage)
        {

            BlobContainerClient container = new(_options.Value.CadenaOne, "entidades");
            BlobClient blob = container.GetBlobClient(rutaStorage);
            BlobDownloadInfo download = await blob.DownloadAsync();

            var descargado = new FileStreamResult(download.Content, download.ContentType)
            {
                FileDownloadName = rutaStorage
            };
            await descargado.FileStream.FlushAsync();

            return descargado;
        }
    }
}
