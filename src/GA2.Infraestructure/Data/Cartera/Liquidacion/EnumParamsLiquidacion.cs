using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumParamsLiquidacion
    {
        [Description("@LIQ_ID")]
        IdLiquidacion,

        [Description("@LIQ_FECHA_CORTE")]
        FechaCorte,

        [Description("@LIQ_FECHA_PAGO")]
        FechaPago,

        [Description("@LIQ_FECHA_MODIFICACION")]
        FechaModificacion,

        [Description("@LIQ_ESTADO")]
        Estado
    }
}
