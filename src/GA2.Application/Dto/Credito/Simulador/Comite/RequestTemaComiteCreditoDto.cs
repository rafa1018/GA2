using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestTemaComiteCreditoDto
    {
        public Guid? idTema { get; set; }
        public int idComite { get; set; }
        public int indicador { get; set; }
    }
}
