using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de parametrizacion de tasa
    /// <author>Andres Riaño</author>
    /// <date>15/03/2021</date>
    /// </summary>
    public class SeguroParametrizacion
    {
        public int PAR_SEG_ID { get; set; }
        public decimal PAR_VIDA { get; set; }
        public decimal PAR_TODO_RIESGO { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }

    }
}
