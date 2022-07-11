using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumEmbargoParameters
    {
        [Description("@EBA_ID")]
        EBA_ID,

        [Description("@EBA_RADICADO_WORK_MANAGER")]
        EBA_RADICADO_WORK_MANAGER,

        [Description("@EBA_FECHA_RADICADO_WORK_MANAGER")]
        EBA_FECHA_RADICADO_WORK_MANAGER,

        [Description("@EBA_RADICADO_JUZGADO")]
        EBA_RADICADO_JUZGADO,

        [Description("@EBA_FECHA_RADICADO_JUZGADO")]
        EBA_FECHA_RADICADO_JUZGADO,

        [Description("@EBA_EMAIL_RESPUESTA")]
        EBA_EMAIL_RESPUESTA,

        [Description("@EBA_DIRECCION_RESPUESTA")]
        EBA_DIRECCION_RESPUESTA,

        [Description("@EBA_NOMBRE_DEMANDANTE")]
        EBA_NOMBRE_DEMANDANTE,

        [Description("@EBA_NOMBRE_DEMANDADO")]
        EBA_NOMBRE_DEMANDADO,

        [Description("@EBA_EXPEDIENTE_BANCO_AGRARIO")]
        EBA_EXPEDIENTE_BANCO_AGRARIO,

        [Description("@EBA_REMANENTE")]
        EBA_REMANENTE,

        [Description("@EBA_OBSERVACIONES")]
        EBA_OBSERVACIONES,

        [Description("@EBA_RESPUESTA")]
        EBA_RESPUESTA,

        [Description("@EBA_VALOR")]
        EBA_VALOR,

        [Description("@CLI_ID")]
        CLI_ID,

        [Description("@EMB_ID_JUZGADO")]
        EMB_ID_JUZGADO,

        [Description("@TPE_ID")]
        TPE_ID,

        [Description("@TIE_ID")]
        TIE_ID,

        [Description("@EBA_FECHA_REGISTRO")]
        EBA_FECHA_REGISTRO,

        [Description("@EBA_FECHA_ACTUALIZACION")]
        EBA_FECHA_ACTUALIZACION,

        [Description("@EBA_CREADOPOR")]
        EBA_CREADOPOR,

        [Description("@EBA_ACTUALIZADOPOR")]
        EBA_ACTUALIZADOPOR,

        [Description("@FECHA_INICIAL")]
        FECHA_INICIAL,

        [Description("@FECHA_FINAL")]
        FECHA_FINAL,


    }
}
