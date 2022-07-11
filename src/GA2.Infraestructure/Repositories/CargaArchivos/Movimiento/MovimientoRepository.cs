using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
    /// Clase repository Movimiento de carga de archivos
    /// </summary>
    public class MovimientoRepository : DapperGenerycWorkerRepository, IMovimientoRepository
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construcctor inyectando configuracion de aplicacion
        /// </summary>
        /// <param name="configuration"></param>
        public MovimientoRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Proceso de cargue de archivo
        /// Proceso de base de datos Bua
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<string> ValidarNomina(string json)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(HelpersEnums.GetEnumDescription(EnumEjecutorParameters.Json), json);

            var respuesta = await ValidarNominaAsync<BodyFile>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameter, CommandType.StoredProcedure);

            return JsonConvert.SerializeObject(respuesta);
        }

        /// <summary>
        /// Obtiene los documentos cargados, no consiliados
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/05/2021</date>
        /// <returns>Lista de documentos cargados</returns>
        public async Task<IEnumerable<Documento>> ObtenerDocumentosCarga(int esdId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentParameters.ESD_ID), esdId);
            return await ObtenerDocumentosCarga<Documento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerBlobStoragePorId por id  archivo
        /// </summary>
        /// <param name="ID">Id del blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Archivo Guardado</returns>
        public async Task<CuentaStorage> ObtenerBlobStoragePorNombre(string nombre)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.BLOBNAME), nombre);

            return await ObtenerBlobStoragePorId<CuentaStorage>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo descargar archivos
        /// </summary>
        /// <param name="id">Documento registro del guardado blob</param>
        /// <returns></returns>
        public async Task<BlobDownloadInfo> DescargarArchivoStorage(CuentaStorage cuentaStorage)
        {
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));
            BlobContainerClient container = new BlobContainerClient(_configuration["BlobStorage:CadenaOne"], cuentaStorage.CONTAINERNAME);
            BlobClient blob = container.GetBlobClient(cuentaStorage.BLOBNAME);
            BlobDownloadInfo download = await blob.DownloadAsync();

            return download;
        }

        /// <summary>
        /// Metodo Eliminar archivos
        /// </summary>
        /// <param name="cuentaStorage">registro del guardado blob</param>
        /// <returns></returns>
        public async Task<Azure.Response> EliminarArchivoStorage(CuentaStorage cuentaStorage)
        {
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));
            BlobContainerClient container = new BlobContainerClient(_configuration["BlobStorage:CadenaOne"], cuentaStorage.CONTAINERNAME);
            BlobClient blob = container.GetBlobClient(cuentaStorage.BLOBNAME);
            var delete = await blob.DeleteAsync();

            return delete;
        }
    }
}
