using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class DocumentosActRespuesta
    {
        [Key]
        public string TDC_ID { get; set; }
        public int ID_ACTIVIDAD_FLUJO { get; set; }
        public string ACTIVIDAD { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string RUTA_IMAGEN { get; set; }
    }
}
