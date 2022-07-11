using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities.Credito.Simulador
{
    public class SocSolicitudCredito
    {
        public Guid SOC_ID { get; set; }
        public DateTime SOC_FECHA_SOLICITUD { get; set; }
        public Int64 SOC_NUMERO_SOLICITUD { get; set; }
        public int TCR_ID { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public Guid SLS_ID { get; set; }
        public int TID_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string SOC_DECLARACION_ORIGEN_FONDOS { get; set; }
        public string SOC_AUTORIZA_USO_DATOS { get; set; }
        public string SOC_AUTORIZA_CONSULTA_CENTRALES { get; set; }
        public string SOC_DECLARACION_ASEGURABILIDAD { get; set; }
        public string SOC_ESTADO { get; set; }
        public string SOC_CONVENIO_ASEGURADORA { get; set; }
        public int ASE_ID { get; set; }
        public Guid SOC_CREADO_POR { get; set; }
        public DateTime SOC_FECHA_CREACION { get; set; }
        public Guid SOC_ACTUALIZADO_POR { get; set; }
        public DateTime SOC_FECHA_ACTUALIZA { get; set; }
    }
}
