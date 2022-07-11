using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumCronograma
    {
        [Description("@CRO_ID")]
        CRO_ID,
        [Description("@UEJ_ID")]
        UEJ_ID,
        [Description("@CRO_FECHA_REPORTE")]
        CRO_FECHA_REPORTE,
        [Description("@CRO_FECHA_INICIO")]
        CRO_FECHA_INICIO,
        [Description("@CRO_FECHA_FIN")]
        CRO_FECHA_FIN,
        [Description("@CRO_PERIODO")]
        CRO_PERIODO,
        [Description("@FRT_ID")]
        FRT_ID,
        [Description("@MDE_ID")]
        MDE_ID,
    }
}
