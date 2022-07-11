using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ActualizacionSolicitudCreditoDesemFirma
    {
        public Guid SOC_ID { get; set; }
        public DateTime SOC_FECHA_SOLICITUD { get; set; }
        public int SOC_NUMERO_SOLICITUD { get; set; }
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
        public string SOC_CONVENIO_ASEGURADORA { get; set; }
        public string SOC_CONVENIO_ASEGURADORA_HOGAR { get; set; }
        public int ASE_ID { get; set; }
        public int ASE_ID_HOGAR { get; set; }
        public Guid SOC_DECISION_BURO { get; set; }
        public int SOC_SCORE { get; set; }
        public decimal SOC_CAPACIDAD_ENDEUDAMIENTO { get; set; }
        public decimal SOC_NIVEL_ENDEUDAMIENTO { get; set; }
        public decimal SOC_NIVEL_ENDEUDAMIENTO_CUOTA { get; set; }
        public decimal SOC_PORC_EXTRAPRIMA { get; set; }
        public decimal SOC_VALOR_RECOMENDADO_CREDITO { get; set; }
        public string SOC_OBSERVACION_RECOMENDACION { get; set; }
        public decimal SOC_TASA_FECH { get; set; }
        public decimal SOC_VALOR_ALIVIO { get; set; }
        public Guid USR_REPARTO { get; set; }
        public int NOT_ID { get; set; }
        public DateTime SOC_FECHA_REPARTO { get; set; }
        public string SOC_FINALIZA_REPARTO { get; set; }
        public DateTime SOC_FECHA_FINALIZA_REPARTO { get; set; }
        public string SOC_TIPO_ALIVIO { get; set; }
        public string SOC_VALIDA_DESEMBOLSO { get; set; }
        public string SOC_OBSERVACION_VALIDA_DES { get; set; }
        public Guid SOC_USUARIO_VALIDA_DES { get; set; }
        public DateTime SOC_FECHA_VALIDA_DES { get; set; }
        public string SOC_VALIDA_FIRMAS { get; set; }
        public string SOC_OBSERVACION_VALIDA_FIRMA { get; set; }
        public Guid SOC_USUARIO_VALIDA_FIRMA { get; set; }
        public DateTime SOC_FECHA_VALIDA_FIRMA { get; set; }
        public string SOC_ESTADO { get; set; }
        public Guid SOC_CREADO_POR { get; set; }
        public DateTime SOC_FECHA_CREACION { get; set; }
        public Guid SOC_ACTUALIZADO_POR { get; set; }
        public DateTime SOC_FECHA_ACTUALIZA { get; set; }
    }
}
