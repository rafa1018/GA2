using System.ComponentModel;


namespace GA2.Infraestructure.Data
{
    public enum EnumCatalogoValorParams
    {
        [Description("@CVL_ID")]
        IdCatalogo,
        
        [Description("@CAT_ID")]
        Id,
        
        [Description("@CVL_CODIGO")]
        Codigo,
        
        [Description("@CVL_DESCRIPCION")]
        Descripcion,
        
        [Description("@CVL_ACTIVO")]
        Estado,
    }
}
