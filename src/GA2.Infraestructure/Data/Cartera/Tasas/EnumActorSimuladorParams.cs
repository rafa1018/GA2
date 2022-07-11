using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum  EnumActorSimuladorParams
    {
        [Description("@PAR_ID")]
        ParametroId,
        [Description("@SIM_ID")]
        SimuladorId,
        [Description("@TPA_ID")]
        TipoId,
        [Description("@PAR_TASA_EA")]
        ParametroTasaEa,
        [Description("@PAR_ESTADO")]
        ParametroEstado,
        [Description("@PAR_CREADO_POR")]
        ParametroCreadoPor,
        [Description("@PAR_FECHA_CREACION")]
        ParametroFechaCreacion,
        [Description("@PAR_MODIFICADO_POR")]
        ParametroModificadoPor,
        [Description("@PAR_FECHA_MODIFICACION")]
        ParametroFechaModificacion,

    }
}
