using System;

namespace GA2.Domain.Entities
{
    public class ConceptoNomina
    {
        public int CNN_ID { get; set; }
        public string CNN_DESCRIPCION { get; set; }
        public string CNN_SIGLA { get; set; }
        public string CNN_SALARIO { get; set; }
        public string CNN_ESTADO { get; set; }
        public Guid CNN_CREADO_POR { get; set; }
        public DateTime CNN_FECHA_CREACION { get; set; }
        public Guid CNN_MODIFICADO_POR { get; set; }
        public DateTime CNN_FECHA_MODIFICACION { get; set; }
        public int CTG_ID { get; set; }

    }
}
