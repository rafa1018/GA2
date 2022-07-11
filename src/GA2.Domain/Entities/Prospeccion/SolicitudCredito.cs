using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudCredito
    {
        public Guid SOC_ID { get; set; }
        public DateTime SOC_FECHA_SOLICITUD { get; set; }
        public int SOC_NUMERO_SOLICITUD { get; set; }
        public int TCR_ID { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public int DPD_ID_INMUEBLE { get; set; }
        public int DPC_ID_INMUEBLE { get; set; }
        public Guid SLS_ID { get; set; }
        public int TID_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string SOC_DECLARACION_ORIGEN_FONDOS { get; set; }
        public string SOC_AUTORIZA_USO_DATOS { get; set; }
        public string SOC_AUTORIZA_CONSULTA_CENTRALES { get; set; }
        public string SOC_DECLARACION_ASEGURABILIDAD { get; set; }
        public string SOC_ESTADO { get; set; }
        public string SOC_CONVENIO_ASEGURADORA { get; set; }
        public string SOC_CONVENIO_ASEGURADORA_HOGAR { get; set; }
        public int ASE_ID { get; set; }
        public int ASE_ID_HOGAR { get; set; }
        public string SOC_DECISION_BURO { get; set; }
        public string SOC_SCORE { get; set; }
        public decimal SOC_CAPACIDAD_ENDEUDAMIENTO { get; set; }
        public decimal SOC_NIVEL_ENDEUDAMIENTO { get; set; }
        public decimal SOC_NIVEL_ENDEUDAMIENTO_CUOTA { get; set; }
        public decimal SOC_PORC_EXTRAPRIMA { get; set; }
        public Guid SOC_CREADO_POR { get; set; }
        public DateTime SOC_FECHA_CREACION { get; set; }
        public Guid SOC_ACTUALIZADO_POR { get; set; }
        public DateTime SOC_FECHA_ACTUALIZA { get; set; }
        public Guid SOP_ID { get; set; }
        public string SOP_ESTADO_INMUEBLE { get; set; }
        public string SOP_TIPO_INMUEBLE { get; set; }
        public string SOP_TIENE_GARAJE { get; set; }
        public string SOP_TIENE_DEPOSITO { get; set; }
        public string SOP_CONJUNTO_CERRADO { get; set; }
        public int TVV_ID { get; set; }
        public int SOP_AÑOS_CONSTRUCCION { get; set; }
        public string SOP_MATRICULA_INMOBILIARIA1 { get; set; }
        public string SOP_MATRICULA_INMOBILIARIA2 { get; set; }
        public string SOP_MATRICULA_INMOBILIARIA3 { get; set; }
        public decimal SOP_VALOR_INMUEBLE { get; set; }
        public string SOP_DIRECCION_INMUEBLE { get; set; }
        public decimal SOP_VALOR_CREDITO { get; set; }
        public decimal SOP_PORC_FINANCIACION { get; set; }
        public int SOP_PLAZO_FINANCIACION { get; set; }
        public string SOP_NUMERO_DOCUMENTO_CONSTRUCTOR { get; set; }
        public string SOP_NOMBRE_CONSTRUCTOR { get; set; }
        public DateTime SOP_FECHA_ENTREGA_INMUEBLE { get; set; }
        public string SOP_NOMBRE_FIDUCIA { get; set; }
        public string SOP_NOMBRE_PROYECTO { get; set; }
        public int TID_ID_VENDEDOR { get; set; }
        public string SOP_NUMERO_DOCUMENTO_VENDEDOR { get; set; }
        public string SOP_NOMBRE_VENDEDOR { get; set; }
        public string SOP_DIRECCION_VENDEDOR { get; set; }
        public int DPD_ID_VENDEDOR { get; set; }
        public int DPC_ID_VENDEDOR { get; set; }
        public string SOP_CORREO_VENDEDOR { get; set; }
        public string SOP_TELEFONO_VENDEDOR { get; set; }
        public Guid SOP_CREADO_POR { get; set; }
        public DateTime SOP_FECHA_CREACION { get; set; }
        public Guid SOP_ACTUALIZADO_POR { get; set; }
        public DateTime SOP_FECHA_ACTUALIZA { get; set; }
    }
}
