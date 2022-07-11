using System;

namespace GA2.Domain.Entities
{
    public class SimulacionCliente
    {
        public string SMC_NUMERO_DOCUMENTO { get; set; }
        public string SMC_NUMERO_PREAPROBADO { get; set; }
        public string SMC_TIPO_VIVIENDA { get; set; }
        public decimal SMC_VALOR_VIVIENDA { get; set; }
        public decimal SMC_VALOR_PRESTAMO { get; set; }
        public string SMC_TIPO_ALIVIO { get; set; }
        public string SMC_TIPO_ABONO { get; set; }
        public decimal SMC_VALOR_TASA_EA { get; set; }
        public decimal SMC_VALOR_TASA_MV { get; set; }
        public decimal SMC_VALOR_TASA_MV_FRESH { get; set; }
        public string SMC_VIVIENDA_VIS { get; set; }
        public int SMC_VALOR_CUOTA { get; set; }
        public int SMC_VALOR_CUOTA_SIN_SEG { get; set; }
        public int SMC_PLAZO { get; set; }
        public DateTime SMC_FECHA_SIMULACION { get; set; }
        public DateTime SMC_FECHA_APROBACION { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string CIUDAD { get; set; }
        public string DIRECCION { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string TELEFONO_FIJO { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public string FUERZA { get; set; }
        public string REGIMEN { get; set; }
        public string CATEGORIA { get; set; }
        public string GRADO { get; set; }
        public int TIPO_CREDITO { get; set; }
        public int AÑOS { get; set; }
        public string TIPO_ABONO { get; set; }
        public string TIPO_VIVIENDA { get; set; }

    }
}
