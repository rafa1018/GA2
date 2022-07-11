using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Clase Enum Prod. ObtenerCausalDesistimiento
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>22/06/2021</date>
    public enum  EmunObtenerCausalDesistimientoParametros
    {
        [Description("@CCD_ID")]
        CCD_ID,
        [Description("@CDD_DESCRIPCION")]
        CDD_DESCRIPCION

    }
}
