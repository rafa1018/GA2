using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class CreacionSimulacionCliente
    {
        public string NUMERO_DOCUMENTO { get; set; }
        public string TIPO_VIVIENDA { get; set; }
        public int VALOR { get; set; }
        public string TIPO_ABONO { get; set; }
        public string SUBSIDIO { get; set; }
        public bool ABONO_UNICO { get; set; }
        public int VLR_PRESTAMO { get; set; }
        public int VLR_CUOTA { get; set; }
        public int PLAZO { get; set; }
    }
}
