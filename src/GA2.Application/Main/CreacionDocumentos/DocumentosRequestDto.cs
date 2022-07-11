using System.ComponentModel;

namespace GA2.Application.Main
{
    public class DocumentosRequestDto
    {
        public string HtmlString { get; set; }
        public string cssHtml { get; set; }
        public TipoDocumentoArchivo TipoDocumentoArchivo { get; set; }
    }

    /// <summary>
    /// Tipo Documento enumerador 
    /// </summary>
    public enum TipoDocumentoArchivo
    {
        [Description("doc")]
        DOC,

        [Description("docx")]
        DOCX,

        [Description("pdf")]
        PDF,

        [Description("xls")]
        XSL,

        [Description("xslx")]
        XSLX,

        [Description("xps")]
        XPS
    }
}
