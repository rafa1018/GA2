using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public abstract class ProviderDocumentos
    {
        public static async Task<FileResult> CrearDocumento(string HTML, 
                                                     string CSS, 
                                                     TipoDocumentoArchivo tipoDocumento,
                                                     string nombreArchivo,
                                                     Dictionary<string, string> datosReemplazo = null,
                                                     string contraseña = null,
                                                     string header = null,
                                                     string footer= null,
                                                     bool margins = false
                                                     )
        {

            var documentoHtml = LlenarDocumentoParametros(HTML, datosReemplazo);
            var documento = CrearTipoDocumento(documentoHtml, tipoDocumento, CSS);
            return await ExportaArchivo(documento, tipoDocumento, nombreArchivo, contraseña, header, footer, margins);
        }

        private static string LlenarDocumentoParametros(string contenidoHtml, Dictionary<string, string> contenido)
        {
            if (contenido != null)
            {
                foreach (var i in contenido)
                {
                    contenidoHtml = contenidoHtml.Replace(i.Key, i.Value);
                }
            }

            //StringBuilder sbReturn = new StringBuilder();
            //var arrayText = contenidoHtml/*.Normalize(NormalizationForm.FormD)*/.ToCharArray();
            //foreach (char letter in arrayText)
            //{
            //    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
            //        sbReturn.Append(letter);
            //}

            //contenidoHtml = sbReturn.ToString();

            return contenidoHtml;
        }

        /// <summary>
        /// Crear tipo de doucmentos 
        /// </summary>
        /// <param name="bodyHtml">Contendio html de cuerpo</param>
        /// <param name="tipoDocumentoArchivo">Tipo de documento a crear</param>
        /// <param name="cssHtml">Estilos css</param>
        /// <returns></returns>
        private static string CrearTipoDocumento(string bodyHtml, TipoDocumentoArchivo tipoDocumentoArchivo, string cssHtml = null, bool margins = false)
        {
            StringBuilder constructorDocumento = new();
            constructorDocumento.Append(ProviderDocumentosConstants.XML_OFFICE);
            switch (tipoDocumentoArchivo)
            {
                case TipoDocumentoArchivo.DOC:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_WORD);
                    break;
                case TipoDocumentoArchivo.DOCX:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_WORDX);
                    break;
                case TipoDocumentoArchivo.XSL:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_XLS);
                    break;
                case TipoDocumentoArchivo.XSLX:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_XLSX);
                    break;
                case TipoDocumentoArchivo.PDF:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_PDF);
                    break;
                case TipoDocumentoArchivo.XPS:
                    constructorDocumento.Append(ProviderDocumentosConstants.XML_XPS);
                    break;
                default:
                    break;
            }

            constructorDocumento.Append(ProviderDocumentosConstants.AddHtmlAndCss(bodyHtml, cssHtml, margins));
            var documento = constructorDocumento.ToString();
            return documento;
        }

        /// <summary>
        /// Exportar archivos creados
        /// </summary>
        /// <param name="contendito">Contenido html</param>
        /// <param name="tipoDocumentoArchivo">Tipo de documento creado</param>
        /// <param name="nombreArchivo">Nombre archivo</param>
        /// <param name="passwordPdf">Password Pdf</param>
        /// <returns>Archivo creado</returns>
        private static async Task<FileResult> ExportaArchivo(string contendito, TipoDocumentoArchivo tipoDocumentoArchivo, string nombreArchivo, string passwordPdf, string header, string footer, bool margins = false)
        {
            //string subPath = "Temp";

            //bool exists = Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subPath));

            //if (!exists)
            //    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subPath));

            //var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subPath);

            byte[] buffer = Encoding.UTF8.GetBytes(contendito);
            MemoryStream ms = new(buffer);
            var fileName = nombreArchivo ?? Guid.NewGuid().ToString();
            fileName = fileName + '.' + HelpersEnums.GetEnumDescription(tipoDocumentoArchivo);
            var archivo = new FileStreamResult(ms, "text/plain")
            {
                FileDownloadName = fileName
            };

            if (tipoDocumentoArchivo == TipoDocumentoArchivo.PDF)
            {
                HtmlToPdf converter = new();
                converter.Options.PdfPageSize = PdfPageSize.Letter;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                if (!string.IsNullOrEmpty(header))
                {
                    converter.Options.DisplayHeader = true;
                    converter.Header.Height = 60;
                    PdfHtmlSection headerHtml = new(header, /*basePath*/"");
                    headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                    converter.Header.Add(headerHtml);
                }
                if (!string.IsNullOrEmpty(footer))
                {
                    converter.Options.DisplayFooter = true;
                    converter.Footer.Height = 80;
                    PdfHtmlSection footerHtml = new(footer, /*basePath*/"")
                    {
                        AutoFitHeight = HtmlToPdfPageFitMode.AutoFit
                    };
                    converter.Footer.Add(footerHtml);
                }

                converter.Options.MarginLeft = 10;
                converter.Options.MarginRight = 10;
                converter.Options.MarginTop = 40;
                converter.Options.MarginBottom = 40;
                converter.Options.PdfStandard = PdfStandard.PdfA;
                PdfDocument doc = converter.ConvertHtmlString(contendito, /*basePath*/"");
                if (!string.IsNullOrWhiteSpace(passwordPdf)) doc.Security.UserPassword = passwordPdf;
                byte[] bufferPdf = doc.Save();
                MemoryStream msPdf = new(bufferPdf);
                var archivoPdf = new FileStreamResult(msPdf, "application/pdf")
                {
                    FileDownloadName = fileName
                };
                await archivoPdf.FileStream.FlushAsync();
                return archivoPdf;
            }

            await archivo.FileStream.FlushAsync();
            return archivo;
        }
    }
}
