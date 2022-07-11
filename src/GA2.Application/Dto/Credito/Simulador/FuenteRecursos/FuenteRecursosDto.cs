using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class FuenteRecursosDto
    {
        public int IdFuenteRecursos { get; set; }
        public string Descripcion { get; set; }
        public string Caja { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
