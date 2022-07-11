using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion de tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>08/04/2021</date>
    /// </summary>
    public class ParametrizacionTasaDto
    {
        public int Id { get; set; }
        public decimal TasaUsuraEA { get; set; }
        public decimal TasaUsuraNM { get; set; }
        public decimal TasaCorrienteEA { get; set; }
        public decimal TasaCorrienteNM { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}