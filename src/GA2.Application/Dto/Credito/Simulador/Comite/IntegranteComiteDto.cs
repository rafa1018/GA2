using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class IntegranteComiteDto
    {
        [Key]
        public int idIntegranteComite { get; set; }
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string tipoIntegrante { get; set; }
        public int estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int idCodigoComite { get; set; }
        public int idComiteIntegrante { get; set; }
        public int orden { get; set; }
    }
}
