using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumValidacionLogParameters
    {
        [Description("VLT_ID")]
        VLT_ID,

        [Description("VLI_ID")]
        VLI_ID,

        [Description("VLT_SERVICIO")]
        VLT_SERVICIO,

        [Description("VLT_PASO_TRANSACCION")]
        VLT_PASO_TRANSACCION,

        [Description("VLT_XML_SOLICITUD")]
        VLT_XML_SOLICITUD,

        [Description("VLT_XML_RESPUESTA")]
        VLT_XML_RESPUESTA,

        [Description("VLT_ID_APICACION")]
        VLT_ID_APICACION,

        [Description("VLT_CODIGO_RESPUESTA")]
        VLT_CODIGO_RESPUESTA,

        [Description("VLT_TIPO_RESPUESTA")]
        VLT_TIPO_RESPUESTA,

        [Description("VLT_DESCRIPCION_RESPUESTA")]
        VLT_DESCRIPCION_RESPUESTA,

        [Description("VLT_FECHA_ACTUALIZA")]
        VLT_FECHA_ACTUALIZA
    }
}
