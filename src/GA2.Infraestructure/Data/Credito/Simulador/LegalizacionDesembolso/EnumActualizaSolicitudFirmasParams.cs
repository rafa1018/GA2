using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumActualizaSolicitudFirmasParams
    {

        [Description("@SOC_ID")]
        IdSolicitudCredito,

        [Description("@@SOC_VALIDA_FIRMAS")]
        ValidaFirmas,

        [Description("@@SOC_OBSERVACION_VALIDA_FIRMA")]
        ObservacionValidaFirmas,

        [Description("@SOC_ACTUALIZADO_POR")]
        ActualizadoPor,

        [Description("@SOC_FECHA_ACTUALIZA")]
        FechaActualiza,
    }
}
