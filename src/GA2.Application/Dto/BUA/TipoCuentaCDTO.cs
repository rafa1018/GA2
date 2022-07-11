using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.BUA
{
    public class TipoCuentaCDTO
    {
        public int TipoCuentaId { get; set; }
        public string TpDescripcion { get; set; }
        public string TpPrefijo { get; set; }
        public string TipoGeneralCuenta { get; set; }
        public bool AplicanIntereses { get; set; }
        public bool AplicanRedimientos { get; set; }
        public bool AplicanCuotas { get; set; }
        public bool Activa { get; set; }
        public string CentroCostos { get; set; }
    }
}
