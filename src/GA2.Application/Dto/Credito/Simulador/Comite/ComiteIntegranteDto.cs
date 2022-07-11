using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class ComiteIntegranteDto
    {
        [Key]
        public Guid? idComiteIntegrante { get; set; }
        public int idComiteCredito { get; set; }
        public int idAsistente { get; set; }
        public int orden { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
