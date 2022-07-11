using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumSimulacionDatosPersonalesParams
    {
        [Description("@SDP_NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@IND")]
        Indicador,

        [Description("@SDP_VALOR_INMUEBLE")]
        ValorInmueble,

        [Description("@TVV_ID")]
        TipoVivienda,

        [Description("@DPD_ID_INMUEBLE")]
        DepartamentoInmueble,

        [Description("@DPC_ID_INMUEBLE")]
        CiudadInmueble
    }
}
