using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicCreditoRecomendacionDto
    {
        [Key]
        public Guid idSolicitudCredito { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public int numeroSolicitud { get; set; }
        public int idTipoCredito { get; set; }
        public int idDepartamento { get; set; }
        public int idCiudad { get; set; }
        public Guid SLS_ID { get; set; }
        public int idTipoDocumento { get; set; }
        public string identificacion { get; set; }
        public string declaracionOrigenFondos { get; set; }
        public string autorizaUsoDatos { get; set; }
        public string autorizaConsultaCentrales { get; set; }
        public string declaracionAsegurabilidad { get; set; }
        public string convenioAseguradora { get; set; }
        public string convenioAseguradoraHogar { get; set; }
        public int idAseguradora { get; set; }
        public string decisionBuro { get; set; }
        public string score { get; set; }
        public string capacidadEndeudamiento { get; set; }
        public string nivelEndeudamiento { get; set; }
        public string nivelEndeudamientoCuota { get; set; }
        public decimal porcentajeExtraprima { get; set; }
        public decimal valorRecomendadoCredito { get; set; }
        public string observacionRecomendacion { get; set; }
        public string estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualiza { get; set; }
        public string tipoAlivio { get; set; }
    }
}
