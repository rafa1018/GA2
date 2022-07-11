using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class InformacionCreditoDto
    {
        public Guid IdCredito { get; set; }
        public int NumeroCredito { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public decimal ValorDesembolso { get; set; }
        public decimal ValorCuota { get; set; }
        public int PlazoTotal { get; set; }
        public int IdTipoCredito { get; set; }
        public int DiaPago { get; set; }
        public int IdEstadoCartera { get; set; }
        public DateTime FechaEstado { get; set; }
        public int DiasMora { get; set; }
        public decimal ValorVivienda { get; set; }
        public int IdTipoVivienda { get; set; }
        public int IdEstadoVivienda { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoCapitalMora { get; set; }
        public int PlazoActual { get; set; }
        public float TasaSeguroVida { get; set; }
        public float TasaSeguroHogar { get; set; }
        public float TasaCreditoEfectivaAnual { get; set; }
        public float TasaCreditoPer { get; set; }
        public float TasaFrech { get; set; }
        public decimal ValorAlivioCuota { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        public DateTime FechaProximoPago { get; set; }
        public int TipoAbonoExtra { get; set; }
        public decimal ValorAbonoExtra { get; set; }
        public decimal ValorDeudaRemanente { get; set; }
        public decimal ValorCanonInicial { get; set; }
        public decimal CanonExtraordinario { get; set; }
        public decimal ValorOpcionCompra { get; set; }
        public float PorcentajeCanonInicial { get; set; }
        public float PorcentajePorOpcionCompra { get; set; }
        public decimal AcumuladoInteresMora { get; set; }
        public DateTime FechaUltimoPagoInteresMora { get; set; }
        public decimal AcumuladoInteresCorriente { get; set; }
        public DateTime FechaUltimoPagoInteresCorriente { get; set; }
        public decimal AcumuladoSeguroHogar { get; set; }
        public DateTime FechaUltimoPagoSeguroHogar { get; set; }
        public decimal AcumuladoSeguroVida { get; set; }
        public DateTime FechaUltimoPagoSeguroVida { get; set; }
        public bool AlivioFrech { get; set; }
        public int NumeroCuotasCanceladas { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
