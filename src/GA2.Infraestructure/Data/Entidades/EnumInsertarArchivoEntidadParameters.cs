using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumInsertarArchivoEntidadParameters
    {
        [Description("@ENE_ARCHIVOS_ID")]
        ArchivoEntidadId,

        [Description("@ENE_NOMBRE_ARCHIVO")]
        NombreArchivo,

        [Description("@ENE_RUTA_STORAGE")]
        RutaArchivo,

        [Description("@ENE_EXTENSION")]
        ExtensionArchivo,

        [Description("@ENE_FECHA_CARGUE")]
        FechaCargue,

        [Description("@ENE_ID")]
        Entidad,

        [Description("@ENE_PAM_ID")]
        Parametrizacion,

        [Description("@ENE_PAM_ORDEN")]
        Orden,

        [Description("@ENE_PAM_CREATEDOPOR")]
        CreadoPor
    }
}
