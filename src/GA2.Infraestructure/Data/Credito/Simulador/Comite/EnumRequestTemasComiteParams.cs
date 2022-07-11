using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumRequestTemasComiteParams
    {
        [Description("@COT_ID")]
        idTema,
        
        [Description("@COC_ID")]
        idComite,
        
        [Description("@IND")]
        indicador
    }
}
