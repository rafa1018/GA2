using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// LogErrorRepository 
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    public class LogErrorBusinessLogic : ILogErrorBusinessLogic
    {
        private readonly ILogErrorRepository _repository;
        private readonly IConfiguration _configuration;

        public LogErrorBusinessLogic(
            ILogErrorRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /// <summary>
        /// CreateLog Error Insert
        /// </summary>
        /// <param name="error">Error reportado por el middleware</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>22/02/2021</date>
        /// <returns>Response Error</returns>
        public async Task<Response<ERRORRESPONSE>> CreateLogError(ERRORRESPONSE error)
        {
            return new Response<ERRORRESPONSE>
            {
                Data = await this._repository.CreateLogError(error),
                IsSuccess = false,
                ReturnMessage = error.MESSAGE
            };
        }
    }
}
