using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TasaSimuladorDto
    {
        public string IdSimulacion { get; set; }
        public string Descripcion { get; set; }
        public decimal TasaEA { get; set; }
        public int MinimoPlazoMeses { get; set; }
        public int MaximoPlazoMeses { get; set; }
        public string Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string EstadoParametro { get; set; }
        public string TipoParametroDescripcion { get; set; }
        public string TipoParametroId { get; set; }
        public string ParametroTasaEa { get; set; }
        public string ParametroId { get; set; }
    }
}
