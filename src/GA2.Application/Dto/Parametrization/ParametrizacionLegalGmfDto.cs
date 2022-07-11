using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion legal gmf
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionLegalGmfDto
    {
        public int Id { get; set; }
        public decimal Gmf { get; set; }
        public DateTime VigenciaGmf { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}