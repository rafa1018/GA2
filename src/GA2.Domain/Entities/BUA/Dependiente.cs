using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Dependiente
    {
        public int CLI_ID { get; set; }
        public int TID_ID { get; set; }
        public string DPT_IDENTIFICACION { get; set; }
        public string DPT_NOMBRE { get; set; }
        public decimal DPT_PARTICIPACION { get; set; }
    }
}
