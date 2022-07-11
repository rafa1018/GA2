using System;
namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Roles
    /// </summary>
    public class RolDto
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
