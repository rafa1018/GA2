using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Propiedades Dto de Flujo Tipo Credito
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class FlujoTipoCreditoDto
    {
        public int Id { get; set; }
        public int FluId { get; set; }
        public int TcrId { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
