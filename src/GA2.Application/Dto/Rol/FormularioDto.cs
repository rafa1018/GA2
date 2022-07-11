using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Form submodule
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class FormularioDto
    {
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public Guid SubMenuId { get; set; }
        public string Descripcion { get; set; }
        public bool Visible { get; set; }
        public IEnumerable<PropiedadFormularioDto> Propiedades { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
