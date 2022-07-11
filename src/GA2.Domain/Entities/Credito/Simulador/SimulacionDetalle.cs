using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SimulacionDetalle
    {
        public Guid SMD_ID { get; set; }
        public Guid SMC_ID { get; set; }
        public int SMD_CUOTA { get; set; }
        public DateTime SMD_FECHA_CORTE { get; set; }
        public DateTime SMD_FECHA_PAGO { get; set; }
        public double SMD_SALDO { get; set; }
        public double SMD_INTERESES { get; set; }
        public double SMD_CAPITAL { get; set; }
        public double SMD_SEGURO_VIDA { get; set; }
        public double SMD_SEGURO_TERREMOTO { get; set; }
        public double SMD_CUOTA_TOTAL { get; set; }
        public double SMD_ABONO_EXTRA { get; set; }
        public double SMD_ABONO_MENSUAL { get; set; }
        public decimal SMD_CUOTA_UNIDAD_PAGADORA { get; set; }
        public double SMD_INTERESES_REDUCCION { get; set; }
        public double SMD_CUOTA_REDUCCION { get; set; }
        public double SMD_COBRO_FONVIVIENDA { get; set; }
        public decimal SMD_SALDO_LEASING { get; set; }
        public decimal SMD_INTERES_LEASING { get; set; }
        public decimal SMD_CAPITAL_LEASING { get; set; }
        public decimal SMD_CUOTA_LEASING { get; set; }
        public decimal SMD_CUOTA_LEASING_SUBSIDIO { get; set; }
        public decimal SMD_INTERES_TRADICIONAL_SUBSIDIO { get; set; }
        public double SMD_INTERES_LEASING_SUBSIDIO { get; set; }
        public decimal SMD_SEGURO_VIDA_LEASING { get; set; }
    }
}

