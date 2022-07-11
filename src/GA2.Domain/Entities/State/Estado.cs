using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de estado
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class Estado
    {
        public int EST_ID { get; set; }
        public int EST_CODIGO { get; set; }
        public string EST_CONCEPTO { get; set; }
        public string EST_DIAS_MORA_ACTIVA_ESTADO { get; set; }
        public string EST_SALDO_DEUDA { get; set; }
        public DateTime EST_FECHA_MODIFICACION { get; set; }
        public int EST_MODIFICADO_POR { get; set; }
        public bool EST_ESTADO { get; set; }

    }
}
