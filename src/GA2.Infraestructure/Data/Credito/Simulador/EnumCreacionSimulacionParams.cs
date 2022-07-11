using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumCreacionSimulacionParams
    {
        [Description("@NUMERO_DOCUMENTO")]
        numDocumento,

        [Description("@TIPO_VIVIENDA")]
        tipoVivienda,

        [Description("@VALOR")]
        valorVivienda,

        [Description("@TIPO_ABONO")]
        tipoAbono,

        [Description("@SUBSIDIO")]
        subsidio,

        [Description("@PLAZO")]
        plazo,

        [Description("@VLR_PRESTAMO")]
        valorPrestamo,

        [Description("@VLR_CUOTA")]
        valorCuota
    }
}
