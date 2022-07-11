using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IIntegracionesGA2WorkManagerBusinessLogic
    {
        Task<Response<object>> FormDeleteWorkManager(Uri url, DeleteRequest delete, Guid userId);
        Task<Response<object>> FormGetBase64StringFileWorkManager(Uri url, StringFileRequest stringFile, Guid userId);
        Task<Response<object>> FormGetDataWorkManager(Uri url, QueryRequest query, Guid userId);
        Task<Response<object>> FormGetFileCodesWorkManager(Uri url, FileRequest file, Guid userId);
        Task<Response<InsertResponseDto>> FormInsertWorkManager(Uri url, InsertRequest insert, Guid userId);
        Task<Response<object>> FormUpdateWorkManager(Uri url, UpdateRequest update, Guid userId);
        Task<Response<object>> ListGetItemsWorkManager(Uri url, ListRequest list, Guid userId);
        Task<Response<object>> WorkflowAttachFilesWorkManager(Uri url, WorkflowAttachFilesRequest WorkflowAttachFiles, Guid userId);
        //Task<Response<object>> WorkflowRunTaskWorkManager(Uri url, RunTaskRequest runTask, Guid userId);
        //Task<Response<object>> WorkflowStartWorkManager(Uri url, StartWorkflowRequest startWorkFlow, Guid userId);
    }
}
