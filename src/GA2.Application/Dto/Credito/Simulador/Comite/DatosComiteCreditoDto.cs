using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class DatosComiteCreditoDto
    {
        [Key]
        public int CodigoComite { get; set; }
        public string Fecha { get; set; }
        public string Lugar { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinalizacion { get; set; }
        public int NumeroComite { get; set; }
        public string Desarrollo { get; set; }
        public string TemasAprobacion { get; set; }
        public string Anotacion { get; set; }
        public string CargoAnalista { get; set; }
        public string CodigoEstado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }
        public string Estado { get; set; }
        public List<ComiteIntegranteDto> ComiteIntegrantesDto { get; set; }
        public List<TemaComiteCreditoDto> TemasComiteCreditoDto { get; set; }
    }
}
