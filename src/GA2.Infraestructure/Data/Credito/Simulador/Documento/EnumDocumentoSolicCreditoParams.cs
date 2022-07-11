using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumDocumentoSolicCreditoParams
    {
        [Description("@DCS_ID")]
        idDocumentoSolicitud,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@TDC_ID")]
        idTipoDocumento,

        [Description("@DCS_CODIGO_BARRAS")]
        codigoBarras,

        [Description("@DCS_FECHA_DOCUMENTO")]
        fechaDocumento,

        [Description("@DCS_NUMERO_FOLIOS")]
        numeroFolios,

        [Description("@DCS_TAMAÑO")]
        tamaño,

        [Description("@DCS_RUTA_IMAGEN")]
        rutaImagen,

        [Description("@DCS_ESTADO")]
        estado,

        [Description("@DCS_CREADO_POR")]
        creadoPor,

        [Description("@DCS_FECHA_CREACION")]
        fechaCreacion
    }
}
