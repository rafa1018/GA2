using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Flujo Tipo Credito
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class FlujoTipoCredito
    {
        public int FTC_ID { get; set; }
        public int FLU_ID { get; set; }
        public int TCR_ID { get; set; }
        public int FTC_ESTADO { get; set; }
        public Guid FTC_CREADO_POR { get; set; }
        public DateTime FTC_FECHA_CREACION { get; set; }
        public Guid FTC_MODIFICADO_POR { get; set; }
        public DateTime FTC_FECHA_MODIFICACION { get; set; }
    }
}
