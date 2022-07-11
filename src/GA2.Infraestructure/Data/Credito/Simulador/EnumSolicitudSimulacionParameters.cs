using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicitudSimulacionParameters
    {
        
        [Description("@SLS_ID")]
        Id,
        
        [Description("@SLS_FECHA_SOLICITUD")]
        FechaSolicitud,
        
        [Description("@TCR_ID")]
        TcrId,
        
        [Description("@SLS_NUMERO_PREAPROBADO")]
        NumeroPreAprobado,
        
        [Description("@SLS_PROBLEMA_EMAIL")]
        ProblemaEmail,

        [Description("@SLS_ENVIO_NOTIFICACION")]
        EnvioNotificacion,
        
        [Description("@SLS_RUTA_PDF_RESUMEN")]
        RutaPdf,
        
        [Description("@SLS_PORC_EXTRAPRIMA ")]
        PorcExtraprima,
        
        [Description("@SLS_ESTADO")]
        Estado,

        [Description("@SLS_USUARIO_ACTUALIZA")]
        UsuarioActualiza,
        
        [Description("@SLS_FECHA_ACTUALIZA")]
        FechaActualiza

    }
}
