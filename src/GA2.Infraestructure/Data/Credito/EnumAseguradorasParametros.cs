using System.ComponentModel;

// <summary>
/// Parametros  Aseguradoras
/// <author>Cristian Gonzalez </author>
/// <date>29/04/2021</date>
/// </summary>
/// 
namespace GA2.Infraestructure.Data
{
    public enum EnumAseguradorasParametros
    {
        [Description("@ASE_ID")]
        ASE_ID,

        [Description("@ASE_RAZON_SOCIAL")]
        ASE_RAZON_SOCIAL,

        [Description("@ASE_SITIO_WEB")]
        ASE_SITIO_WEB,

        [Description("@ASE_ESTADO")]
        ASE_ESTADO,

        [Description("@ASE_CREADO_POR")]
        ASE_CREADO_POR,

        [Description("@ASE_FECHA_CREACION")]
        ASE_FECHA_CREACION,

        [Description("@ASE_ACTUALIZADO_POR")]
        ASE_ACTUALIZADO_POR,

        [Description("@ASE_FECHA_ACTUALIZA")]
        ASE_FECHA_ACTUALIZA,

    }
}
