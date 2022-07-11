using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de parametrizacion de tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>08/04/2021</date>
    /// </summary>
    public class TasaParametrizacion
    {
        public int PAR_TAS_ID { get; set; }
        public decimal PAR_USURA_EA { get; set; }
        public decimal PAR_USURA_NM { get; set; }
        public decimal PAR_CORRIENTE_EA { get; set; }
        public decimal PAR_CORRIENTE_NM { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }



    }
}
