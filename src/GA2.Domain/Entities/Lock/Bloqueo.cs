using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de blqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>05/05/2021</date>
    /// </summary>
    public class Bloqueo
    {
        public int MOD_B_ID { get; set; }
        public int MOD_B_CODIGO { get; set; }
        public string MOD_B_CONCEPTO { get; set; }
        public string MOD_B_DIAS_MORA { get; set; }
        public bool MOD_B_REVERSIBLE { get; set; }
        public bool MOD_B_ACELERACION_DEUDA { get; set; }
        public DateTime MOD_B_FECHA_MODIFICACION { get; set; }
        public int MOD_B_MODIFICADO_POR { get; set; }
        public bool MOD_B_ESTADO { get; set; }

    }
}
