using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion de plazos
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>80/04/2021</date>
    /// </summary>
    public class ParametrizacionPlazosDto
    {
        public int Id { get; set; }
        public decimal YearMin { get; set; }
        public decimal MonthMin { get; set; }
        public decimal YearMax { get; set; }
        public decimal MonthMax { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}