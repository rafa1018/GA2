using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoCorreo
    {
        [Key]
        public int TCE_ID { get; set; }
        public string TCE_DESCRIPCION { get; set; }
        public bool TCE_ACTIVO { get; set; }
    }
}
