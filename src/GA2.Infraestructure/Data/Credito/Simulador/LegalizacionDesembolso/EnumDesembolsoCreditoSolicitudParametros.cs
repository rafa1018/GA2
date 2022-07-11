using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{ 
    /// <summary>
    /// Clase Enum Prod. AplicarDesembolsoSolicitud 
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>21/06/2021</date>
    public enum EnumDesembolsoCreditoSolicitudParametros
    {
        [Description("@SOC_ID")]
        SOC_ID,
        [Description("SID_ID")]
        SID_ID,
        [Description("@SID_APLICADO_POR")]
        SID_APLICADO_POR,
        [Description("@SID_FECHA_APLICACION")]
        SID_FECHA_APLICACION
   
    }
}
