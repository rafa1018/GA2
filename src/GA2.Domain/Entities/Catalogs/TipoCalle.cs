using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoCalle
    {
        [Key]
        public int TPC_ID { get; set; }
        public string TPC_DESCRIPCION { get; set; }
        public bool TPC_ACTIVO { get; set; }
    }
}
