using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ProductoClienteDto
    {
        public Guid IdCredito { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public decimal ValorDesembolso { get; set; }
        public decimal ValorCuota { get; set; }
        public int PlazoTotal { get; set; }
        public int IdTipoCredito { get; set; }
        public int DiaPago { get; set; }
        public int IdEstadoCredito { get; set; }
        public DateTime FechaEstadoCredito { get; set; }
        public int DiasMora { get; set; }
        public decimal ValorVivienda { get; set; }
        public int IdEstadoVivienda { get; set; }
        public int IdTipoVivienda { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoCapitalMora { get; set; }
        public int PlazoActual { get; set; }
        public decimal TasaSeguroVida { get; set; }
        public decimal TasaSeguroHogar { get; set; }
        public decimal TasaCreditoEA { get; set; }
        public decimal TasaCreditoPer { get; set; }
        public decimal TasaFrech { get; set; }
        public decimal ValorAlivioCuota { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        public DateTime FechaProximoPago { get; set; }
        public string TipoAbonoExtra { get; set; }
        public decimal ValorAbonoExtra { get; set; }
        public decimal ValorDeudaRemanente { get; set; }
        public decimal ValorCanonInicial { get; set; }
        public decimal ValorOpcionCompra { get; set; }
        public decimal PorcentajeCanonInicial { get; set; }
        public decimal PorcentajeOpcionCompra { get; set; }
        public decimal AcumuladoInteresMora { get; set; }
        public decimal CanonExtraordinario { get; set; }
        public DateTime UltimoPagoInteresMora { get; set; }
        public decimal AcumuladoInteresCorriente { get; set; }
        public DateTime UltimoPagoInteresCorriente { get; set; }
        public decimal AcumuladoSeguroHogar { get; set; }
        public DateTime UltimoPagoSeguroHogar { get; set; }
        public decimal AcumuladoSeguroVida { get; set; }
        public DateTime UltimoPagoSeguroVida { get; set; }
        public decimal AlivioFrech { get; set; }
        public int NumeroCuotasCanceladas { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int NumeroCredito { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Categoria { get; set; }
        public string Grado { get; set; }
        public string DireccionInmueble { get; set; }
        public string CiudadInmueble { get; set; }
        public string NoMatricula { get; set; }
        public string Escritura { get; set; }
        public DateTime FechaEscritura { get; set; }
        public string Notaria { get; set; }
        public string Linderos { get; set; }
        public string DescripcionInmueble { get; set; }
        public int Score { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaFinPagos { get; set; }

        public string TipoVivienda { get; set; }
        public string ClaseInmueble { get; set; }
        public string EstadoCredito { get; set; }
    }
}