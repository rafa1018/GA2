using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SMCSimulacionCliente
    {
        public Guid SMC_ID { get; set; }
        public Guid SLS_ID { get; set; }
        public Guid SDP_ID { get; set; }
        public string SMC_TIPO_VIVIENDA { get; set; }
        public decimal SMC_VALOR_VIVIENDA { get; set; }
        public string SMC_TIPO_ALIVIO { get; set; }
        public string SMC_TIPO_ABONO { get; set; }
        public string SMC_NUMERO_DOCUMENTO { get; set; }
        public decimal SMC_VALOR_PRESTAMO { get; set; }
        public double SMC_VALOR_TASA_EA { get; set; }
        public double SMC_VALOR_TASA_MV { get; set; }
        public double SMC_VALOR_TASA_MV_FRESH { get; set; }
        public string SMC_VIVIENDA_VIS { get; set; }
        public DateTime SMC_FECHA_SIMULACION { get; set; }
        public string SMC_USA_REC_ACUMULADO { get; set; }
        public string SMC_TOMA_SEGURO { get; set; }
        public double SMC_VALOR_PRESTAMO_LSG { get; set; }
        public int SMC_NUMERO_PREAPROBADO { get; set; }
        public int SMC_TOTAL_CUOTAS { get; set; }
        public DateTime SMC_FECHA_APROBACION { get; set; }
        public double SMC_OPCION_COMPRA { get; set; }
    }
}