using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumActualizaSolicitudDesembolsoParams
    {

        [Description("@SOC_ID")]
        IdSolicitudCredito,

        [Description("@SOC_VALIDA_DESEMBOLSO")]
        ValidaDesembolso,

        [Description("@SOC_OBSERVACION_VALIDA_DES")]
        ObservacionValidaDesembolso,

        [Description("@SOC_ACTUALIZADO_POR")]
        ActualizadoPor,

        [Description("@SOC_FECHA_ACTUALIZA")]
        FechaActualiza,
    }
}
