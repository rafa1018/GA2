using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class PlanillaSimulacionCreditoDto
    {
        [Key]
        public Guid SMD_ID { get; set; }
        public Guid SMC_ID { get; set; }
        public int cuota { get; set; }
        public DateTime fechaCorte { get; set; }
        public DateTime fechaPago { get; set; }
        public decimal saldo { get; set; }
        public decimal intereses { get; set; }
        public decimal capital { get; set; }
        public decimal seguroVida { get; set; }
        public decimal seguroTerremoto { get; set; }
        public decimal cuotaTotal { get; set; }
        public decimal abonoExtra { get; set; }
        public decimal abonoMensual { get; set; }
        public decimal cuotaUnidadPagadora { get; set; }
        public decimal interesesReduccion { get; set; }
        public decimal cuotaReduccion { get; set; }
        public decimal cobroFonvivienda { get; set; }
        public decimal smlv { get; set; }
        public decimal inflacion { get; set; }
        public decimal incrementoAnual { get; set; }
        public decimal financiaVIS { get; set; }
        public decimal salarioMinVIS { get; set; }
        public decimal FinanciaNoVIS { get; set; }
        public decimal porcSeguroTerremoto { get; set; }
        public int diasDesembolso { get; set; }
        public int mesesLeyFrech { get; set; }
        public int mesesLeyAliv { get; set; }
        public int mesSubsidioSol { get; set; }
        public int mesSubsidioOtro { get; set; }
        public decimal tasaEA { get; set; }
        public int diasValidoPreaprobado { get; set; }
        public int minimoMesesPlazo { get; set; }
        public int maximoMesesPlazo { get; set; }
        public string estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid modificadoPor { get; set; }
        public DateTime fechaModificacion { get; set; }
        public decimal canonIniLSG { get; set; }
        public decimal canonFinLSG { get; set; }
        public decimal opcionCompraLSG { get; set; }
        public string factorAhorro { get; set; }
        public string factorCesantias { get; set; }
        public decimal valorPrestamo { get; set; }
        public decimal valorTasa { get; set; }
        public string viviendaVis { get; set; }
        public string derechoCuota { get; set; }
        public string derechoTasa { get; set; }
        public Guid idSimulacion { get; set; }
        public int minimoMeses { get; set; }
        public int maximoMeses { get; set; }
        public decimal valorTasaNominal { get; set; }
        public decimal valorTasaNominalF { get; set; }
    }
}
