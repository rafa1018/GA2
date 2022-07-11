using System;
using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Form submodule
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class Formulario
    {
        public Guid FRM_ID { get; set; }
        public Guid MNU_ID { get; set; }
        public Guid SBM_ID { get; set; }
        public string FRM_DESCRIPCION { get; set; }
        public bool FRM_VISIBLE { get; set; }
        public IEnumerable<PropiedadFormulario> PROPIEDADES { get; set; }
        public Guid FRM_MODIFICADOPOR { get; set; }
        public DateTime FRM_FECHAMODIFICACION { get; set; }
        public Guid FRM_CREADOPOR { get; set; }
        public DateTime FRM_FECHACREACION { get; set; }
        public bool FRM_ESTADO { get; set; }
    }
}


