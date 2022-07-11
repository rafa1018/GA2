using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumAuditoriaParameter
    {

        [Description("@AUR_NOM_TABLE")]
        AUR_NOM_TABLE,

        [Description("@AUR_FECHA_FILTRO_INICIO")]
        AUR_FECHA_FILTRO_INICIO,

        [Description("@AUR_FECHA_FILTRO_FIN")]
        AUR_FECHA_FILTRO_FIN,

        [Description("@AUR_AGRUPADOR")]
        AUR_AGRUPADOR,

        [Description("@AUR_VER_DETALLE")]
        AUR_VER_DETALLE,

        [Description("@AUR_USR_ID")]
        AUR_USR_ID,

        [Description("@PAGENUM")]
        PAGENUM,

        [Description("@PAGESIZE")]
        PAGESIZE,

    }
}
