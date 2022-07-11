using System;
using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Table Menu app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>23/03/2021</date>
    public class Menu
    {
        public Guid MNU_ID { get; set; }
        public Guid APP_ID { get; set; }
        public string MNU_DESCRIPCION { get; set; }
        public bool MNU_VISIBLE { get; set; }
        public string MNU_LINK { get; set; }
        public string MNU_ICONO { get; set; }
        public IEnumerable<SubMenu> MNU_SUBMENUS { get; set; }
        public Guid FRM_ID { get; set; }
        public Formulario FRM_FORMULARIO { get; set; }
        public Guid MNU_MODIFICADOPOR { get; set; }
        public DateTime MNU_FECHAMODIFICACION { get; set; }
        public Guid MNU_CREADOPOR { get; set; }
        public DateTime MNU_FECHACREACION { get; set; }
        public bool MNU_ESTADO { get; set; }
    }
}
