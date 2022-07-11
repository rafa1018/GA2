using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TasaHogarCiudadDto
    {
        public int TasaId { get; set; }
        public decimal ValorTasa { get; set; }
        public int DpcId { get; set; }
        public int DpdId { get; set; }
    }
}
