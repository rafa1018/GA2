using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class DatosLiquidacion
    {
        public int LIQ_ID {get; set;}
        public int LIQ_FECHA_CORTE {get; set;}
        public int LIQ_FECHA_PAGO {get; set;}
        public DateTime LIQ_FECHA_MODIFICACION {get; set;}
        public int LIQ_ESTADO {get; set;}
    
    }
}
