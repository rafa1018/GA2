using GA2.Transversals.Commons;
using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad aportes clientes archivo nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class AportesCliente : BaseEntity
    {
        public int CLI_ID { get; set; }
        public int CGT_ID { get; set; }
        public int APC_CUOTAS_ACUMULADAS { get; set; }
        public DateTime APC_FECHA_ULTIMA_COUTA { get; set; }
        public DateTime APC_FECHA_PRIMERA_CUOTA { get; set; }
    }
}
