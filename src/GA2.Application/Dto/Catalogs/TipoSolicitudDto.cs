using System;

namespace GA2.Application.Dto
{
    public class TipoSolicitudDto
    {
        public Guid IdTipoSolicitud { get; set; }
        public string DescripcionTipoSolicitud { get; set; }
        public bool Activo { get; set; }
    }
}
