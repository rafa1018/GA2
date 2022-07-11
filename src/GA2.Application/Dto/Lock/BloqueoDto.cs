using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>05/05/2021</date>
    /// </summary>
    public class BloqueoDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Concepto { get; set; }
        public string DiasMora { get; set; }
        public bool Reversible { get; set; }
        public bool AceleracionDeuda { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}