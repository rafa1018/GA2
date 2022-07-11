using Azure.Storage.Blobs.Models;
using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMovimientoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="esdId"></param>
        /// <returns></returns>
        Task<IEnumerable<Documento>> ObtenerDocumentosCarga(int esdId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        Task<string> ValidarNomina(string json);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        Task<CuentaStorage> ObtenerBlobStoragePorNombre(string nombre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuentaStorage"></param>
        /// <returns></returns>
        Task<BlobDownloadInfo> DescargarArchivoStorage(CuentaStorage cuentaStorage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuentaStorage"></param>
        /// <returns></returns>
        Task<Azure.Response> EliminarArchivoStorage(CuentaStorage cuentaStorage);
    }
}