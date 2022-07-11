using System;

namespace GA2.Application.Dto
{
    class RolesPorUSuarioDto
    {
        public Guid Id { get; set; }
        public Guid RolId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
