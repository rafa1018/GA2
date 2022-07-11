using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad documento de cargue de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public class Documento
    {
        public int DCT_ID { get; set; }
        public int TDC_ID { get; set; }
        public string DCT_NOMBRE { get; set; }
        public DateTime DCT_FECHA_INICIAL { get; set; }
        public int ESD_ID { get; set; }
        public int CED_ID { get; set; } //Causal estado documento
        public int UEJ_ID { get; set; } //Unidad ejecutora
        public DateTime DCT_FECHA_FINAL { get; set; }
        public int DCT_ID_ANULA { get; set; }
        public string DCT_ALERTA { get; set; }
        public Guid DCT_CREADOPOR { get; set; }
        public DateTime DCT_FECHACREACION { get; set; }
        public DateTime DCT_FECHAMODIFICACION { get; set; }
        public Guid DCT_MODIFICADOPOR { get; set; }
    }
}
