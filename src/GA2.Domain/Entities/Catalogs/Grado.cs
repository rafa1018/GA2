using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class Grado
    {
        [Key]
        public int GRD_ID { get; set; }
        public string GRD_DESCRIPCION { get; set; }
        public int CTG_ID { get; set; }
        public bool GRD_ESPECIAL { get; set; }
        public int GRD_CODIGO { get; set; }
        public string GRD_SIGLA { get; set; }
        public int FRZ_ID { get; set; }
        public bool GRD_CIVIL { get; set; }
        public bool GRD_ACTIVO { get; set; }
    }
}
