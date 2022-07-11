using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TipoCuentaCDto
    {
        public int IdTipoCuentaC { get; set; }
        public string DescripcionTipoCuentaC { get; set; }
        public string PrefijoCuentaC { get; set; }
        public string TipoGeneralCuentaC { get; set; }
        public bool AplicanInteresesCuentaC { get; set; }
        public bool AplicanRendimientosCuentaC { get; set; }
        public bool AplicanCuotasCuentaC { get; set; }
        public bool ActivaCuentaC { get; set; }
        public string CentroCostoCuenta { get; set; }

    }
}
