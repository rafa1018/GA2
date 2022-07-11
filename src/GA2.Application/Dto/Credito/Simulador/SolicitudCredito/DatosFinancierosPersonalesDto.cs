using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DatosFinancierosPersonalesDto
    {
        public Guid IdSimulacionFinancierosPersonales { get; set; }
        public Guid IdSimulacion { get; set; }
        public string DescripcionSalario { get; set; }
        public decimal ValorSalario { get; set; }
        public string DescripcionOtroIngreso { get; set; }
        public decimal ValorOtroIngreso { get; set; }
        public string DescripcionOtroIngreso1 { get; set; }
        public decimal ValorOtroIngreso1 { get; set; }
        public string DescripcionOtroIngreso2 { get; set; }
        public decimal ValorOtroIngreso2 { get; set; }
        public string DescripcionOtroIngreso3 { get; set; }
        public decimal ValorOtroIngreso3 { get; set; }
        public string DescripcionOtroIngreso4 { get; set; }
        public decimal ValorOtroIngreso4 { get; set; }
        public string DescripcionOtroIngreso5 { get; set; }
        public decimal ValorOtroIngreso5 { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public Guid UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}