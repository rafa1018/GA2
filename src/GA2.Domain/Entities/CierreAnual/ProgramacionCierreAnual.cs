using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ProgramacionCierreAnual
    {
        public Guid ID { get; set; }
        public DateTime FECHA_CARGUE { get; set; }
        public DateTime FECHA_PROCESAMIENTO { get; set; }
        public Guid USUARIO_PROCESAMIENTO { get; set; }
        public bool GENERA_ACTUALIZACION { get; set; }
        public int TIPO_PROCESO { get; set; }
        public int CUENTA_ABONO_AHORRO { get; set; }
        public string CONCEPTOS_AHORRO { get; set; }
        public int CUENTA_ABONO_CESANTIAS { get; set; }
        public string CONCEPTOS_CESANTIAS { get; set; }
        public float IPC { get; set; }
        public int ANIO { get; set; }
        public int MES { get; set; }
        public int ESTADO { get; set; }

    }

    public class RespuestaCierreAnual
    {
        public Guid ID { get; set; }
        public int ESTADO { get; set; }
    }
}
