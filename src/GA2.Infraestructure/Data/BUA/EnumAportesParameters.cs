using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumAportesParameters
    {
        [Description("@IdCliente")]
        CLI_ID,
        [Description("@IdCategoria")]
        CGT_ID,
        [Description("@CuotasAcumuladas")]
        APC_CUOTAS_ACUMULADAS,
        [Description("@FechaUltimaCuota")]
        APC_FECHA_ULTIMA_COUTA,
        [Description("@FechaPrimeraCuota")]
        APC_FECHA_PRIMERA_CUOTA
    }
}
