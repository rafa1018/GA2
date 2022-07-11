using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SimulacionClienteDto
    {
        [Key]
        public string numeroDocumento { get; set; }
        public string numeroPreaprobado { get; set; }
        public string smcTipoVivienda { get; set; }
        public decimal valorVivienda { get; set; }
        public decimal valorPrestamo { get; set; }
        public string tipoAlivio { get; set; }
        public string smcTipoAbono { get; set; }
        public decimal valorTasaEA { get; set; }
        public decimal valorTasaMV { get; set; }
        public decimal valorTasaMVFresh { get; set; }
        public string viviendaVIS { get; set; }
        public int valorCuota { get; set; }
        public int valorCuotaSinSeg { get; set; }
        public int plazo { get; set; }
        public DateTime fechaSimulacion { get; set; }
        public DateTime fechaAprobacion { get; set; }
        public string nombreCliente { get; set; }
        public string departamento { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string correoElectronico { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoCelular { get; set; }
        public string fuerza { get; set; }
        public string regimen { get; set; }
        public string categoria { get; set; }
        public string grado { get; set; }
        public int tipoCredito { get; set; }
        public int años { get; set; }
        public string tipoAbono { get; set; }
        public string tipoVivienda { get; set; }
    }
}
