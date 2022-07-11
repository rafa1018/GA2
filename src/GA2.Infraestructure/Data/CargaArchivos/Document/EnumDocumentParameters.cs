using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Lista de parametros de documento
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public enum EnumDocumentParameters
    {
        [Description("@DCT_ID")]
        DCT_ID,

        [Description("@TDC_ID")]
        TDC_ID,

        [Description("@DCT_NOMBRE")]
        DCT_NOMBRE,

        [Description("@DCT_FECHA_INICIAL")]
        DCT_FECHA_INICIAL,

        [Description("@ESD_ID")]
        ESD_ID,

        [Description("@CED_ID")]
        CED_ID,

        [Description("@DCT_FECHA_FINAL")]
        DCT_FECHA_FINAL,

        [Description("@DCT_ID_ANULA")]
        DCT_ID_ANULA,

        [Description("@DCT_ALERTA")]
        DCT_ALERTA,

        [Description("@DCT_CREADOPOR")]
        DCT_CREADOPOR,

        [Description("@DCT_FECHACREACION")]
        DCT_FECHACREACION,

        [Description("@DCT_FECHAMODIFICACION")]
        DCT_FECHAMODIFICACION,

        [Description("@DCT_MODIFICADOPOR")]
        DCT_MODIFICADOPOR,

        [Description("@UEJ_ID")]
        UEJ_ID
    }
}

