using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ParamGeneralesSeguros
    {
        public int SEG_ID { get; set; }
        public decimal SEG_VIDA { get; set; }
        public decimal SEG_TODO_RIESGO { get; set; }
        public DateTime SEG_FECHA_MODIFICACION { get; set; }
        public int SEG_MODIFICADO_POR { get; set; }
        public bool SEG_ESTADO { get; set; }
        public int ID_EXC_SEGURO { get; set; }
        public int DPP_ID { get; set; }
        public int DPD_CODIGO { get; set; }
        public int DPC_ID { get; set; }
        public int DPC_CODIGO { get; set; }
    }
}
