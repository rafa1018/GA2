using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Entidad Dto Prod. AplicarDesembolsoSolicitud 
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>21/06/2021</date>
    public class DesembolsoCreditoSolicitudDto
    {
        public Guid SolicitudId { get; set; }
        public Guid SolicitudDesembolsoId { get; set; }
        public Guid AplicadoPor { get; set; }
        public DateTime FechaAplicacion { get; set; }
    }
}
