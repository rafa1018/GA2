using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Submodule menu app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class SubMenuDto
    {
        public Guid MenuId { get; set; }
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string Icono { get; set; }
        public string Descripcion { get; set; }
        public bool Visible { get; set; }
        public FormularioDto Formulario { get; set; }
        public Guid FormularioId { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
