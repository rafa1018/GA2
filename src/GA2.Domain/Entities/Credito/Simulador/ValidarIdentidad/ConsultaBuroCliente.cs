using System;

namespace GA2.Domain.Entities.Credito.Simulador
{
    public class ConsultaBuroCliente
    {
        public Guid CBC_ID { get; set; }
        public DateTime CBC_FECHA_CONSULTA { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string CBC_DECISION_BURO { get; set; }
        public string CBC_SCORE { get; set; }
        public decimal CBC_CAPACIDAD_ENDEUDAMIENTO { get; set; }
        public decimal CBC_NIVEL_ENDEUDAMIENTO { get; set; }
        public decimal CBC_NIVEL_ENDEUDAMIENTO_CUOTA { get; set; }
        public string CBC_HISTORIAL_CREDITO { get; set; }
        public string CBC_HUELLA_CONSULTA { get; set; }
        public Guid CBC_CREADO_POR { get; set; }
        public DateTime CBC_FECHA_CREACION { get; set; }

    }
}
