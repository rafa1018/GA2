using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Fuerzas
    {
        [Key]
        public int FRZ_ID { get; set; }
        public string FRZ_CODIGO { get; set; }
        public string FRZ_DESCRIPCION { get; set; }
        public int FRZ_DIGITO { get; set; }
        public bool FRZ_SOLDADO { get; set; }
    }
}
