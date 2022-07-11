using System;
namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Simulacion Datos Financieros
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class SimulacionDatosFinancierosDto
    {
        public Guid Id { get; set; }
        public Guid IdSimulacion { get; set; }
        public string DescripcionSalario { get; set; }
        public float ValorSalario { get; set; }
        public string DescripcionOtroIngresos { get; set; }
        public float ValorOtrosIngresos { get; set; }
        public string DescripcionOtroIng1 { get; set; }
        public float ValorOtrosIngresos1 { get; set; }
        public string DescripcionOtroIng2 { get; set; }
        public float ValorOtrosIngresos2 { get; set; }
        public string DescripcionOtroIng3 { get; set; }
        public float ValorOtrosIngresos3 { get; set; }
        public string DescripcionOtroIng4 { get; set; }
        public float ValorOtrosIngresos4 { get; set; }
        public string DescripcionOtroIng5 { get; set; }
        public float ValorOtrosIngresos5 { get; set; }
        public float ValorTotalIngresos { get; set; }
        public float ValorTotalEgresos { get; set; }
        public Guid UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }


    }
}
