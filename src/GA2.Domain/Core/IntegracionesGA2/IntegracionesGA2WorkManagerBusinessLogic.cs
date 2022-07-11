using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Transversals.Commons;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class IntegracionesGA2WorkManagerBusinessLogic : IIntegracionesGA2WorkManagerBusinessLogic
    {
        private readonly IIntegracionesGA2WorkManager _integraciones;

        public IntegracionesGA2WorkManagerBusinessLogic(IIntegracionesGA2WorkManager integraciones)
        {
            _integraciones = integraciones;
        }

        public async Task<Response<InsertResponseDto>> FormInsertWorkManager(Uri url, InsertRequest insert, Guid userId)
        {
            var response = new Response<InsertResponseDto>();
            var stringResultado = JsonConvert.SerializeObject(insert);
            var result = await _integraciones.FormInsertAsyncWorkManager<InsertResponseDto>(url, insert, response.GetCorrelation(), userId);
            response = JsonConvert.DeserializeObject<Response<InsertResponseDto>>(JsonConvert.SerializeObject(result));
            return response;
        }

        public async Task<Response<object>> FormUpdateWorkManager(Uri url, UpdateRequest update, Guid userId)
        {
            var response = new Response<object>();
            var stringResultado = JsonConvert.SerializeObject(update);
            var result = await _integraciones.FormUpdateAsyncWorkManager<object>(url, update, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        public async Task<Response<object>> FormDeleteWorkManager(Uri url, DeleteRequest delete, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.FormDeleteAsyncWorkManager<object>(url, delete, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        public async Task<Response<object>> FormGetDataWorkManager(Uri url, QueryRequest query, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.FormGetDataAsyncWorkManager<object>(url, query, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
        public async Task<Response<object>> FormGetFileCodesWorkManager(Uri url, FileRequest file, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.FormGetFileCodesAsyncWorkManager<object>(url, file, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        public async Task<Response<object>> FormGetBase64StringFileWorkManager(Uri url, StringFileRequest stringFile, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.FormGetBase64StringFileAsyncWorkManager<object>(url, stringFile, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        //public async Task<Response<object>> WorkflowStartWorkManager(Uri url, StartWorkflowRequest startWorkFlow, Guid userId)
        //{
        //    var response = new Response<object>();
        //    var result = await _integraciones.WorkflowStartAsyncWorkManager<object>(url, startWorkFlow, response.GetCorrelation(), userId);
        //    response.Data = JsonConvert.SerializeObject(result);
        //    return response;
        //}

        public async Task<Response<object>> WorkflowAttachFilesWorkManager(Uri url, WorkflowAttachFilesRequest WorkflowAttachFiles, Guid userId)
        {
            var response = new Response<object>();
            var stringResultado = JsonConvert.SerializeObject(WorkflowAttachFiles);
            var result = await _integraciones.WorkflowAttachFilesAsyncWorkManager<object>(url, WorkflowAttachFiles, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        //public async Task<Response<object>> WorkflowRunTaskWorkManager(Uri url, RunTaskRequest runTask, Guid userId)
        //{
        //    var response = new Response<object>();
        //    var result = await _integraciones.WorkflowRunTaskAsyncWorkManager<object>(url, runTask, response.GetCorrelation(), userId);
        //    response.Data = JsonConvert.SerializeObject(result);
        //    return response;
        //}

        public async Task<Response<object>> ListGetItemsWorkManager(Uri url, ListRequest list, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.ListGetItemsAsyncWorkManager<object>(url, list, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
    }
}
