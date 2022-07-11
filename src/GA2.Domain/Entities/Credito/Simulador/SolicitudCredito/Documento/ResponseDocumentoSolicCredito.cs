using System;

namespace GA2.Domain.Entities
{
    public class ResponseDocumentoSolicCredito
    {
        public Guid DCS_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int TDC_ID { get; set; }
        public string DCS_CODIGO_BARRAS { get; set; }
        public DateTime DCS_FECHA_DOCUMENTO { get; set; }
        public int DCS_NUMERO_FOLIOS { get; set; }
        public long DCS_TAMAÑO { get; set; }
        public string DCS_RUTA_IMAGEN { get; set; }
        public string DCS_ESTADO { get; set; }
        public Guid DCS_CREADO_POR { get; set; }
        public DateTime DCS_FECHA_CREACION { get; set; }
    }
}
