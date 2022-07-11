using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Proceso de negocio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public class Procesos
    {
        public Guid PCS_ID { get; set; }
        public string PCS_NOMBRE { get; set; }
        public string PCS_DESCRIPCION { get; set; }
        public bool PCS_ESTADO { get; set; }
        public Guid PSC_CREATEDOPOR { get; set; }
        public DateTime PSC_FECHACREACION { get; set; }
        public Guid PSC_MODIFICADOPOR { get; set; }
        public DateTime PSC_FECHAMODIFICACION { get; set; }
        public string PSC_VERSION { get; set; }
    }
}
