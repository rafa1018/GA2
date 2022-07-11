using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data.Credito.Simulador
{
    /// <summary>
    /// Enum de Simulacion Datos Financieros
    /// </summary>
    /// <author>John Byron Agudelo Gonzalez</author>
    /// <date>10/05/2021</date>
    public enum EnumSimulacionDatosFinancieros
    {
        [Description("@SDF_ID")]
        SDF_ID,

        [Description("@SLS_ID")]
        SLS_ID,

        [Description("@SDF_DESCRIPCION_SALARIO")]
        SDF_DESCRIPCION_SALARIO,

        [Description("@SDF_VALOR_SALARIO")]
        SDF_VALOR_SALARIO,

        [Description("@SDF_DESCRIPCION_OTRO_INGRESOS")]
        SDF_DESCRIPCION_OTRO_INGRESOS,

        [Description("@SDF_VALOR_OTROS_INGRESOS")]
        SDF_VALOR_OTROS_INGRESOS,

        [Description("@SDF_DESCRIPCION_OTRO_ING1")]
        SDF_DESCRIPCION_OTRO_ING1,

        [Description("@SDF_VALOR_OTROS_INGRESOS1")]
        SDF_VALOR_OTROS_INGRESOS1,

        [Description("@SDF_DESCRIPCION_OTRO_ING2")]
        SDF_DESCRIPCION_OTRO_ING2,

        [Description("@SDF_VALOR_OTROS_INGRESOS2")]
        SDF_VALOR_OTROS_INGRESOS2,

        [Description("@SDF_DESCRIPCION_OTRO_ING3")]
        SDF_DESCRIPCION_OTRO_ING3,

        [Description("@SDF_VALOR_OTROS_INGRESOS3")]
        SDF_VALOR_OTROS_INGRESOS3,

        [Description("@SDF_DESCRIPCION_OTRO_ING4")]
        SDF_DESCRIPCION_OTRO_ING4,

        [Description("@SDF_VALOR_OTROS_INGRESOS4")]
        SDF_VALOR_OTROS_INGRESOS4,

        [Description("@SDF_DESCRIPCION_OTRO_ING5")]
        SDF_DESCRIPCION_OTRO_ING5,

        [Description("@SDF_VALOR_OTROS_INGRESOS5")]
        SDF_VALOR_OTROS_INGRESOS5,

        [Description("@SDF_VALOR_TOTAL_INGRESOS")]
        SDF_VALOR_TOTAL_INGRESOS,

        [Description("@SDF_VALOR_TOTAL_EGRESOS")]
        SDF_VALOR_TOTAL_EGRESOS,

        [Description("@SDF_USUARIO_ACTUALIZA")]
        SDF_USUARIO_ACTUALIZA,

        [Description("@SDF_FECHA_ACTUALIZA")]
        SDF_FECHA_ACTUALIZA,
    }
}
