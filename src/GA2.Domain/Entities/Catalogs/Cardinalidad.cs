using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Cardinalidad
    {
        [Key]
        public int CRD_ID { get; set; }
        public string CRD_DESCRIPCION { get; set; }
        public bool CRD_ACTIVO { get; set; }
    }
}
