using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumProgramaEducativoParametros
    {
        [Description("@PGE_ID")]
        PGE_ID,

        [Description("@ENE_ID_FK")]
        ENE_ID,

        [Description("@PGE_DESCRIPCION")]
        PGE_DESCRIPCION,

        [Description("@PGE_ESTADO")]
        PGE_ESTADO,

        [Description("@PGE_CREATEDOPOR")]
        PGE_CREATEDOPOR,

        [Description("@PGE_FECHACREACION")]
        PGE_FECHACREACION,

        [Description("@PGE_MODIFICADOPOR")]
        PGE_MODIFICADOPOR,

        [Description("@PGE_FECHAMODIFICACION")]
        PGE_FECHAMODIFICACION

    }
}