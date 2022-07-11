using GA2.Application.Dto;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICargaArchivoBusinessLogic
    {
        Task<ComponentesDTO> ValidacionArchivoNomina(Stream streamFile, string fileName, ParamCargueNomDTO parametros, DocumentoDto documentoId= default);
    }
}