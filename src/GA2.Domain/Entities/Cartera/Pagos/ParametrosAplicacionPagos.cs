using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ParametrosAplicacionPagos
    {
        public Guid PARAM_ID { get; set; }
        public decimal PARAM_TASA_MORA { get; set; }
        public int PARAM_FACTOR_DIAS { get; set; }
        public Guid PARAM_CREADO_POR { get; set; }
        public DateTime PARAM_FECHA_CREACION { get; set; }
        public Guid PARAM_MODIFICADO_POR { get; set; }
        public DateTime PARAM_FECHA_MODIFICACION { get; set; }
    }
}
