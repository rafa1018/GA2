using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class DocumentoTipo
    {
        public int TDC_ID { get; set; }
        public string TDC_ABRV { get; set; }
        public string TDC_DECRIPCION { get; set; }
        public bool TDC_ESTADO { get; set; }
    }
}
