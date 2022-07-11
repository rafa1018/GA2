using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicCreditoInfTecnicaDto
    {
        [Key]
        public Guid IdSolicitudInformacionTecnica { get; set; }
        public Guid IdSolicitudCredito { get; set; }
        public int ValorAvaluoComercial { get; set; }
        public int ValorVentaInmueble { get; set; }
        public string ConsideracionesFinales { get; set; }
        public string DeclaraCumplimiento { get; set; }
        public string CondicionesSalvedades { get; set; }
        public string ConceptoEstTecnico { get; set; }
        public string Estrato { get; set; }
        public string NombreAliado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IEnumerable<SolicCreditoInfTecInmDto> solicitudesCreditoInfTecnicaInmueble { get; set; }
    }
}
