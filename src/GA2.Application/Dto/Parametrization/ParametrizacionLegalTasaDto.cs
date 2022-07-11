using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion legal tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionLegalTasaDto
    {
        public int Id { get; set; }
        public decimal TasaFrech { get; set; }
        public DateTime VigenciaTasaFrech { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}