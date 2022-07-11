using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ParametrosTasaActorDto
    {
        public int ParametroId { get; set; }
        public int SimuladorId { get; set; }
        public int TipoId { get; set; }
        public decimal ParametroTasaEa { get; set; }
        public int ParametroEstado { get; set; }
        public Guid ParametroCreadoPor { get; set; }
        public Guid ParametroModificadoPor { get; set; }


    }
}
