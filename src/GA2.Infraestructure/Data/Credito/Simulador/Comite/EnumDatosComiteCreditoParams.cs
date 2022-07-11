using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumDatosComiteCreditoParams
    {
        [Description("@COC_ID")]
        codigoComite,

        [Description("@COC_FECHA")]
        fecha,

        [Description("@COC_LUGAR")]
        lugar,

        [Description("@COC_HORA_INICIO")]
        horaInicio,

        [Description("@COC_HORA_FINALIZACION")]
        horaFinalizacion,

        [Description("@COC_NUMERO_COMITE")]
        numeroComite,

        [Description("@COC_DESARROLLO")]
        desarrollo,

        [Description("@COC_TEMAS_APROBACION")]
        temasAprobacion,

        [Description("@COC_ANOTACION")]
        anotacion,

        [Description("@COC_CARGO_ANALISTA")]
        cargoAnalista,

        [Description("@COC_ESTADO")]
        codigoEstado,

        [Description("@COC_CREADO_POR")]
        creadoPor,

        [Description("@COC_FECHA_CREACION")]
        fechaCreacion,

        [Description("@COC_ACTUALIZADO_POR")]
        actualizadoPor,

        [Description("@COC_FECHA_ACTUALIZA")]
        fechaActualiza,

        [Description("@ESTADO")]
        estado,

        [Description("@COC_NUMERO_RADICADO")]
        radicado
    }
}
