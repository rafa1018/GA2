using System;

namespace GA2.Application.Dto
{
    public class ConceptoNominaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public string Salario { get; set; }
        public string Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdCategoria { get; set; }


    }
}
