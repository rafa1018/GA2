using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de parametrizacion legal tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class LegalTasaParametrizacion
    {
        public int PAR_LET_ID { get; set; }
        public decimal PAR_TASA_FRECH { get; set; }
        public DateTime PAR_VIGENCIA_TASA_FRECH { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }

    }
}
