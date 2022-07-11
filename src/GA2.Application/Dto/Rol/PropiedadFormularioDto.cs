using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Property of form 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class PropiedadFormularioDto
    {
        public Guid Id { get; set; }
        public Guid FormularioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool ReadOnly { get; set; }
        public bool Visible { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
