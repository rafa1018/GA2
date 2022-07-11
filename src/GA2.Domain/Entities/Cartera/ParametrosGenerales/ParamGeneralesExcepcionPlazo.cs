using System;

namespace GA2.Domain.Entities
{
    public class ParamGeneralesExcepcionPlazo
    {
        public int PLAZ_ID { get; set; }
        public int PLAZ_YEAR_MIN { get; set; }
        public int PLAZ_MONTH_MIN { get; set; }
        public int PLAZ_YEAR_MAX { get; set; }
        public int PLAZ_MONTH_MAX { get; set; }
        public DateTime PLAZ_FECHA_MODIFICACION { get; set; }
        public int PLAZ_MODIFICADO_POR { get; set; }
        public bool PLAZ_ESTADO { get; set; }
        public int TPA_ID { get; set; }
        public Guid ID_EXE_PLAZO { get; set; }
        public int TCR_ID { get; set; }
        public int UEJ_ID { get; set; }
        public int ID_EXC_PLAZO { get; set; }
        public string TPA_DESCRIPCION { get; set; }
        public string UEJ_NOMBRE { get; set; }
    }
}
