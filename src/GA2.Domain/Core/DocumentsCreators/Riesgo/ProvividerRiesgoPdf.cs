using GA2.Application.Main;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core.DocumentsCreators.Riesgo
{
    public abstract class ProvividerRiesgoPdf
    {
        public async Task<FileResult> CrearDocumento(
            string documentoHtml,
            string estiloHtml,
            TipoDocumentoArchivo tipoDocumentoArchivo,
            string nombreArchivo,
            Dictionary<string, string> dictionarioDatos,
            string contrasena,
            string header,
            string footer,
            bool margins = false
            )
        {
            documentoHtml = this.LlenarDocumentoParametros(documentoHtml, dictionarioDatos);
            var documento = this.CrearTipoDocumento(documentoHtml, tipoDocumentoArchivo, estiloHtml, margins);
            return await this.ExportaArchivo(documento, tipoDocumentoArchivo, nombreArchivo, contrasena, header, footer);
        }



        private string LlenarDocumentoParametros(string documentoHtml, Dictionary<string, string> dictionarioDatos)
        {
            if (dictionarioDatos != null)
            {
                foreach (var i in dictionarioDatos)
                {
                    documentoHtml = documentoHtml.Replace(i.Key, i.Value);
                }
            }

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = documentoHtml.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            documentoHtml = sbReturn.ToString();

            return documentoHtml;
        }

        private string CrearTipoDocumento(string documentoHtml, TipoDocumentoArchivo tipoDocumentoArchivo, string estiloHtml, bool margins)
        {
            StringBuilder constructorDocumento = new StringBuilder();
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

            constructorDocumento.Append(ProviderDocumentosConstants.AddHtmlAndCss(documentoHtml, estiloHtml, margins));
            var documento = constructorDocumento.ToString();
            return documento;
        }


        private async Task<FileResult> ExportaArchivo(string documento, TipoDocumentoArchivo tipoDocumentoArchivo, string nombreArchivo, string contrasena, string header, string footer)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(documento);

            MemoryStream ms = new MemoryStream(buffer);
            var fileName = nombreArchivo ?? Guid.NewGuid().ToString();
            fileName = fileName + '.' + HelpersEnums.GetEnumDescription(tipoDocumentoArchivo);
            var archivo = new FileStreamResult(ms, "text/plain")
            {
                FileDownloadName = fileName
            };

            if (tipoDocumentoArchivo == TipoDocumentoArchivo.PDF)
            {
                HtmlToPdf converter = new HtmlToPdf();
                converter.Options.PdfPageSize = PdfPageSize.Letter;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

                //Header & footer
                converter.Options.DisplayHeader = true;
                converter.Options.DisplayFooter = true;
                converter.Footer.Height = 80;
                converter.Header.Height = 60;
                PdfHtmlSection footerHtml = new PdfHtmlSection(footer, null);
                footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Footer.Add(footerHtml);
                PdfHtmlSection headerHtml = new PdfHtmlSection(header, null);
                headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Header.Add(headerHtml);
                //Fin headers y footers

                converter.Options.MarginLeft = 10;
                converter.Options.MarginRight = 10;
                converter.Options.MarginTop = 40;
                converter.Options.MarginBottom = 40;
                converter.Options.PdfStandard = PdfStandard.PdfA;
                PdfDocument doc = converter.ConvertHtmlString(documento);
                if (contrasena != null) doc.Security.UserPassword = contrasena;
                byte[] bufferPdf = doc.Save();
                MemoryStream msPdf = new MemoryStream(bufferPdf);
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