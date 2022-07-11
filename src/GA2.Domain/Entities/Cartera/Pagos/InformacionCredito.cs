using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
   public class InformacionCredito
    {
        public Guid CRE_ID { get; set; }
        public int CRE_NRO_CREDITO { get; set; }
        public DateTime CRE_FECHA_DESEMBOLSO { get; set; }
        public decimal CRE_VALOR_DESEMBOLSO { get; set; }
        public decimal CRE_VALOR_CUOTA { get; set; }
        public int CRE_PLAZO_TOTAL { get; set; }
        public int TCR_ID { get; set; }
        public int CRE_DIA_PAGO { get; set; }
        public int ESC_ID { get; set; }
        public DateTime CRE_FECHA_ESTADO { get; set; }
        public int CRE_DIAS_MORA { get; set; }
        public decimal CRE_VALOR_VIVIENDA { get; set; }
        public int TIV_ID { get; set; }
        public int TVV_ID { get; set; }
        public decimal CRE_SALDO_CAPITAL { get; set; }
        public decimal CRE_SALDO_CAPITAL_MORA { get; set; }
        public int CRE_PLAZO_ACTUAL { get; set; }
        public float CRE_TASA_SEGURO_VIDA { get; set; }
        public float CRE_TASA_SEGURO_HOGAR { get; set; }
        public float CRE_TASA_CREDITO_EA { get; set; }
        public float CRE_TASA_CREDITO_PER { get; set; }
        public float CRE_TASA_FRECH { get; set; }
        public decimal CRE_VALOR_ALIVIO_CUOTA { get; set; }
        public DateTime CRE_FECHA_ULTIMO_PAGO { get; set; }
        public DateTime CRE_FECHA_PROXIMO_PAGO { get; set; }
        public int CRE_TIPO_ABONO_EXTRA { get; set; }
        public decimal CRE_VALOR_ABONO_EXTRA { get; set; }
        public decimal CRE_VALOR_DEUDA_REMANENTE { get; set; }
        public decimal CRE_VALOR_CANON_INICIAL { get; set; }
        public decimal CRE_VALOR_OPCION_COMPRA { get; set; }
        public decimal CRE_CANON_EXTRAORDINARIO { get; set; }
        public float CRE_POR_CANON_INICIAL { get; set; }
        public float CRE_POR_OPCION_COMPRA { get; set; }
        public decimal CRE_ACUMULADO_INTERES_MORA { get; set; }
        public decimal CRE_ACUMULADO_INTERES_CORRIENTE { get; set; }
        public decimal CRE_ACUMULADO_SEGURO_HOGAR { get; set; }
        public decimal CRE_ACUMULADO_SEGURO_VIDA { get; set; }
        public DateTime CRE_FECHA_ULTIMO_PAGO_INTERES_MORA { get; set; }
        public DateTime CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE { get; set; }
        public DateTime CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR { get; set; }
        public DateTime CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA { get; set; }
        public bool CRE_ALIVIO_FRECH { get; set; }
        public int CRE_NUMERO_CUOTAS_CANCELADAS { get; set; }
        public Guid CRE_CREADO_POR { get; set; }
        public DateTime CRE_FECHA_CREACION { get; set; }
        public Guid CRE_MODIFICADO_POR { get; set; }
        public DateTime CRE_FECHA_MODIFICACION { get; set; }
    }
}