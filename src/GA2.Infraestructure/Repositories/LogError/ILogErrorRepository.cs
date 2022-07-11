using GA2.Domain.Entities;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Interface ILogErrorRepository
    /// </summary>
    public interface ILogErrorRepository
    {
        /// <summary>
        /// CreateLog Error Insert
        /// </summary>
        /// <param name="error">Error reportado por el middleware</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>22/02/2021</date>
        /// <returns>Response Error</returns>
        Task<ERRORRESPONSE> CreateLogError(ERRORRESPONSE error);
    }
}
