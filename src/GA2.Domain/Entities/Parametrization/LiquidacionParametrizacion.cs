using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de parametrizacion liquidacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class LiquidacionParametrizacion
    {
        public int PAR_LIQ_ID { get; set; }
        public decimal PAR_FECHA_CORTE { get; set; }
        public decimal PAR_FECHA_PAGO { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }



    }
}
