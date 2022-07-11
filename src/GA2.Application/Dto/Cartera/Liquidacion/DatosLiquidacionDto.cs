using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DatosLiquidacionDto
    {
        public int IdLiquidacion { get; set; }
        public int FechaCorte { get; set; }
        public int FechaPago { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Estado { get; set; }
    }
}
