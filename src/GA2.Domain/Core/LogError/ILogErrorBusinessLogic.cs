using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Interface Error Logica de negocio
    /// </summary>
    public interface ILogErrorBusinessLogic
    {
        /// <summary>
        /// LogErrorRepository 
        /// </summary>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        Task<Response<ERRORRESPONSE>> CreateLogError(ERRORRESPONSE error);
    }
}
