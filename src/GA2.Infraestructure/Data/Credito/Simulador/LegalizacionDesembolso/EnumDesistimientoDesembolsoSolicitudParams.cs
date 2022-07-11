using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumDesistimientoDesembolsoSolicitudParams
    {
        [Description("@SID_ID")]
        IdSolicitudDesistimiento, 

        [Description("@SOC_ID")]
        IdSolicitudCredito, 

        [Description("@FRC_ID")]
        IdFuenteRecursos, 

        [Description("@SID_VALOR_DESEMBOLSO")]
        ValorDesembolso, 

        [Description("@SID_FECHA_DESEMBOLSO")]
        FechaDesembolso, 

        [Description("@SID_APLICADO")]
        Aplicado, 

        [Description("@SID_APLICADO_POR")]
        AplicadoPor, 

        [Description("@SID_FECHA_APLICACION")]
        FechaAplicacion, 

        [Description("@SID_ANULADO")]
        Anulado, 

        [Description("@CDD_ID")]
        IdCdd, 

        [Description("@SID_ANULADO_POR")]
        AnuladoPor, 

        [Description("@SID_FECHA_ANULACION")]
        FechaAnulacion, 

        [Description("@SID_OBSERVACION_ANULACION")]
        ObservacionAnulacion, 

        [Description("@SID_CREADO_POR")]
        CreadoPor, 

        [Description("@SID_FECHA_CREACION")]
        FechaCreacion, 

        [Description("@SID_ACTUALIZADO_POR")]
        ActualizadoPor, 

    }
}
