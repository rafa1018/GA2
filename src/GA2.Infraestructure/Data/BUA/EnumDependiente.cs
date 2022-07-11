using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumDependientParameters
    {
        [Description("@IdCliente")]
        CLI_ID,
        [Description("@IdTipoIdentificacion")]
        TID_ID,
        [Description("@Identificacion")]
        DPT_IDENTIFICACION,
        [Description("@Nombre")]
        DPT_NOMBRE,
        [Description("@Participacion")]
        DPT_PARTICIPACION,
    }
}
