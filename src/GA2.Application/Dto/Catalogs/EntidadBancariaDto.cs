using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class EntidadBancariaDto
    {
        public Guid idEntidadBancaria { get; set; }
        public string nombreRazonSocial { get; set; }
        public int codigoBanco { get; set; }
        public bool estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid modificadoPor { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
