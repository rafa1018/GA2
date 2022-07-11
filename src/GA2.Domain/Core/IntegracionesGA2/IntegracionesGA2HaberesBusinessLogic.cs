using GA2.Application.Dto;
using GA2.Application.Dto.Haberes;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class IntegracionesGA2HaberesBusinessLogic : IIntegracionesGA2HaberesBusinessLogic
    {
        private readonly IIntegracionesGA2Haberes _integraciones;
        private readonly IBlobStorageGenericRepository _blobStorageRepository;
        private readonly ICreditoBusinessLogic _credito;

        public IntegracionesGA2HaberesBusinessLogic(IIntegracionesGA2Haberes integraciones, IBlobStorageGenericRepository blobStorageRepository, ICreditoBusinessLogic credito)
        {
            _integraciones = integraciones;
            _blobStorageRepository = blobStorageRepository;
            _credito = credito;
        }

        public async Task<FileResult> GenerarReporteHaberes(Uri url, HaberesRequestDto request, Guid userId)
        {
            var response = new Response<string>();
            var fileName = $"REPORTE_HABERES_{request.ClienteIdentificacion}_{request.CuentaId}_.pdf";
            try
            {
                var checkBlob = await _blobStorageRepository.DescargarArchivoStorage("haberes" ,fileName);
                var diferenciaDias = (checkBlob.Details.LastModified.DateTime- DateTime.Now).TotalDays;
                if (diferenciaDias >= 30)
                {
                    await this._blobStorageRepository.EliminarArchivoStorage("haberes", fileName);
                    var result = await _integraciones.GenerarReporteHaberes<Response<String>>(url, request, response.GetCorrelation(), userId);

                    var _request = Convert.FromBase64String(result.Data);

                    Stream stream = new MemoryStream(_request);

                    var blobResponse = await this._blobStorageRepository.SubirArchivoStorage(stream, "haberes", fileName);
                    var fileDownload = new FileStreamResult(checkBlob.Content, "application/octet-stream")
                    {
                        FileDownloadName = $"{Guid.NewGuid().ToString().ToUpper()}.pdf"
                    };
                    await fileDownload.FileStream.FlushAsync();
                    return fileDownload;

                }
                else
                {
                    var file = new FileStreamResult(checkBlob.Content, "application/octet-stream")
                    {
                        FileDownloadName = $"{Guid.NewGuid().ToString().ToUpper()}.pdf"
                    };
                    await file.FileStream.FlushAsync();
                    return file;
                }
            }
            catch
            {
                var result = await _integraciones.GenerarReporteHaberes<Response<String>>(url, request, response.GetCorrelation(), userId);

                var _request = Convert.FromBase64String(result.Data);

                Stream stream = new MemoryStream(_request);
                var blobResponse = await this._blobStorageRepository.SubirArchivoStorage(stream, "haberes", fileName);
                response.Data = blobResponse;
                var fileDownload = await this._blobStorageRepository.DescargarArchivoStorage("haberes", fileName);
                var downloadFile = new FileStreamResult(fileDownload.Content, "application/octet-stream")
                {
                    FileDownloadName = $"{Guid.NewGuid().ToString().ToUpper()}.pdf"
                };
                await downloadFile.FileStream.FlushAsync();
                return downloadFile;
            }
            
           
        }

    }
}
