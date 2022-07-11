using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data.Credito.Simulador
{
    public enum EnumCreacionSimulacionClienteParams
    {
        [Description("@NUMERO_DOCUMENTO")]
        documento,
        
        [Description("@VALOR")]
        valor,
        
        [Description("@TIPO_VIVIENDA")]
        tipoVivienda,
        
        [Description("@TIPO_ABONO")]
        tipoAbono,
        
        [Description("@SUBSIDIO")]
        subsidio,
    }
}
