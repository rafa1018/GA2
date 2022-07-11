using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion legal alivio
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionLegalAlivioDto
    {
        public int Id { get; set; }
        public decimal AlivioCuota { get; set; }
        public DateTime VigenciaAlivioCuota { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}