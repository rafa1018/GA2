using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class TemaComiteDto
    {
        [Key]
        public int idTemaComite { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
