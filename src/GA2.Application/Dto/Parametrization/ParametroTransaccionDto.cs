using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// ParametroTrasaccionDto GA2
    /// </summary>
    public class ParametroTransaccionDto
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public int Codigo { get; set; }
        public string Proceso { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
