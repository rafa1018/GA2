using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{

    public class Catalogo
    {
        [Key]
        public int CTL_ID { get; set; }
        public string CTL_NOMBRE { get; set; }
        public string CTL_DESCRIPCION { get; set; }
        public string CTL_EXPRESION { get; set; }
        public bool CTL_EDITABLE { get; set; }
    }
}
