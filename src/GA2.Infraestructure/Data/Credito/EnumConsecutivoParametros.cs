
using System.ComponentModel;


// <summary>
/// Parametros Entidad Consecutivo
/// <author>Cristian Gonzalez </author>
/// <date>24/04/2021</date>
/// </summary>
/// 

namespace GA2.Infraestructure.Data
{
    public enum EnumConsecutivoParametros
    {
        [Description("@CNS_ID")]
        CNS_ID,
        [Description("@CNS_DESCRIPCION")]
        CNS_DESCRIPCION,
        [Description("@CNS_ULTIMO_NUMERO")]
        CNS_ULTIMO_NUMERO,
        [Description("@CNS_ESTADO")]
        CNS_ESTADO,
        [Description("@CNS_CREADO_POR")]
        CNS_CREADO_POR,
        [Description("@CNS_FECHA_CREACION")]
        CNS_FECHA_CREACION,
        [Description("@CNS_ACTUALIZADO_POR")]
        CNS_ACTUALIZADO_POR,
        [Description("@CNS_FECHA_ACTUALIZA")]
        CNS_FECHA_ACTUALIZA,

    }
}
