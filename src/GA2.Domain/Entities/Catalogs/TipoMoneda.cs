using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoMoneda
    {
        [Key]
        public int MND_ID { get; set; }
        public string MND_DESCRIPCION { get; set; }
        public string MND_CODIGO { get; set; }
    }
}
