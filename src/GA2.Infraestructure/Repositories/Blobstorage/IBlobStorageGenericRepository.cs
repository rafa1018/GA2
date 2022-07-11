using Azure.Storage.Blobs.Models;
using GA2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Blobstorage repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>06/05/2021</date>
    public interface IBlobStorageGenericRepository
    {
        /// <summary>
        /// Descarga de archivo storage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Archivo descargado</returns>
        Task<BlobDownloadInfo> DescargarArchivoStorage(String Id);

        /// <summary>
        /// EliminarArchivo Blob storage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Entero de confirmacion de elimancion</returns>
        Task<int> EliminarArchivoStorage(String Id);

        /// <summary>
        /// SubirArchivo blobstorage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Objeto de confirmacion subido</returns>
        Task<CuentaStorage> SubirArchivoStorage(CuentaStorage cuentaStorage);
        
        /// <summary>
        /// SubirArchivo blobstorage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Objeto de confirmacion subido</returns>
        Task<string> SubirArchivoStorage(Stream stream, string containerName, string filename);
        
        /// <summary>
        /// SubirArchivo blobstorage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/05/2021</date>
        /// <returns>Objeto de confirmacion subido</returns>
        Task<CuentaStorage> SubirArchivoStorage(string containerName, string blobName, FileStreamResult file);

        /// <summary>
        /// SubirArchivo blobstorage
        /// </summary>
        /// <param name="cuentaStorage">Cuenta de blob storage</param>
        /// <author>Erwin Pantoja</author>
        /// <date>02/03/2022</date>
        /// <returns>Objeto de confirmacion subido</returns>
        Task<BlobContentInfo> SubirArchivoBlobStorage(string ContainerName, string blobName, FileStreamResult file);

        /// <summary>
        /// Descargar archivo por contenedor y nombre blob
        /// </summary>
        /// <param name="containerName">Nombre contenedor</param>
        /// <param name="blobName">nombre del archivo</param>
        /// <returns>Archivo descargado del blob storage</returns>
        Task<BlobDownloadInfo> DescargarArchivoStorage(string containerName, string blobName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        Task<Azure.Response> EliminarArchivoStorage(string containerName, string blobName);
    }
}