using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoIdentificacion
    {
        [Key]
        public int TID_ID { get; set; }
        public string TID_CODIGO { get; set; }
        public string TID_DESCRIPCION { get; set; }
        public bool TID_EMPRESARIAL { get; set; }
        public bool TID_ACTIVO { get; set; }
        public int TID_ERP { get; set; }
        public int TID_VIGIA { get; set; }
        public int TID_EMBARGO { get; set; }
    }
}
