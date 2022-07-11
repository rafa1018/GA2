using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class NivelAcademicoDto
    {
        public int IdNivelAcademico { get; set; }
        public int NivelAcademicoId { get; set; }
        public string Descripcion { get; set; }
    }

    public class NivelAcademicoCatalogoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
