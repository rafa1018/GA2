using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Property of form 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class PropiedadFormulario
    {
        public Guid PFR_ID { get; set; }
        public Guid FRM_ID { get; set; }
        public Guid PFR_FORMID { get; set; }
        public string PFR_NOMBRE { get; set; }
        public string PFR_DESCRIPCION { get; set; }
        public bool PFR_READONLY { get; set; }
        public bool PFR_VISIBLE { get; set; }
        public Guid PFR_MODIFICADOPOR { get; set; }
        public DateTime PFR_FECHAMODIFICACION { get; set; }
        public Guid PFR_CREADOPOR { get; set; }
        public DateTime PFR_FECHACREACION { get; set; }
        public bool PFR_ESTADO { get; set; }
    }
}
