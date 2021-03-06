using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO para el movimineto de carga de archivo nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class MovimientoDTO
    {
        public int MVT_ID { get; set; }
        public int CTA_ID { get; set; }
        public int CNC_ID { get; set; }
        public decimal MVT_VALOR { get; set; }
        public string CAT_TIPO_MOVIMIENTO { get; set; }
        public DateTime MVT_FECHA_PROCESO { get; set; }
        public int DCT_ID { get; set; }
        public int MVT_ANO_PERIODO { get; set; }
        public string MVT_MES_PERIODO { get; set; }
        public DateTime MVT_FECHA_MOVIMIENTO { get; set; }
    }
}
