using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Sexo
    {
        [Key]
        public int SX_ID { get; set; }
        public string SX_DESCRIPCION { get; set; }

    }
}
