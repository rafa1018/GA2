using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DatosFinancierosDto
    {
        public Guid IdSolicitudCredito { get; set; }
        public Guid IdSimulacion { get; set; }
        public Guid IdSof { get; set; }
        public string DescripcionSalario { get; set; }
        public int ValorSalario { get; set; }
        public string DescripcionOtroIngresos { get; set; }
        public int ValorOtrosIngresos { get; set; }
        public string DescripcionOtroIng1 { get; set; }
        public int ValorOtrosIngresos1 { get; set; }
        public string DescripcionOtroIng2 { get; set; }
        public int ValorOtrosIngresos2 { get; set; }
        public string DescripcionOtroIng3 { get; set; }
        public int ValorOtrosIngresos3 { get; set; }
        public string DescripcionOtroIng4 { get; set; }
        public int ValorOtrosIngresos4 { get; set; }
        public string DescripcionOtroIng5 { get; set; }
        public int ValorOtrosIngresos5 { get; set; }
        public string DescripcionOtroIng6 { get; set; }
        public int ValorOtrosIngresos6 { get; set; }
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
        public Guid UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
