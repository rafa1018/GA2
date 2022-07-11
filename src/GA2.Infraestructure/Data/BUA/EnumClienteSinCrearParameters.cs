using System.ComponentModel;

namespace GA2.Infraestructure.Data.BUA
{
    /// <summary>
    /// Lista de parametros que se reciben de un cliente sin crear en BUA
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public enum EnumClienteSinCrearParameters
    {
        [Description("DIGITO_FUERZA")]
        DIGITO_FUERZA,

        [Description("TIPO_IDENTIFICACION")]
        TIPO_IDENTIFICACION,

        [Description("IDENTIFICACION")]
        IDENTIFICACION,

        [Description("CODIGO_MILITAR")]
        CODIGO_MILITAR,

        [Description("PRIMER_NOMBRE")]
        PRIMER_NOMBRE,

        [Description("SEGUNDO_NOMBRE")]
        SEGUNDO_NOMBRE,

        [Description("PRIMER_APELLIDO")]
        PRIMER_APELLIDO,

        [Description("SEGUNDO_APELLIDO")]
        SEGUNDO_APELLIDO,

        [Description("GRADO")]
        GRADO,

        [Description("UNIDAD_OPERATIVA")]
        UNIDAD_OPERATIVA
    }
}
