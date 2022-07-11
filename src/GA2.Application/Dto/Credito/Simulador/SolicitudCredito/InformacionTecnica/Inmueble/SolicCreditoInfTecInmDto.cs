using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicCreditoInfTecInmDto
    {
        [Key]
        public Guid idSolicitudInfoTecnicaInmueble { get; set; }
        public Guid idSolicitudtecnica { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public string numeroMatricula { get; set; }
        public DateTime fechaMatricula { get; set; }
        public string numeroChip { get; set; }
        public string cedulaCatastral { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
