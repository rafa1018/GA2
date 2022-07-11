using System;

namespace GA2.Application.Dto
{
    public class SolicitudCreditoProductoDto
    {
        public Guid VLT_ID { get; set; }
        public Guid VLI_ID { get; set; }
        public string VLT_SERVICIO { get; set; }
        public string VLT_PASO_TRANSACCION { get; set; }
        public string VLT_XML_SOLICITUD { get; set; }
        public string VLT_XML_RESPUESTA { get; set; }
        public string VLT_ID_APICACION { get; set; }
        public string VLT_CODIGO_RESPUESTA { get; set; }
        public string VLT_TIPO_RESPUESTA { get; set; }
        public string VLT_DESCRIPCION_RESPUESTA { get; set; }
        public DateTime VLT_FECHA_ACTUALIZA { get; set; }
    }
}
