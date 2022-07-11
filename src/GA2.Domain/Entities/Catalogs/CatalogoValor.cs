using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class CatalogoValor
    {
        [Key]
        public int CAT_ID { get; set; }
        public string CVL_CODIGO { get; set; }
        public string CVL_DESCRIPCION { get; set; }
        public bool CVL_ACTIVO { get; set; }
        public int CVL_ID { get; set; }
    }
}
