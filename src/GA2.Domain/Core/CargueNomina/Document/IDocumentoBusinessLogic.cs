using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IDocumentoBusinessLogic
    {
        Task<Response<DocumentoDto>> CambiarEstadoAProcesar(int documentoId);
        Task<Response<IEnumerable<DocumentoDto>>> ObtenerDocumentosCarga(int estadoDocumento);
        Task<Response<DocumentoDto>> ObtenerDocumentosPorId(int documentoId);
        Task<DocumentoDto> RegistroDocumento(ComponentesDTO componentesDto, Guid userId, CuentaStorage cuentaStorage);
        Task<ComponentesDTO> ValidarArchivoNomina(Stream stream, string nombreArchivo,  ParamCargueNomDTO parametros, DocumentoDto documento= default);
    }
}