using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class EstadoVivienda
    {
        [Key]
        public int ESV_ID { get; set; }
        public string ESV_DESCRIPCION { get; set; }

    }
}
