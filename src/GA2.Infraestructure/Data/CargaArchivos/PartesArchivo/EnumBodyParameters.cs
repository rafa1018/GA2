using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Lista de parametros dle body de un archivo de carga de archivos
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public enum EnumBodyParameters
    {
        [Description("@CONSECUTIVE")]
        CONSECUTIVE,

        [Description("@DIGITO_FUERZA")]
        DIGITO_FUERZA,

        [Description("@UNIDAD_EJECUTORA")]
        UNIDAD_EJECUTORA,

        [Description("@TIPO_IDENTIFICACION")]
        TIPO_IDENTIFICACION,

        [Description("@IDENTIFICACION")]
        IDENTIFICACION,

        [Description("@CODIGO_MILITAR")]
        CODIGO_MILITAR,

        [Description("@PRIMER_NOMBRE")]
        PRIMER_NOMBRE,

        [Description("@SEGUNDO_NOMBRE")]
        SEGUNDO_NOMBRE,

        [Description("@PRIMER_APELLIDO")]
        PRIMER_APELLIDO,

        [Description("@SEGUNDO_APELLIDO")]
        SEGUNDO_APELLIDO,

        [Description("@EMBARGO")]
        EMBARGO,

        [Description("@INGRESO_BASE_CALCULO")]
        INGRESO_BASE_CALCULO,

        [Description("@VALOR")]
        VALOR,

        [Description("@PERIODO")]
        PERIODO,

        [Description("@GRADO")]
        GRADO,

        [Description("@UNIDAD_OPERATIVA")]
        UNIDAD_OPERATIVA

    }
}
