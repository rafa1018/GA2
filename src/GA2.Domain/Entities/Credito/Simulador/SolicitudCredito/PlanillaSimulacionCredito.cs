using System;

namespace GA2.Domain.Entities
{
    public class PlanillaSimulacionCredito
    {
        public Guid SMD_ID { get; set; }
        public Guid SMC_ID { get; set; }
        public int SMD_CUOTA { get; set; }
        public DateTime SMD_FECHA_CORTE { get; set; }
        public DateTime SMD_FECHA_PAGO { get; set; }
        public decimal SMD_SALDO { get; set; }
        public decimal SMD_INTERESES { get; set; }
        public decimal SMD_CAPITAL { get; set; }
        public decimal SMD_SEGURO_VIDA { get; set; }
        public decimal SMD_SEGURO_TERREMOTO { get; set; }
        public decimal SMD_CUOTA_TOTAL { get; set; }
        public decimal SMD_ABONO_EXTRA { get; set; }
        public decimal SMD_ABONO_MENSUAL { get; set; }
        public decimal SMD_CUOTA_UNIDAD_PAGADORA { get; set; }
        public decimal SMD_INTERESES_REDUCCION { get; set; }
        public decimal SMD_CUOTA_REDUCCION { get; set; }
        public decimal SMD_COBRO_FONVIVIENDA { get; set; }
        public decimal PRM_SMLV { get; set; }
        public decimal PRM_PORC_INFLACION { get; set; }
        public decimal PRM_PORC_INCREMENTO_ANUAL { get; set; }
        public decimal PRM_PORC_FINANCIA_VIS { get; set; }
        public decimal PRM_NO_SALARIO_MIN_VIS { get; set; }
        public decimal PRM_PORC_FINANCIA_NO_VIS { get; set; }
        public decimal PRM_SEGURO_TERREMOTO { get; set; }
        public int PRM_DIAS_DESEMBOLSO { get; set; }
        public int PRM_MESES_LEY_FRECH { get; set; }
        public int PRM_MESES_LEY_ALIV { get; set; }
        public int PRM_MES_SUBSIDIO_SOL { get; set; }
        public int PRM_MES_SUBSIDIO_OTRO { get; set; }
        public decimal PRM_TASA_EA { get; set; }
        public int PRM_DIAS_VALIDO_PREAPROB { get; set; }
        public int PRM_MINIMO_MESES_PLAZO { get; set; }
        public int PRM_MAXIMO_MESES_PLAZO { get; set; }
        public string PRM_ESTADO { get; set; }
        public Guid PRM_TDC_CREADO_POR { get; set; }
        public DateTime PRM_FECHA_CREACION { get; set; }
        public Guid PRM_MODIFICADO_POR { get; set; }
        public DateTime PRM_FECHA_MODIFICACION { get; set; }
        public decimal PRM_PORC_CANON_INI_LSG { get; set; }
        public decimal PRM_PORC_CANON_FIN_LSG { get; set; }
        public decimal PRM_PORC_OPC_COMPRA_LSG { get; set; }
        public string PRM_FACTOR_AHORRO { get; set; }
        public string PRM_FACTOR_CESANTIAS { get; set; }
        public decimal VALOR_PRESTAMO { get; set; }
        public decimal VALOR_TASA { get; set; }
        public string VIVIENDA_VIS { get; set; }
        public string DERECHO_CUOTA { get; set; }
        public string DERECHO_TASA { get; set; }
        public Guid ID_SIMULACION { get; set; }
        public int MINIMO_MESES { get; set; }
        public int MAXIMO_MESES { get; set; }
        public decimal VALOR_TASA_NOMINAL { get; set; }
        public decimal VALOR_TASA_NOMINAL_F { get; set; }
    }
}
