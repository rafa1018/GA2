using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class FuenteRecursos
    {
        public int FRC_ID { get; set; }
        public string FRC_DESCRIPCION { get; set; }
        public string FRC_CAJA { get; set; }
        public int FRC_ESTADO { get; set; }
        public Guid FRC_CREADO_POR { get; set; }
        public DateTime FRC_FECHA_CREACION { get; set; }
    }
}
