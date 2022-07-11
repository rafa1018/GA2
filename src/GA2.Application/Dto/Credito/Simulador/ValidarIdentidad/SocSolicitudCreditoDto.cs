using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.Credito.Simulador.ValidarIdentidad
{
    public class SocSolicitudCreditoDto
    {
        public Guid SocId { get; set; }
        public DateTime SocFechaSolicitud { get; set; }
        public Int64 SocNumeroSolicitud { get; set; }
        public int TcrId { get; set; }
        public int DpdId { get; set; }
        public int DpcId { get; set; }
        public Guid SlsId { get; set; }
        public int TidId { get; set; }
        public string CliIdentificacion { get; set; }
        public string SocDeclaracionOrigenFondos { get; set; }
        public string  SocAutorizaUsoDatos{ get; set; }
        public string SocAutorizaConsultaCentrales { get; set; }
        public string SocDeclaracionAsegurabilidad { get; set; }
        public string SocEstado { get; set; }
        public string SocConvenioAseguradora { get; set; }
        public int AseId { get; set; }
        public Guid SocCreadoPor { get; set; }
        public DateTime SocFechaCreacion { get; set; }
        public Guid SocActualizadoPor { get; set; }
        public DateTime SocFechaActualiza { get; set; }
    }
}
