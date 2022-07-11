using System;

namespace GA2.Application.Dto
{
    public class LoginIntegracionesDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string NombreAplicacion { get; set; }
        public string Contrasena { get; set; }
        public string AplicacionId { get; set; }
    }
}
