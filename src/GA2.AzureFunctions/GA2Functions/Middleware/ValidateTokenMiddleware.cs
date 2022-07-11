using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GA2Functions.Middleware
{
    public class ValidateTokenMiddleware: IFunctionsWorkerMiddleware
    {
       
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await Task.CompletedTask;
                var algocontext = context;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
