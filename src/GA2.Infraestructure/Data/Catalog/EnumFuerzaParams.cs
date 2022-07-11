using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumFuerzaParams
    {
        [Description("@FRZ_CODIGO")]
        Codigo,
        
        [Description("@FRZ_DESCRIPCION")]
        Descripcion,
        
        [Description("@FRZ_SOLDADO")]
        Soldado,
        
        [Description("@FRZ_ID")]
        Id,
        
        [Description("@FRZ_DIGITO")]
        Digito,
    }
}
