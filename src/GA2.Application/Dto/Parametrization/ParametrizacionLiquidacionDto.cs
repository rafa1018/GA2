using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion liquidacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionLiquidacionDto
    {
        public int Id { get; set; }
        public decimal FechaCorte { get; set; }
        public decimal FechaPago { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}