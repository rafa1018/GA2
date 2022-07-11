using System;

namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Base auditory dto
    /// </summary>
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
