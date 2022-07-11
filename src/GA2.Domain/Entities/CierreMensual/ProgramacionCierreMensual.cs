using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ProgramacionCierreMensual
    {
        public Guid ID { get; set; }
        public DateTime FECHA_CARGUE { get; set; }
        public DateTime FECHA_PROCESAMIENTO { get; set; }
        public Guid USUARIO_PROCESAMIENTO { get; set; }
        public bool GENERA_ACTUALIZACION { get; set; }
        public int TIPO_PROCESO { get; set; }
        public string TIPO_PROCESO_DESC { get; set; }
        public int CUENTA_ABONO_AHORRO { get; set; }
        public string CONCEPTOS_AHORRO { get; set; }
        public int CUENTA_ABONO_CESANTIAS { get; set; }
        public string CONCEPTOS_CESANTIAS { get; set; }
        public float IPC { get; set; }
        public int ANIO { get; set; }
        public int MES { get; set; }
        public int ESTADO { get; set; }
        public string ESTADO_DESC { get; set; }

    }

    public class RespuestaCierreMensual
    {
        public Guid ID { get; set; }
        public int ESTADO { get; set; }
    }

    public class ReporteCierreMensual
    {
        public Guid ID_PROGRAMACION_CIERRE_MENSUAL { get; set; }
        public int UNIDAD_EJECUTORA { get; set; }
        public string UNIDAD_EJECUTORA_DESC { get; set; }
        public string CONCEPTO { get; set; }
        public string CLI_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public string CLI_SEGUNDO_NOMBRE { get; set; }
        public string CLI_PRIMER_APELLIDO { get; set; }
        public string CLI_SEGUNDO_APELLIDO { get; set; }
        public float SALDO_ACTUAL { get; set; }
        public float SALDO_ANTERIOR { get; set; }
        public float SALDO_INICIAL_INTERES { get; set; }
        public float SALDO_INICIAL_INGRESOS { get; set; }
        public float VALOR_INTERES { get; set; }
        public float SALDO_INTERES_CAUSADO { get; set; }
        public float NUEVO_SALDO { get; set; }
        public string PERIODO { get; set; }
        public float IPC { get; set; }

    }
}
