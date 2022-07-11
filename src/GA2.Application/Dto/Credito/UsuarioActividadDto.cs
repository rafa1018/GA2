using System;

namespace GA2.Application.Dto
{

    /// <summary>
    /// Propiedades Dto de Usuario Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class UsuarioActividadDto
    {
        public long Id { get; set; }
        public int AflId { get; set; }
        public Guid IdUsers { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
