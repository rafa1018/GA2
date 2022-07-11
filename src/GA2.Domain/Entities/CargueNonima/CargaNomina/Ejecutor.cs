using System;

namespace GA2.Domain.Entities
{
    public class Ejecutor
    {
        public int FILE_UNIDAD_EJECUTORA { get; set; }
        public string FILE_TIPO { get; set; }
        public string FILE_CATEGORIA { get; set; }
        public int FILE_PERIODOS_APORTES { get; set; }
        public Guid DCT_ID { get; set; }
        public DateTime DCT_FECHA_INCIAL { get; set; }
    }
}
