using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Bis
    {
        [Key]
        public int BS_ID { get; set; }
        public string BS_BIS { get; set; }
        public bool BS_ACTIVO { get; set; }
    }
}
