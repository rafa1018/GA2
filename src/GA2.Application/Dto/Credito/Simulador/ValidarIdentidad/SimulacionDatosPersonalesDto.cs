using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Simulacion Datos Personales
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class SimulacionDatosPersonalesDto
    {
        public Guid Id { get; set; }
        public Guid IdSimulacion { get; set; }
        public int FrzId { get; set; }
        public int CrgId { get; set; }
        public int GrdId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombresApellidos { get; set; }
        public int Edad { get; set; }
        public DateTime? FechaAfiliacion { get; set; }
        public int DpdId { get; set; }
        public int DpcId { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public string EMail { get; set; }
        public int Cuotas { get; set; }
        public string Regimen { get; set; }
        public float ValorInmueble { get; set; }
        public int TvvId { get; set; }
        public int DpdIdInmueble { get; set; }
        public int DpcIdInmueble { get; set; }
        public Guid? UsuarioActualiza { get; set; }
        public DateTime? FechaActualiza { get; set; }
        public string DepartamentoResidencia { get; set; }
        public string CiudadResidencia { get; set; }
        public string DepartamentoInmueble { get; set; }
        public string CiudadInmueble { get; set; }
        public string Fuerza { get; set; }
        public string Categoria { get; set; }
        public string Grado { get; set; }
        public string TipoVivienda { get; set; }
        public string TipoAfiliado { get; set; }
        public int TipoAfiliadoId { get; set; }
        public string UnidadEjecutora { get; set; }
        public int UejId { get; set; }
        public int TpaId { get; set; }
    }
}
