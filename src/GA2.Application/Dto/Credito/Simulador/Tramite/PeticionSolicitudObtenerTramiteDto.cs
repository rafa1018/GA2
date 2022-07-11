using System;

namespace GA2.Application.Dto
{
    public class PeticionSolicitudObtenerTramiteDto
    {
        public DateTime? FechaSolicitud { get; set; }
        public string Identificacion { get; set; }
        public Guid Usuario { get; set; }
        public int? Estado { get; set; }
        public int? TipoCredito { get; set; }
    }
}
