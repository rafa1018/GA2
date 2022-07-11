using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SMCSimulacionClienteDto
    {
        public Guid IdSimulacionCliente { get; set; }
        public Guid IdSimulacion { get; set; }
        public Guid IdDatosPersonales { get; set; }
        public string TipoVivienda { get; set; }
        public double? ValorVivienda { get; set; }
        public string TipoAlivio { get; set; }
        public string TipoAbono { get; set; }
        public string Documento { get; set; }
        public decimal ValorPrestamo { get; set; }
        public decimal TasaEa { get; set; }
        public double TasaMv { get; set; }
        public double TasaFrech { get; set; }
        public string ViviendaVis { get; set; }
        public DateTime FechaSimulacion { get; set; }
        public string UsaRecursosAcumulados { get; set; }
        public string TomaSeguro { get; set; }
        public double ValorPrestamosLeasing { get; set; }
        public int NumeroPreaprobado { get; set; }
        public int TotalCuotas { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public double OpcionCompra { get; set; }
        
    }
}
