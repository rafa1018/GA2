using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class PagoAplicarDto

    {
        public int NumeroCredito { get; set; }
        public decimal ValorPago { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
