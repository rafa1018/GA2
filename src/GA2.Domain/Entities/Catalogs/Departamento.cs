using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Departamento
    {
        [Key]
        public int DPD_ID { get; set; }
        public int DPP_ID { get; set; }
        public int DPD_CODIGO { get; set; }
        public string DPD_NOMBRE { get; set; }
        public int REG_ID { get; set; }
        public int DPD_INDICATIVOTEL { get; set; }
    }
}
