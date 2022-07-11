using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicCreditoInfJurInmDto
    {
        [Key]
        public Guid IdSolicitudInfJuridicaInmueble { get; set; }
        public Guid IdSolicitudInformacionJuridica { get; set; }
        public Guid IdSolicitudCredito { get; set; }
        public string NumeroMatricula { get; set; }
        public string CedulaCatastral { get; set; }
        public int AreaPrivada { get; set; }
        public int AvaluoComercial { get; set; }
        public int AvaluoCatastral { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
