using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class NivelAcademico
    {
        public int ID_NIVEL_ACADEMICO { get; set; }
        public int NIVEL_ACADEMICO_ID { get; set; }
        public string DESCRIPCION_NIVEL { get; set; }
    }

    public class NivelAcademicoCatalogo
    {
         public int CVL_ID { get; set; }
         public string CVL_CODIGO { get; set; }
         public string CVL_DESCRIPCION { get; set; }
        public bool CVL_ACTIVO { get; set; }
    }
}
