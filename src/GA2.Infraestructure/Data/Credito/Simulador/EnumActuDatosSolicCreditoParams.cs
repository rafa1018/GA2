using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumActuDatosSolicCreditoParams
    {
        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@SOC_CONVENIO_ASEGURADORA")]
        convenioAseguradora,

        [Description("@SOC_CONVENIO_ASEGURADORA_HOGAR")]
        convenioAseguradoraHogar,

        [Description("@ASE_ID")]
        idAseguradora,
        
        [Description("@ASE_ID_HOGAR")]
        idAseguradoraHogar,

        [Description("@SOC_PORC_EXTRAPRIMA")]
        porcentajeExtraprima,

        [Description("@SOC_ACTUALIZADO_POR")]
        actualizadoPor,

        [Description("@SOC_FECHA_ACTUALIZA")]
        fechaActualiza
    }
}
