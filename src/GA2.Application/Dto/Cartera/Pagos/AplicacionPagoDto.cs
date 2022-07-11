using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class AplicacionPagoDto
    {
        public Guid IdAplicacionPago { get; set; }
        public Guid IdCredito { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public decimal AbonoSeguroHogar { get; set; }
        public decimal AbonoSeguroVida { get; set; }
        public decimal AbonoInteresCorriente { get; set; }
        public decimal AbonoInteresMora { get; set; }
        public decimal AbonoCapital { get; set; }
        public decimal ValorPago { get; set; }
        public int IdDct { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
