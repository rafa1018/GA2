using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// EjemploDocumentos
    /// </summary>
    public class EjemploDocumentos : ProviderDocumentos, IEjemploDocumentos
    {
        public async Task<FileResult> GenerarDocumento(string htmlContenido, string cssHtml, TipoDocumentoArchivo tipo)
        {
            return await CrearDocumento(htmlContenido, cssHtml, tipo, $"{Guid.NewGuid().ToString().ToUpper()}.{tipo}");

        }
    }
}
