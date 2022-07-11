using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Ciudad
    {
        [Key]
        public int DPC_ID { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_CODIGO { get; set; }
        public string DPC_NOMBRE { get; set; }
    }
}
