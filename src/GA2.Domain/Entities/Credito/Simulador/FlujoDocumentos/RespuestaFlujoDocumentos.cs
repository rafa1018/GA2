using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class RespuestaFlujoDocumentos
    {
        [Key]
        public int TCR_ID { get; set; }
        public int FLU_ID { get; set; }
        public int AFL_ID { get; set; }
        public int DCA_ID { get; set; }
        public int TDC_ID { get; set; }
        public string DOCUMENTO_EXISTE { get; set; }
        public string TDC_DESCRIPCION { get; set; }
        public string DCA_OBLIGATORIO { get; set; }
        public int DCA_ORDEN { get; set; }
    }
}
