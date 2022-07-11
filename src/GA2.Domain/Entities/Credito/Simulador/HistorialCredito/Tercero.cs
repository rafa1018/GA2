using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Tercero
    {
        public Endeudamiento Endeudamiento { get; set; }
        public SectorFinancieroExtinguidas SectorFinancieroExtinguidas { get; set; }
        public SectorFinancieroAlDia SectorFinancieroAlDia { get; set; }
        public CuentasVigentes CuentasVigentes { get; set; }
        public Consolidado Consolidado { get; set; }
        public string RespuestaConsulta { get; set; }
        public string Entidad { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoCiiu { get; set; }
        public string RangoEdad { get; set; }
        public string EstadoTitular { get; set; }
        public string NumeroInforme { get; set; }
        public string Estado { get; set; }
        public string FechaExpedicion { get; set; }
        public string LugarExpedicion { get; set; }
        public string NombreCiiu { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CodigoTipoIndentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string IdentificadorLinea { get; set; }
    }
}
