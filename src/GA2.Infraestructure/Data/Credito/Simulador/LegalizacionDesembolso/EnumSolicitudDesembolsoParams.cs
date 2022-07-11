using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicitudDesembolsoParams
    {
            [Description("@SOC_ID")]
            IdSolicitudCredito,

            [Description("@NUMERO_SOLICITUD")]
            NumeroSolicitud,

            [Description("@TIPO_CREDITO")]
            TipoCredito,

            [Description("@SID_ID")]
            IdSolicitudDesembolso,

            [Description("@CLI_IDENTIFICACION")]
            DocumentoCliente,

            [Description("@NOMBRE_CLIENTE")]
            NombreCliente,

            [Description("@FRC_ID")]
            IdFuenteRecursos,

            [Description("@FUENTE_RECURSO")]
            FuenteRecursos,

            [Description("@SID_FECHA")]
            FechaDesembolso,

            [Description("@SID_VALOR_DESEMBOLSO")]
            ValorDesembolso,

            [Description("@FECHA_APLICACION")]
            FechaAplicacion,

            [Description("@APLICADO_POR")]
            AplicadoPor,

            [Description("@ANULADO")]
            Anulado,

            [Description("@FECHA_ANULACION")]
            FechaAnulacion,

            [Description("@OBSERVACION_ANULACION")]
            ObservacionAnulacion,

            [Description("@ANULADO_POR")]
            AnuladoPor,

            [Description("@CAUSA_ANULACION")]
            CausaAnulacion,

            [Description("@CREADO_POR")]
            CreadoPor,

            [Description("@FECHA_CREACION")]
            FechaCreacion,

            [Description("@ACTUALIZADO_PRO")]
            ActualizadoPor,

            [Description("@FECHA_ACTUALIZACION")]
            FechaActualizacion,
        
            [Description("@APLICADO")]
            Aplicado

    }
}
