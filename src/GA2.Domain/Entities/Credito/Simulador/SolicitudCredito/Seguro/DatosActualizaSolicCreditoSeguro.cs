using System;

namespace GA2.Domain.Entities
{
    public class DatosActualizaSolicCreditoSeguro
    {
        public Guid SOC_ID { get; set; }
        public string SOC_CONVENIO_ASEGURADORA { get; set; }
        public string SOC_CONVENIO_ASEGURADORA_HOGAR { get; set; }
        public string ASE_ID { get; set; }
        public string ASE_ID_HOGAR { get; set; }
        public decimal SOC_PORC_EXTRAPRIMA { get; set; }
        public Guid SOC_ACTUALIZADO_POR { get; set; }
        public DateTime SOC_FECHA_ACTUALIZA { get; set; }
    }
}
