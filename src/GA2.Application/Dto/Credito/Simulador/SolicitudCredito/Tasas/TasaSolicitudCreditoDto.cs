using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TasaSolicitudCreditoDto
    {
        public Guid idSolicitudCredito { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public int numeroSolicitud { get; set; }
        public int tipoCredito { get; set; }
        public int idDepartamento { get; set; }
        public int idCiudad { get; set; }
        public Guid idSLS { get; set; }
        public int tipoIdentificacion { get; set; }
        public string identificacion { get; set; }
        public string declaracionOrigenFondos { get; set; }
        public string autorizaUsoDatos { get; set; }
        public string autorizaConsultaCentrales { get; set; }
        public string declaracionAsegurabilidad { get; set; }
        public string convenioAseguradora { get; set; }
        public string convenioAseguradoraHogar { get; set; }
        public int idAseguradora { get; set; }
        public string desicionBuro { get; set; }
        public int score { get; set; }
        public decimal capacidadEndeudamiento { get; set; }
        public decimal nivelEndeudamiento { get; set; }
        public decimal nivelEndeudamientoCuota { get; set; }
        public decimal porcentajeExtraprima { get; set; }
        public decimal valorReconocimientoCredito { get; set; }
        public string observacionRecomendacion { get; set; }
        public double tasaFrech { get; set; }
        public decimal valorAlivio { get; set; }
        public string estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualizacion { get; set; }
    }
}
