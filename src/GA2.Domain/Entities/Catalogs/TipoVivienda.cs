using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoVivienda
    {
        [Key]
        public int TVV_ID { get; set; }
        public string TVV_DESCRIPCION { get; set; }
        public bool TVV_PROMOCIONADA { get; set; }
        public bool TVV_ACTIVA { get; set; }
    }
}
