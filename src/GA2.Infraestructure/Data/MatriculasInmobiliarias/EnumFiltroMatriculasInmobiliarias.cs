using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumFiltroMatriculasInmobiliarias
    {
       
        [Description("@MAI_NUMERO_MATRICULA")]
        MAI_NUMERO_MATRICULA,

        [Description("@PRP_NUMERO_IDENTIFICACION")]
        PRP_NUMERO_IDENTIFICACION,

        [Description("@TID_ID")]
        TID_ID,

        [Description("@MAI_ID")]
        MAI_ID,

        [Description("@MAI_FECHA_REGISTRO")]
        MAI_FECHA_REGISTRO,

        [Description("@MAI_DIRECCION")]
        MAI_DIRECCION,

        [Description("@DPD_DEPARTAMENTO")]
        DPD_DEPARTAMENTO,

        [Description("@DPC_NOMBRE_CIUDAD")]
        DPC_NOMBRE_CIUDAD,

        [Description("@PRP_TIPO_IDENTIFICACION")]
        PRP_TIPO_IDENTIFICACION,

        [Description("@PRP_RAZON_SOCIAL")]
        PRP_NOMBRE_RAZON_SOCIAL,

        [Description("@CORREO")]
        CORREO,

        [Description("@TELEFONO")]
        TELEFONO,

    }


    public enum EnumNovedadMatriculasInmobiliarias
    {

        [Description("@NVM_ID")]
        NVM_ID,

        [Description("@NVM_FECHA_NOVEDAD")]
        NVM_FECHA_NOVEDAD,

        [Description("@MAI_ID")]
        MAI_ID,

        [Description("@TOP_ID")]
        TOP_ID,

        [Description("@PCS_ID")]
        PCS_ID,

        [Description("@TSN_ID")]
        TSN_ID,

        [Description("@CAN_ID")]
        CAN_ID,

        [Description("@SOL_ID")]
        SOL_ID,

        [Description("@NVM_CREATEDOPOR")]
        NVM_CREATEDOPOR,

    }

    public enum EnumHistorialPropietarios
    {

        [Description("@MAI_ID")]
        MAI_ID,

        [Description("@PRP_ID")]
        PRP_ID,

        [Description("@PRP_NUMERO_IDENTIFICACION")]
        PRP_NUMERO_IDENTIFICACION,

        [Description("@PRP_NOMBRE_RAZON_SOCIAL")]
        PRP_NOMBRE_RAZON_SOCIAL,

        [Description("@TID_ID")]
        TID_ID,

        [Description("@CORREO")]
        CORREO,

        [Description("@TELEFONO")]
        TELEFONO,

    }
}
