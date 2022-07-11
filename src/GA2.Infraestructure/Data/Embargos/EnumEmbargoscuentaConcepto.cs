using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumEmbargoscuentaConcepto
    {

        [Description("@ECC_ID")]
        ECC_ID,

        [Description("@ECC_VALOR")]
        ECC_VALOR,

        [Description("@ECC_FECHA_INICIO_EMBARGO")]
        ECC_FECHA_INICIO_EMBARGO,

        [Description("@ECC_FECHA_FIN_EMBARGO")]
        ECC_FECHA_FIN_EMBARGO,

        [Description("@ECC_INDICADOR_CESANTIAS")]
        ECC_INDICADOR_CESANTIAS,

        [Description("@EBA_ID")]
        EBA_ID,

        [Description("@TRE_ID")]
        TRE_ID,

        [Description("@TIE_ID")]
        TIE_ID,

        [Description("@CTA_ID")]
        CTA_ID,

        [Description("@CCT_ID")]
        CCT_ID,

        [Description("@EBA_FECHA_REGISTRO")]
        EBA_FECHA_REGISTRO,

        [Description("@EBA_FECHA_ACTUALIZACION")]
        EBA_FECHA_ACTUALIZACION,

        [Description("@EBA_CREADOPOR")]
        EBA_CREADOPOR,

        [Description("@EBA_ACTUALIZADOPOR")]
        EBA_ACTUALIZADOPOR,

        [Description("@ECC_ESTADO")]
        ECC_ESTADO,

        [Description("@TID_ID")]
        TID_ID,


    }
}
