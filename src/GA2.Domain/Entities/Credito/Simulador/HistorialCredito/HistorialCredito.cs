using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class HistorialCredito
    {
        public Guid CBC_ID { get; set; }
        public DateTime CBC_FECHA_CONSULTA { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string CBC_DECISION_BURO { get; set; }
        public int CBC_SCORE { get; set; }
        public int CBC_CAPACIDAD_ENDEUDAMIENTO { get; set; }
        public float CBC_NIVEL_ENDEUDAMIENTO { get; set; }
        public float CBC_NIVEL_ENDEUDAMIENTO_CUOTA { get; set; }
        public string CBC_HISTORIAL_CREDITO { get; set; }
        public string CBC_HUELLA_CONSULTA { get; set; }
        public Guid CBC_CREADO_POR { get; set; }
        public DateTime CBC_FECHA_CREACION { get; set; }
        

    }
}
