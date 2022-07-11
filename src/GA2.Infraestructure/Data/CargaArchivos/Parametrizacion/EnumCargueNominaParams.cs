using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Lista de los parametros para el cargue de nómina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public enum EnumCargueNominaParams
    {
        [Description("@PAR_ARCHIVO_CARGUE_NOMINA_ID")]
        PAR_ARCHIVO_CARGUE_NOMINA_ID,

        [Description("@NOM_ARCHIVO_LEN")]
        NOM_ARCHIVO_LEN,

        [Description("@NOM_TIPO_ARCHIVO_REPORTADO_LEN")]
        NOM_TIPO_ARCHIVO_REPORTADO_LEN,

        [Description("@NOM_CLASIF_ARCHIVO_LEN")]
        NOM_CLASIF_ARCHIVO_LEN,

        [Description("@NOM_PERIODO_APORTES_LEN")]
        NOM_PERIODO_APORTES_LEN,

        [Description("@NOM_COD_UNID_EJECUTORA_LEN")]
        NOM_COD_UNID_EJECUTORA_LEN,

        [Description("@NOM_FECHA_ENVIO_LEN")]
        NOM_FECHA_ENVIO_LEN,

        [Description("@NOM_EXTENSION_PERMITIDA")]
        NOM_EXTENSION_PERMITIDA,

        [Description("@NOM_EXTENSION_LEN")]
        NOM_EXTENSION_LEN,

        [Description("@ENC_CONSEC_LEN")]
        ENC_CONSEC_LEN,

        [Description("@ENC_TIPO_ARCHIVO_LEN")]
        ENC_TIPO_ARCHIVO_LEN,

        [Description("@ENC_NOMB_NOMINA_UNI_EJECUTORA_LEN")]
        ENC_NOMB_NOMINA_UNI_EJECUTORA_LEN,

        [Description("@ENC_COD_UNI_EJECUTORA_LEN")]
        ENC_COD_UNI_EJECUTORA_LEN,

        [Description("@ENC_PERIODO_APORTES_LEN")]
        ENC_PERIODO_APORTES_LEN,

        [Description("@CUER_CONSEC_LEN")]
        CUER_CONSEC_LEN,

        [Description("@CUER_DIGITO_FUERZA_LEN")]
        CUER_DIGITO_FUERZA_LEN,

        [Description("@CUER_UNI_EJECUTORA_LEN")]
        CUER_UNI_EJECUTORA_LEN,

        [Description("@CUER_TIPO_ID_LEN")]
        CUER_TIPO_ID_LEN,

        [Description("@CUER_IDENTIFICACION_LEN")]
        CUER_IDENTIFICACION_LEN,

        [Description("@CUER_COD_MILITAR_LEN")]
        CUER_COD_MILITAR_LEN,

        [Description("@CUER_PRIMER_NOMBRE_LEN")]
        CUER_PRIMER_NOMBRE_LEN,

        [Description("@CUER_SEGUNDO_NOMBRE_LEN")]
        CUER_SEGUNDO_NOMBRE_LEN,

        [Description("@CUER_PRIMER_APELLIDO_LEN")]
        CUER_PRIMER_APELLIDO_LEN,

        [Description("@CUER_SEGUNDO_APELLIDO_LEN")]
        CUER_SEGUNDO_APELLIDO_LEN,

        [Description("@CUER_EMBARGO_LEN")]
        CUER_EMBARGO_LEN,

        [Description("@CUER_INGRESO_BASE_LEN")]
        CUER_INGRESO_BASE_LEN,

        [Description("@CUER_VALOR_LEN")]
        CUER_VALOR_LEN,

        [Description("@CUER_PERIODO_LEN")]
        CUER_PERIODO_LEN,

        [Description("@CUER_GRADO_LEN")]
        CUER_GRADO_LEN,

        [Description("@CUER_UNIDAD_OPERATIVA_LEN")]
        CUER_UNIDAD_OPERATIVA_LEN,

        [Description("@FIN_CONSEC_LEN")]
        FIN_CONSEC_LEN,

        [Description("@FIN_INDICADOR_CONTROL_LEN")]
        FIN_INDICADOR_CONTROL_LEN,

        [Description("@FIN_SUM_APORTES_LEN")]
        FIN_SUM_APORTES_LEN,

        [Description("@FIN_COD_FIN_LEN")]
        FIN_COD_FIN_LEN,

        [Description("@PAR_VERSION")]
        PAR_VERSION
    }
}
