using Microsoft.AspNetCore.Http;

namespace GA2.Application.Dto
{
    public class CuentaStorageRequest
    {
        public string Modulo { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
    }

    public class FileStorageRequest
    {
        public IFormFile File { get; set; }
    }
}
