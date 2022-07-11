using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class TemaComiteCreditoDto
    {
        [Key]
        public Guid? idTema { get; set; }
        public int idComiteCredito { get; set; }
        public int idTemaComite { get; set; }
        public int orden { get; set; }
        public string observacion { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string descripcionTema { get; set; }
    }
}
