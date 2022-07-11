using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumCreacionSolicitudCreditoParams
    {
        [Description("@SOC_ID")]
        SOC_ID,

        [Description("@SOC_FECHA_SOLICITUD")]
        SOC_FECHA_SOLICITUD,

        [Description("@SOC_NUMERO_SOLICITUD")]
        SOC_NUMERO_SOLICITUD,

        [Description("@TCR_ID")]
        TCR_ID,

        [Description("@DPD_ID")]
        DPD_ID,

        [Description("@DPC_ID")]
        DPC_ID,

        [Description("@SLS_ID")]
        SLS_ID,

        [Description("@TID_ID")]
        TID_ID,

        [Description("@CLI_IDENTIFICACION")]
        CLI_IDENTIFICACION,

        [Description("@SOC_DECLARACION_ORIGEN_FONDOS")]
        SOC_DECLARACION_ORIGEN_FONDOS,

        [Description("@SOC_AUTORIZA_USO_DATOS")]
        SOC_AUTORIZA_USO_DATOS,

        [Description("@SOC_AUTORIZA_CONSULTA_CENTRALES")]
        SOC_AUTORIZA_CONSULTA_CENTRALES,

        [Description("@SOC_DECLARACION_ASEGURABILIDAD")]
        SOC_DECLARACION_ASEGURABILIDAD,

        [Description("@SOC_ESTADO")]
        SOC_ESTADO,

        [Description("@SOC_CREADO_POR")]
        SOC_CREADO_POR,

        [Description("@SOC_FECHA_CREACION")]
        SOC_FECHA_CREACION,

        [Description("@SOP_ID")]
        SOP_ID,

        [Description("@SOP_ESTADO_INMUEBLE")]
        SOP_ESTADO_INMUEBLE,

        [Description("@SOP_TIPO_INMUEBLE")]
        SOP_TIPO_INMUEBLE,

        [Description("@SOP_TIENE_GARAJE")]
        SOP_TIENE_GARAJE,

        [Description("@SOP_TIENE_DEPOSITO")]
        SOP_TIENE_DEPOSITO,

        [Description("@SOP_CONJUNTO_CERRADO")]
        SOP_CONJUNTO_CERRADO,

        [Description("@TVV_ID")]
        TVV_ID,

        [Description("@SOP_AÑOS_CONSTRUCCION")]
        SOP_AÑOS_CONSTRUCCION,

        [Description("@SOP_MATRICULA_INMOBILIARIA1")]
        SOP_MATRICULA_INMOBILIARIA1,

        [Description("@SOP_MATRICULA_INMOBILIARIA2")]
        SOP_MATRICULA_INMOBILIARIA2,

        [Description("@SOP_MATRICULA_INMOBILIARIA3")]
        SOP_MATRICULA_INMOBILIARIA3,

        [Description("@SOP_VALOR_INMUEBLE")]
        SOP_VALOR_INMUEBLE,

        [Description("@SOP_DIRECCION_INMUEBLE")]
        SOP_DIRECCION_INMUEBLE,

        [Description("@DPD_ID_INMUEBLE")]
        DPD_ID_INMUEBLE,

        [Description("@DPC_ID_INMUEBLE")]
        DPC_ID_INMUEBLE,

        [Description("@SOP_VALOR_CREDITO")]
        SOP_VALOR_CREDITO,

        [Description("@SOP_PORC_FINANCIACION")]
        SOP_PORC_FINANCIACION,

        [Description("@SOP_PLAZO_FINANCIACION")]
        SOP_PLAZO_FINANCIACION,

        [Description("@SOP_FECHA_ENTREGA_INMUEBLE")]
        SOP_FECHA_ENTREGA_INMUEBLE,

        [Description("@TID_ID_VENDEDOR")]
        TID_ID_VENDEDOR,

        [Description("@SOP_NUMERO_DOCUMENTO_VENDEDOR")]
        SOP_NUMERO_DOCUMENTO_VENDEDOR,

        [Description("@SOP_NOMBRE_VENDEDOR")]
        SOP_NOMBRE_VENDEDOR,

        [Description("@SOP_DIRECCION_VENDEDOR")]
        SOP_DIRECCION_VENDEDOR,

        [Description("@DPD_ID_VENDEDOR")]
        DPD_ID_VENDEDOR,

        [Description("@DPC_ID_VENDEDOR")]
        DPC_ID_VENDEDOR,

        [Description("@SOP_CORREO_VENDEDOR")]
        SOP_CORREO_VENDEDOR,

        [Description("@SOP_TELEFONO_VENDEDOR")]
        SOP_TELEFONO_VENDEDOR,

    }
}
