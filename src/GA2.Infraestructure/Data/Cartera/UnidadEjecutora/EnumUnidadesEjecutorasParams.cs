using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumUnidadesEjecutorasParams
    {
        [Description("@PAR_ID")]
        idParametro,
        [Description("@SIM_ID")]
        idSimulacion, 
        [Description("@UEJ_ID")]
        idUnidadEjecutora,
        [Description("@PAR_TASA_EA")]
        tasaEa,
        [Description("@PAR_ESTADO")]
        estado,
        [Description("@UEJ_NOMBRE")]
        nombreUnidadEjecutora,
        [Description("@PAR_CREADO_POR")]
        creadoPor,
        [Description("@PAR_FECHA_CREACION")]
        fechaCreacion,
        [Description("@PAR_MODIFICADO_POR")]
        modificadoPor,
        [Description("@PAR_FECHA_MODIFICACION")]
        fechaModificacion,
    }
}
