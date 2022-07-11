using System.Text;

namespace GA2.Transversals.Commons
{
    public static class ProviderDocumentosConstants
    {
        public const string XML_OFFICE = @"<html xmlns:o='urn:schemas-microsoft-com:office:office' ";
        public const string XML_WORD = @"xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'> ";
        public const string XML_WORDX = @"xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'> ";
        public const string XML_XLS = @"xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'> ";
        public const string XML_XLSX = @"xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'> ";
        public const string XML_PDF = @"xmlns='http://www.w3.org/TR/REC-html40'> ";
        public const string XML_XPS = @"xmlns:w='urn:schemas-microsoft-com:office:xps' xmlns='http://www.w3.org/TR/REC-html40'> ";
        public static string AddHtmlAndCss(string htmlBody, string cssHtml, bool margins = true)
        {
            StringBuilder cadenaHtml = new StringBuilder();
            cadenaHtml.Append($"<head><style>{cssHtml}</style></head>");
            cadenaHtml.Append(@"<body>");
            if (margins)
            {
                cadenaHtml.Append($"<div class='special-margin'>");
            }
            else
            {
                cadenaHtml.Append("<div>");
            }

            cadenaHtml.Append(htmlBody);
            cadenaHtml.Append("</div></body></html> ");
            return cadenaHtml.ToString();
        }
    }
}
