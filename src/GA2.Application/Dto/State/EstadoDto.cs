using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion legal tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class EstadoDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Concepto { get; set; }
        public string DiasMoraActivaEstado { get; set; }
        public string SaldoDeuda { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}