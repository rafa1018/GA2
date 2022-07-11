using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Pais
    {
        [Key]
        public int DPP_ID { get; set; }
        public int DPP_CODIGO { get; set; }
        public string DPP_NOMBRE { get; set; }
        public string DPP_INDICATIVOTEL { get; set; }
    }
}
