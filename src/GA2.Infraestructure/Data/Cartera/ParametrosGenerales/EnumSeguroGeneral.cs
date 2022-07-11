using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumSeguroGeneral
    {
        [Description("@SEG_ID")]
        idSeguro,
        [Description("@SEG_VIDA")]
        seguroVida,
        [Description("@SEG_TODO_RIESGO")]
        seguroTodoRiesgo,
        [Description("@SEG_FECHA_MODIFICACION")]
        seguroFechaModificacion,
        [Description("@SEG_MODIFICADO_POR")]
        seguroModificadoPor,
        [Description("@SEG_ESTADO")]
        seguroEstado,
        [Description("@DPP_ID")]
        departamentoId,
        [Description("@DPD_CODIGO")]
        departamentoCodigo,
        [Description("@DPC_ID")]
        ciudadId,
        [Description("@DPC_CODIGO")]
        ciudadCodigo,
        [Description("@ID_EXC_SEGURO")]
        idExcepcionSeguro
    }
}
