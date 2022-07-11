using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TiVivienda
    {
        [Key]
        public int TIV_VIVIENDA_ID { get; set; }
        public string TIV_VIVIENDA_DESCRIPCION { get; set; }
    }
}
