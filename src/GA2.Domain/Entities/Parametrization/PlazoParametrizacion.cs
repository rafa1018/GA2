using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de parametrizacion de plazos
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>08/04/2021</date>
    /// </summary>
    public class PlazoParametrizacion
    {
        public int PAR_PLA_ID { get; set; }
        public decimal PAR_YEAR_MIN { get; set; }
        public decimal PAR_MONTH_MIN { get; set; }
        public decimal PAR_YEAR_MAX { get; set; }
        public decimal PAR_MONTH_MAX { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }

    }
}
