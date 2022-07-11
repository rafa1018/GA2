using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Submodule menu app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class SubMenu
    {
        public Guid MNU_ID { get; set; }
        public Guid SBM_ID { get; set; }
        public string SBM_LINK { get; set; }
        public string SBM_ICONO { get; set; }
        public string SBM_DESCRIPCION { get; set; }
        public bool SBM_VISIBLE { get; set; }
        public Guid FRM_ID { get; set; }
        public Formulario SBM_FORMULARIO { get; set; }
        public Guid SBM_MODIFICADOPOR { get; set; }
        public DateTime SBM_FECHAMODIFICACION { get; set; }
        public Guid SBM_CREADOPOR { get; set; }
        public DateTime SBM_FECHACREACION { get; set; }
        public bool SBM_ESTADO { get; set; }
    }
}
