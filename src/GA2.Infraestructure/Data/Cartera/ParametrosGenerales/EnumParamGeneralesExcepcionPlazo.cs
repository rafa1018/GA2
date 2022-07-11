using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumParamGeneralesExcepcionPlazo
    {
        [Description("@PLAZ_ID")]
        plazoId,
        [Description("@PLAZ_YEAR_MIN")]
        plazoMinimoAnio,
        [Description("@PLAZ_MONTH_MIN")]
        plazoMinimoMes,
        [Description("@PLAZ_YEAR_MAX")]
        plazoMaximoAnio,
        [Description("@PLAZ_MONTH_MAX")]
        plazoMaximoMes,
        [Description("@PLAZ_FECHA_MODIFICACION")]
        plazoFechaModificacion,
        [Description("@PLAZ_MODIFICADO_POR")]
        plazoModificadoPor,
        [Description("@PLAZ_ESTADO")]
        plazoEstado,
        [Description("@TPA_ID")]
        IdTipoActor,
        [Description("@ID_EXE_PLAZO")]
        idExcepcion,
        [Description("@TCR_ID")]
        tipoCredito,
        [Description("@UEJ_ID")]
        unidadEjecutoraId,
        [Description("@ID_EXC_PLAZO")]
        idExcepcionPlazo
    }
}
