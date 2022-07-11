using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Table Module app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>23/03/2021</date>
    public class MenuDto
    {
        public Guid Id { get; set; }
        public Guid AplicacionId { get; set; }
        public string Descripcion { get; set; }
        public bool Visible { get; set; }
        public string Link { get; set; }
        public string Icono { get; set; }
        public IEnumerable<SubMenuDto> SubMenus { get; set; }
        public Guid FormularioId { get; set; }
        public FormularioDto Formulario { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
