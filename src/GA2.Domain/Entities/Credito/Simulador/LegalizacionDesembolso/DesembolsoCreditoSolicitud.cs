using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad Prod. AplicarDesembolsoSolicitud 
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>21/06/2021</date>
    public class DesembolsoCreditoSolicitud
    {
        public Guid SOC_ID { get; set; }
        public Guid SID_ID { get; set; }
        public Guid SID_APLICADO_POR  { get;set;}
        public DateTime SID_FECHA_APLICACION { get;set;}

    }
}
