using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Afiliacion
    {
        public int AFL_ID { get; set; }
        public int AFL_NUMERO_RADICADO { get; set; }
        public DateTime AFL_FECHA_RADICADO { get; set; }
        public bool AFL_TRAMITE_AFILIACION { get; set; }
        public DateTime AFL_FECHA_PRIMER_APORTE { get; set; }
        public DateTime AFL_FECHA_ULTIMO_APORTE { get; set; }
        public int AFL_NUMERO_CUOTAS { get; set; }
        public bool AFL_CONSERVA_ANTIGUEDAD { get; set; }
        public int AFL_RATIFICACION_CUOTAS { get; set; }
        public string AFL_OBSERVACIONES { get; set; }
        public int AFL_NUMERO_ACTO_ADMINISTRATIVO { get; set; }
        public DateTime AFL_FECHA_NOTIFICACION { get; set; }
        public bool AFL_CAMPO_CESANTIAS { get; set; }
        public bool AFL_ACTIVACION_DESCUENTO { get; set; }
        public bool AFL_LIQUIDACION_CUOTA_FONDO_SOLIDARIDAD { get; set; }
        public bool AFL_REINTEGRO_APORTES { get; set; }
        public DateTime AFL_PERIODO_APORTES_DESDE { get; set; }
        public DateTime AFL_PERIODO_APORTES_HASTA { get; set; }
        public decimal AFL_ASIGNACION_BASICA_MENSUAL { get; set; }
        public bool AFL_DERECHO_LIQUIDACION_CUOTAS { get; set; }
        public string AFL_DESCRIPCION_PROCEDENCIA_AFILIACION { get; set; }
        public string CLI_NOMBRE_COMPLETO { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public DateTime CLI_FECHA_ALTA { get; set; }    
        public int EAF_ID { get; set; }
        public int CLD_ID { get; set; }
        public int TPF_ID { get; set; }
        public int FRZ_ID { get; set; }
        public int CTG_ID { get; set; }
        public int UEJ_ID { get; set; }
        public int TPP_ID { get; set; }
        public int PRC_ID { get; set; }
    }
}
