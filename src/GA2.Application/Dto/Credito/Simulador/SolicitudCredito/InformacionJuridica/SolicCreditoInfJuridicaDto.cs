using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicCreditoInfJuridicaDto
    {
        [Key]
        public Guid idSolicitudInformacionJuridica { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public string linderos { get; set; }
        public string tipoParqueadero { get; set; }
        public string edadJuridica { get; set; }
        public DateTime fechaPrimerActo { get; set; }
        public string tradicionInmueble { get; set; }
        public string analisisUlt20Años { get; set; }
        public string analisisSitJuridica { get; set; }
        public string analisisRegPropHorizontal { get; set; }
        public string analisisPazySalvo { get; set; }
        public string analisisVendedor { get; set; }
        public string viabilidadJurNegocio { get; set; }
        public string recomendaciones { get; set; }
        public string conceptoJuridicoFin { get; set; }
        public string conceptoEstJuridicio { get; set; }
        public string direccion { get; set; }
        public int codigoDepartamento { get; set; }
        public int codigoCiudad { get; set; }
        public string nombreAliado { get; set; }
        public string departamento { get; set; }
        public string ciudad { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public IEnumerable<SolicCreditoInfJurInmDto> solicitudesCreditoInfoJurInmueble { get; set; }
    }
}
