using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class PeticionConsultarSolicitudCesantiasDto
    {
        // public DateTime? FechaSolicitud { get; set; }
        public string Identificacion { get; set; }
        public int EstadoTarea { get; set; } //Pendiente, En tramite, Subsanacion, Aprobada, Rechazada
        public Guid? TipoSolicitud { get; set; } //PSC_PROCESO
    }
}
