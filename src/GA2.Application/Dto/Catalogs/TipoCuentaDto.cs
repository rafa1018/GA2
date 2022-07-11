using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TipoCuentaDto
    {
        public int idTipoCuenta { get; set; }
        public string descripcionTipoCuenta { get; set; }
        public string prefijoTipoCuenta { get; set; }
        public string categoriaTipoCuenta { get; set; }
        public bool aplicaInteres { get; set; }
        public bool aplicaRendimientos { get; set; }
        public bool aplicaCuotas { get; set; }
        public bool activo { get; set; }
        public string centroCostoTipoCuenta { get; set; }
    }
}
