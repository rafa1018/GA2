using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumDocumentoTipoParams
    {
        [Description("@TDC_ID")]
        IdTipoDocumento,

        [Description("@TID_CODIGO")]
        Abreviatura,

        [Description("@TID_DESCRIPCION")]
        Descripcion,

        [Description("@TID_EMPRESARIAL")]
        Empresarial,

        [Description("@TID_ACTIVO")]
        Activo,

        [Description("@TID_ERP")]
        ERP,

        [Description("@TID_AUDITORIA")]
        Auditoria,

        [Description("@TID_EMBARGO")]
        Embargo,

    }
}
