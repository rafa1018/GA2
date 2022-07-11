using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumObtenerSolicitudCredito
    {
        [Description("@SOC_ID")]
        idSolicitud,

        [Description("@SLS_ID")]
        idSls,

        [Description("@CLI_IDENTIFICACION")]
        identificacion,

        [Description("@IND")]
        indicador,
    }
}
