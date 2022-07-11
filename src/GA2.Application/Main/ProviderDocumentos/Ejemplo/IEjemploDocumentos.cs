using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IEjemploDocumentos
    {
        Task<FileResult> GenerarDocumento(string htmlContenido, string cssHtml, TipoDocumentoArchivo tipo);
    }
}