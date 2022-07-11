using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Abecedario

    {
        [Key]
        public int LTR_ID { get; set; }
        public string LTR_LETRA { get; set; }
        public bool LTR_ACTIVIDAD { get; set; }
    }
}
