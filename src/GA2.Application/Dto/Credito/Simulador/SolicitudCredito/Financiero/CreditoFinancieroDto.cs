using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class CreditoFinancieroDto
    {
        public Guid IdSolicitudF { get; set; }
        public Guid IdSolicitudCredito { get; set; }
        public string ConceptoSalario { get; set; }
        public int ValorConceptoSalario { get; set; }
        public string Concepto1 { get; set; }
        public int ValorConcepto1 { get; set; }
        public string Concepto2 { get; set; }
        public int ValorConcepto2 { get; set; }
        public string Concepto3 { get; set; }
        public int ValorConcepto3 { get; set; }
        public string Concepto4 { get; set; }
        public int ValorConcepto4 { get; set; }
        public string Concepto5 { get; set; }
        public int ValorConcepto5 { get; set; }
        public string Concepto6 { get; set; }
        public int ValorConcepto6 { get; set; }
        public int ValorTotalIngresos { get; set; }
        public int ValorTotalEgresos { get; set; }
        public string DireccionVivienda { get; set; }
        public string MatriculaVivienda { get; set; }
        public int ValorComercialVivienda { get; set; }
        public string MarcaVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public int ValorComercialVehiculo { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
