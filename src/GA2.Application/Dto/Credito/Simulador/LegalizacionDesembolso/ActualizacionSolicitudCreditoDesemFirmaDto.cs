using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ActualizacionSolicitudCreditoDesemFirmaDto
    {
        public Guid IdSolicitudCredito { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int NumeroSolicitud { get; set; }
        public int IdTipoCredito { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCiudad { get; set; }
        public Guid IdSls { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string DeclaracionOrigenFondos { get; set; }
        public string AutorizaUsoDatos { get; set; }
        public string AutorizaConsultaCentrales { get; set; }
        public string DeclaracionAsegurabilidad { get; set; }
        public string ConvenioAseguradora { get; set; }
        public string ConvenioAseguradoraHogar { get; set; }
        public int IdAseguradora { get; set; }
        public int IdAseguradoraHogar { get; set; }
        public Guid DecisionBuro { get; set; }
        public int Score { get; set; }
        public decimal CapacidadEndeudamiento { get; set; }
        public decimal NivelEndeudamiento { get; set; }
        public decimal NivelEndeudamientoCuota { get; set; }
        public decimal PorcentajeExtraprima { get; set; }
        public decimal ValorRecomendadoCredito { get; set; }
        public string ObservacionRecomendacion { get; set; }
        public decimal TasaFrech { get; set; }
        public decimal ValorAlivio { get; set; }
        public Guid Reparto { get; set; }
        public int IdNotaria { get; set; }
        public DateTime FechaReparto { get; set; }
        public string FinalizaReparto { get; set; }
        public DateTime FechaFinalizaReparto { get; set; }
        public string TipoAlivio { get; set; }
        public string ValidaDesembolso { get; set; }
        public string ObservacionValidaDesembolso { get; set; }
        public Guid UsuarioValidaDesembolso { get; set; }
        public DateTime FechaValidaDesembolso { get; set; }
        public string ValidaFirmas { get; set; }
        public string ObservacionValidaFirmas { get; set; }
        public Guid UsuarioValidaFirmas { get; set; }
        public DateTime FechaValidaFirmas { get; set; }
        public string Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
