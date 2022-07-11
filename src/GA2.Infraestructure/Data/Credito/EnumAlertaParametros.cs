using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    // <summary>
    /// Parametros AlertasParametros
    /// <author>Cristian Gonzalez </author>
    /// <date>29/04/2021</date>
    /// </summary>
    /// 
    public enum EnumAlertaParametros
    {
        [Description("@ALA_ID")]
        ALA_ID,
        [Description("@ALA_DESCRIPCION")]
        ALA_DESCRIPCION,
        [Description("@ALA_MENSAJE")]
        ALA_MENSAJE,
        [Description("@ALA_FECHA_CREACION")]
        ALA_FECHA_CREACION,
        [Description("@ALA_MODIFICADO_POR")]
        ALA_MODIFICADO_POR,
        [Description("@ALA_FECHA_MODIFICACION")]
        ALA_FECHA_MODIFICACION

    }
}
