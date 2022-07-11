using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DatosProspeccionDto
    {
        public int IdDatosProspeccion { get; set; }
        public Guid IdSimulacionPersonales { get; set; }
        public int IdEstrato { get; set; }
        public int IdNivelAcademico { get; set; }
        public int IdViviendaPropia { get; set; }
        public int IdTipoContrato { get; set; }
        public int IdPersonasACargo { get; set; }
        public decimal TotalActivos { get; set; }
        public decimal TotalPasivos { get; set; }
        public string DesicionHomologadaTU { get; set; }
        public decimal RiegoCredito { get; set; }
        public decimal CapacidadPagoLibranza { get; set; }
        public bool Viabilidad { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoIdentificacion { get; set; }
        public int Antiguedad { get; set; }
        public string FormaPago { get; set; }
        public string Garantia { get; set; }
        public string FormaPagoId { get; set; }
        public string GarantiaId { get; set; }
    }
}
