using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2 : IIntegracionesGA2WorkManager
    {
        #region WorkManager

        public async Task<object> FormInsertAsyncWorkManager<TOutput>(Uri url, InsertRequest insert, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            var retorno = await PostExternalAsync<object>(insert, url, headers);
            return retorno;
        }
        public async Task<object> FormUpdateAsyncWorkManager<TOutput>(Uri url, UpdateRequest update, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(update, url, headers);
        }

        public async Task<object> FormDeleteAsyncWorkManager<TOutput>(Uri url, DeleteRequest delete, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(delete, url, headers);
        }

        public async Task<object> FormGetDataAsyncWorkManager<TOutput>(Uri url, QueryRequest query, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(query, url, headers);
        }

        public async Task<object> FormGetFileCodesAsyncWorkManager<TOutput>(Uri url, FileRequest file, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(file, url, headers);
        }

        public async Task<object> FormGetBase64StringFileAsyncWorkManager<TOutput>(Uri url, StringFileRequest stringFile, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(stringFile, url, headers);
        }

        public async Task<object> WorkflowStartAsyncWorkManager<TOutput>(Uri url, StartWorkflowRequest startWorkFlow, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(startWorkFlow, url, headers);
        }

        public async Task<object> WorkflowAttachFilesAsyncWorkManager<TOutput>(Uri url, WorkflowAttachFilesRequest workFlowAttach, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(workFlowAttach, url, headers);
        }

        public async Task<object> WorkflowRunTaskAsyncWorkManager<TOutput>(Uri url, RunTaskRequest runTask, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(runTask, url, headers);
        }

        public async Task<object> ListGetItemsAsyncWorkManager<TOutput>(Uri url, ListRequest list, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(list, url, headers);
        }

        #endregion

    }
}
