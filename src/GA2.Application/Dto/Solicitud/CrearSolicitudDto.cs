using System;

namespace GA2.Application.Dto
{
    public class CrearSolicitudDto
    {
        public int? cuentaId { get; set; }
        public Guid procesoId { get; set; }
        public Guid tipoSubModalidad { get; set; }
        public int clienteId { get; set; }
        public Guid creadoPor { get; set; }
    }
}
