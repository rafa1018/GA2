using System;

namespace GA2.Application.Dto
{
    public class ParametrosObtenerCesantiasDto
    {
        public Guid? solicitudId { get; set; }
        public Guid subModalidadId { get; set; }
        public int? IdCliente { get; set; }
    }
}
