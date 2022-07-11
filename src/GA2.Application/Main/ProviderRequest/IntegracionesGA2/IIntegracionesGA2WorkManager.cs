using GA2.Application.Dto;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IIntegracionesGA2WorkManager
    {
        Task<object> CargaProductoTercero<TOutput>(Uri url, CargaProductoTerceroRequest cargaProductoTerceroRequest, Guid correlationId, Guid userId);
        Task<object> CargaTercero<TOutput>(Uri url, CargaTerceroRequest cargaTerceroRequest, Guid correlationId, Guid userId);
        Task<object> CargaTransaccion<TOutput>(Uri url, CargaTransaccionRequest cargaTransaccionRequest, Guid correlationId, Guid userId);
        Task<object> FormDeleteAsyncWorkManager<TOutput>(Uri url, DeleteRequest delete, Guid correlationId, Guid userId);
        Task<object> FormGetBase64StringFileAsyncWorkManager<TOutput>(Uri url, StringFileRequest stringFile, Guid correlationId, Guid userId);
        Task<object> FormGetDataAsyncWorkManager<TOutput>(Uri url, QueryRequest query, Guid correlationId, Guid userId);
        Task<object> FormGetFileCodesAsyncWorkManager<TOutput>(Uri url, FileRequest file, Guid correlationId, Guid userId);
        Task<object> FormInsertAsyncWorkManager<TOutput>(Uri url, InsertRequest insert, Guid correlationId, Guid userId);
        Task<object> FormUpdateAsyncWorkManager<TOutput>(Uri url, UpdateRequest update, Guid correlationId, Guid userId);
        Task<object> ListGetItemsAsyncWorkManager<TOutput>(Uri url, ListRequest list, Guid correlationId, Guid userId);
        Task<object> WorkflowAttachFilesAsyncWorkManager<TOutput>(Uri url, WorkflowAttachFilesRequest WorkflowAttachFiles, Guid correlationId, Guid userId);
        //Task<Response<object>> WorkflowRunTaskWorkManager(Uri url, RunTaskRequest runTask, Guid userId);
        //Task<Response<object>> WorkflowStartWorkManager(Uri url, StartWorkflowRequest startWorkFlow, Guid userId);
    }
}
