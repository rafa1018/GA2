using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int CTG_ID { get; set; }
        public string CTG_DESCRIPCION { get; set; }
    }
}
