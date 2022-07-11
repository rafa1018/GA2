using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoTelefono
    {
        [Key]
        public int TPT_ID { get; set; }
        public string TPT_DESCRIPCION { get; set; }
        public bool TPT_ACTIVO { get; set; }
    }
}
