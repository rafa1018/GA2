
using System;

namespace GA2.Application.Dto
{
    public class PropietarioDto
    {
        public Guid propietarioId { get; set; }
        public Guid solicitudId { get; set; }
        public string numeroIdentificacion { get; set; }
        public int tipoIdentificacionId { get; set; }
        public string tipoIdentificacionDesc { get; set; }
        public bool estado { get; set; }
        public TipoIdentificacionMatricula tipoIdentificacion { get; set; }
    }
}
