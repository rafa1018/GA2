using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class IntegrantePorComiteDto
    {
        [Key]
        public Guid? idIntegrantePorComite { get; set; }
        public int idComite { get; set; }

        // public int idIntegrante { get; set; }
        public int idIntegranteComite { get; set; }
        public int orden { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string cargo { get; set; }
        public int indicador { get; set; }
    }
}
