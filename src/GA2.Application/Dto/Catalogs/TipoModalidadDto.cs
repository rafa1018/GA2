using System;

namespace GA2.Application.Dto
{
    public class TipoModalidadDto
    {
        public Guid IdTipoModalidad { get; set; }
        public string DescripcionTipoModalidad { get; set; }
        public bool Activo { get; set; }
        public string codigoModalidad { get; set; }
    }
}
