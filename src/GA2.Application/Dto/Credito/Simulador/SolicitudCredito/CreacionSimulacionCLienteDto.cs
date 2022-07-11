using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GA2.Application.Dto
{
    public class CreacionSimulacionClienteDto
    {
        [Key]
        public string documento { get; set; }
        //public string tipoVivienda { get; set; }
        public double? valor { get; set; }
        //public string tipoAbono { get; set; }
        //public string subsidio { get; set; }
        //public bool abonoUnico { get; set; }
        public int plazo { get; set; }
        public double valorPrestamo { get; set; }
        public double valorCuota { get; set; }
        public int simId { get; set; }
        public int tipoIdentificacion { get; set; }
        public decimal porOpcionCompra { get; set; }
        public decimal CanonInicial { get; set; }
        public bool ViviendaNueva { get; set; }
    }
}
