using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DesembargoDto
    {
        public Guid Id { get; set; }
        public Guid EmbargoCuentaConceptoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }

    public class ObtenerDesembargoDto 
    {

        public Guid Id { get; set; }
        public string RadicadoWorkManager { get; set; }
        public string RadicadoJuzgado { get; set; }
        public string NombreDemandante { get; set; }
        public string NombreDemandado { get; set; }
        public string ExpedienteBancoAgrario { get; set; }
        public string Cliente { get; set; }
        public int ClienteId { get; set; }
        public string Juzgado { get; set; }
        public string TipoProceso { get; set; }
        public string TipoEmbargo { get; set; }
        public int Valor { get; set; }

        public int CuentaId { get; set; }
        public int Cuenta { get; set; }
        public string TipoRetencion { get; set; }

    }
}
