using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class CuentaAfiliado
    {
        public int CTA_NUMERO { get; set; }
        public int CNC_ID { get; set; }
        public decimal SALDO { get; set; }
        public int MOVIMIENTOS { get; set; }
    }
}
