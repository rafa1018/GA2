using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumTasaSimuladorParams
    {
        [Description("@SIM_ID")]
        IdSimulacion,

        [Description("@SIM_DESCRIPCION")]
        Descripcion,

        [Description("@SIM_TASA_EA")]
        TasaEA,

        [Description("@SIM_MINIMO_MESES_PLAZO")]
        MinimoPlazoMeses,

        [Description("@SIM_MAXIMO_MESES_PLAZO")]
        MaximoPlazoMeses,

        [Description("@SIM_ESTADO")]
        Estado,

        [Description("@SIM_CREADO_POR")]
        CreadoPor,

        [Description("@SIM_FECHA_CREACION")]
        FechaCreacion,

        [Description("@SIM_MODIFICADO_POR")]
        ModificadoPor,

        [Description("@SIM_FECHA_MODIFICACION")]
        FechaModificacion
    }
}
