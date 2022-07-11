using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumValidacionDocumentosParams
    {
        [Description("@SOC_ID")]
        IdSolicitud,
        
        [Description("@TCR_ID")]
        IdTipoCredito,
        
        [Description("@ORDEN")]
        Orden,
        
        [Description("@PRINCIPAL")]
        Principal,
        
        [Description("@DOC_SEGURO_VIDA")]
        DocSeguroVida,
        
        [Description("@DOC_SEGURO_HOGAR")]
        DocSeguroHogar,

    }
}
