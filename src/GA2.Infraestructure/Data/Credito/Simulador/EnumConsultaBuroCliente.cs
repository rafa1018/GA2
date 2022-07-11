using System.ComponentModel;

namespace GA2.Infraestructure.Data.Credito.Simulador
{
    public enum  EnumConsultaBuroCliente
    {
        [Description("@CBC_ID")]
        CBC_ID,

        [Description("@CBC_FECHA_CONSULTA")]
        CBC_FECHA_CONSULTA,

        [Description("@CLI_IDENTIFICACION")]
        CLI_IDENTIFICACION,

        [Description("@CBC_DECISION_BURO")]
        CBC_DECISION_BURO,

        [Description("@CBC_SCORE")]
        CBC_SCORE,

        [Description("@CBC_CAPACIDAD_ENDEUDAMIENTO")]
        CBC_CAPACIDAD_ENDEUDAMIENTO,

        [Description("@CBC_NIVEL_ENDEUDAMIENTO")]
        CBC_NIVEL_ENDEUDAMIENTO,

        [Description("@CBC_NIVEL_ENDEUDAMIENTO_CUOTA")]
        CBC_NIVEL_ENDEUDAMIENTO_CUOTA,

        [Description("@CBC_HISTORIAL_CREDITO")]
        CBC_HISTORIAL_CREDITO,

        [Description("@CBC_HUELLA_CONSULTA")]
        CBC_HUELLA_CONSULTA,

        [Description("@CBC_CREADO_POR")]
        CBC_CREADO_POR,

        [Description("@CBC_FECHA_CREACION")]
        CBC_FECHA_CREACION
    }
}
