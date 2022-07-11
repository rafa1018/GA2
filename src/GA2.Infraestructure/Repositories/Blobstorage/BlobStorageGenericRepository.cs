using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repository generico para menejar el blobstorage
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>16/04/2021</date>
    public class BlobStorageGenericRepository : DapperGenerycRepository, IBlobStorageGenericRepository
    {
        /// <summary>
        /// Options blob storage 
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        private readonly BlobStorageOptions _options;

        /// <summary>
        /// Constructor BlobStorage
        /// </summary>
        /// <param name="configuration">Configuracion aplicacion</param>
        public BlobStorageGenericRepository(IConfiguration configuration, IOptions<BlobStorageOptions> options) : base(configuration)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Metodo subir Archivo
        /// </summary>
        /// <param name="cuentaStorage">Cuenta Storage asignada</param>
        /// <returns>CuentaStorage de archivo subido</returns>
        public async Task<CuentaStorage> SubirArchivoStorage(CuentaStorage cuentaStorage)
        {
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));
            StreamReader streamreader = new StreamReader(cuentaStorage.FILE);
            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, cuentaStorage.CONTAINERNAME);
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(cuentaStorage.BLOBNAME);
            var result = await blob.UploadAsync(streamreader.BaseStream);
            if (result != null) return await this.GuardarBlobStorage(cuentaStorage);
            return null;
        }
        
        /// <summary>
        /// Metodo subir Archivo
        /// </summary>
        /// <param name="cuentaStorage">Cuenta Storage asignada</param>
        /// <returns>CuentaStorage de archivo subido</returns>
        public async Task<string> SubirArchivoStorage(Stream stream, string containerName, string filename)
        {
            BlobContainerClient container = new BlobContainerClient(_options.CadenaOne, containerName);
            await container.CreateIfNotExistsAsync();
            var newName = filename;
            BlobClient blob = container.GetBlobClient(newName);
            stream.Position = 0;
            var result = await blob.UploadAsync(stream);
            return newName;
        }
        
        /// <summary>
        /// Metodo subir Archivo
        /// </summary>
        /// <param name="cuentaStorage">Cuenta Storage asignada</param>
        /// <returns>CuentaStorage de archivo subido</returns>
        public async Task<CuentaStorage> SubirArchivoStorage(string ContainerName, string blobName, FileStreamResult file)
        {
            StreamReader streamreader = new StreamReader(file.FileStream);
            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, ContainerName);
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(blobName);
            var result = await blob.UploadAsync(streamreader.BaseStream);
            return null;
        }


        /// <summary>
        /// Metodo subir Archivo
        /// </summary>
        /// <param name="cuentaStorage">Cuenta Storage asignada</param>
        /// <returns>CuentaStorage de archivo subido</returns>
        public async Task<BlobContentInfo> SubirArchivoBlobStorage(string ContainerName, string blobName, FileStreamResult file)
        {
            StreamReader streamreader = new StreamReader(file.FileStream);
            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, ContainerName);
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(blobName);
            return await blob.UploadAsync(streamreader.BaseStream);
        }

        /// <summary>
        /// Metodo descargar archivos
        /// </summary>
        /// <param name="Id">Id documento registro del guardado blob</param>
        /// <returns>Archivo blob</returns>
        public async Task<BlobDownloadInfo> DescargarArchivoStorage(String Id)
        {
            var cuentaStorage = await this.ObtenerBlobStoragePorId(Id);
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));

            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, cuentaStorage.CONTAINERNAME);
            BlobClient blob = container.GetBlobClient(cuentaStorage.BLOBNAME);
            BlobDownloadInfo download = await blob.DownloadAsync();

            return download;
        }

        /// <summary>
        /// Metodo descargar archivos
        /// </summary>
        /// <param name="cuentaStorage">Cuenta storage registrada para descargar</param>
        /// <returns>Archivo tipo blob</returns>
        public async Task<BlobDownloadInfo> DescargarArchivoStorage(CuentaStorage cuentaStorage)
        {
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));

            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, cuentaStorage.CONTAINERNAME);
            BlobClient blob = container.GetBlobClient(cuentaStorage.BLOBNAME);
            BlobDownloadInfo download = await blob.DownloadAsync();

            return download;
        }
            
        /// <summary>
        /// Metodo descargar archivos
        /// </summary>
        /// <param name="containerName">Nombre contenedor</param>
        /// <param name="blobName">Nombre archivo</param>
        /// <returns>Archivo tipo blob</returns>
        public async Task<BlobDownloadInfo> DescargarArchivoStorage(string containerName, string blobName)
        {
            var descripcion = (containerName, blobName);
            if (string.IsNullOrEmpty(descripcion.blobName)
                && string.IsNullOrEmpty(descripcion.containerName)) throw new ArgumentNullException(nameof(descripcion));

            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, descripcion.containerName);
            BlobClient blob = container.GetBlobClient(descripcion.blobName);
            BlobDownloadInfo download = await blob.DownloadAsync();

            return download;
        }

        /// <summary>
        /// Metodo descargar archivos
        /// </summary>
        /// <param name="containerName">Nombre contenedor</param>
        /// <param name="blobName">Nombre archivo</param>
        /// <returns></returns>
        public async Task<Azure.Response> EliminarArchivoStorage(string containerName, string blobName)
        {
            var descripcion = (containerName, blobName);
            if (string.IsNullOrEmpty(descripcion.blobName)
                && string.IsNullOrEmpty(descripcion.containerName)) throw new ArgumentNullException(nameof(descripcion));

            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, descripcion.containerName);
            BlobClient blob = container.GetBlobClient(descripcion.blobName);
            var delete = await blob.DeleteAsync();

            return delete;
        }

        /// <summary>
        /// Eliminar archivos
        /// </summary>
        /// <param name="Id">CuentaStorage a eleminar</param>
        /// <returns>Numero entero de confirmacion</returns>
        public async Task<int> EliminarArchivoStorage(String Id)
        {
            var cuentaStorage = await this.ObtenerBlobStoragePorId(Id);
            if (cuentaStorage is null) throw new ArgumentNullException(nameof(cuentaStorage));

            BlobContainerClient container = new BlobContainerClient(this._options.CadenaOne, cuentaStorage.CONTAINERNAME);
            var result = await container.DeleteAsync();
            if (result != null) await this.EliminarBlobStoragePorId(cuentaStorage.ID);

            return result.Status;
        }
        

        /// <summary>
        /// Guardar archivo
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Archivo Guardado</returns>
        private async Task<CuentaStorage> GuardarBlobStorage(CuentaStorage cuentaStorage)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.CONTAINERNAME), cuentaStorage.CONTAINERNAME);
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.MODULO), cuentaStorage.MODULO);
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.BLOBNAME), cuentaStorage.BLOBNAME);
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.CREADOPOR), cuentaStorage.CREADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.FECHACREACION), cuentaStorage.FECHACREACION);

            return await GetAsyncFirst<CuentaStorage>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarBloStorage por id  archivo
        /// </summary>
        /// <param name="ID">Id del blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Archivo Guardado</returns>
        private async Task<CuentaStorage> EliminarBlobStoragePorId(int ID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.ID), ID);

            return await GetAsyncFirst<CuentaStorage>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerBlobStoragePorId por id  archivo
        /// </summary>
        /// <param name="ID">Id del blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Archivo Guardado</returns>
        private async Task<CuentaStorage> ObtenerBlobStoragePorId(String ID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.ID), int.Parse(ID));

            return await GetAsyncFirst<CuentaStorage>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }
    }
}
