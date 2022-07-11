using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ValidacionDocumentos
    {
        public Guid SOC_ID { get; set; }
        public int TCR_ID { get; set; }
        public int ORDEN { get; set; }
        public string PRINCIPAL { get; set; }
        public int DOC_SEGURO_VIDA { get; set; }
        public int DOC_SEGURO_HOGAR { get; set; }
        public string FLU_ID { get; set; }
        public string AFL_ID { get; set; }
        public string DCA_ID { get; set; }
        public string TDC_ID { get; set; }
        public string TDC_DESCRIPCION { get; set; }
        public string DCA_OBLIGATORIO { get; set; }
        public string DCA_ORDEN { get; set; }
    }
}
