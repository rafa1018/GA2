using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SimulacionDto
    {
        public Guid IdSimulacion { get; set; }
        public Guid IdDetalleSimulacion { get; set; }
        public Guid IdSimulacionCliente { get; set; }
        public int Cuota { get; set; }
        public DateTime FechaCorte { get; set; }
        public DateTime FechaPago { get; set; }
        public double Saldo { get; set; }
        public double Capital { get; set; }
        public double Intereses { get; set; }
        public double SeguroVida { get; set; }
        public double SeguroHogar { get; set; }
        public double TotalCuota { get; set; }
        public double Subsidio { get; set; }
        public double AbonoExtra { get; set; }
        public decimal CuotaUnidadPagadora { get; set; }
        public double InteresesReduccion { get; set; }
        public double CuotaReduccion { get; set; }
        public double CobroFonvivienda { get; set; }
        public decimal SaldoLeasing { get; set; }
        public decimal InteresLeasing { get; set; }
        public decimal CapitalLeasing { get; set; }
        public decimal CuotaLeasing { get; set; }
        public decimal CuotaLeasingSubsidio { get; set; }
        public decimal InteresTradicionalSubsidio { get; set; }
        public decimal InteresLeasingSubsidio { get; set; }
        public decimal ValorPrestamo { get; set; }
        public decimal valorPrestamoLeasing { get; set; }
        public decimal SeguroVidaLeasing { get; set; }
        public decimal ValorTasa { get; set; }
        public string ViviendaVis { get; set; }
        public string DerechoCuota { get; set; }
        public string DerechoTasa { get; set; }
        public int MinimoMeses { get; set; }
        public int MaximoMeses { get; set; }
        public double ValorTasaNominal { get; set; }
        public double AbonoMensual { get; set; }
        public decimal VALOR_TASA_NOMINAL_F { get; set; }
        public double? ValorVivienda { get; set; }
        public double? TotalCuotaSinSeguros { get; set; }
        public decimal ValorDeudaRemanente { get; set; }
        public string Sobrante { get; set; }
        public int PlazoMeses { get; set; }
        public int PlazoAnos { get; set; }
        public decimal SaldoCapitalReducido { get; set; }
        public decimal CapitalPorPagar { get; set; }
        public decimal InteresesPorPagar { get; set; }
        public decimal AfectacionCuentaIndividual { get; set; }
        public int TcrId { get; set; }
        public decimal CapitalReducido { get; set; }
    }
}
