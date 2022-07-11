using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Juzgado Dto
    /// </summary>
    public class JuzgadosDto
    {
        public string IdJuzgado { get; set; }
        public string CodigoInterno { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public string NroCuenta { get; set; }
        public string CodigoOficina { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }
        public string? Contacto { get; set; }
        public int codigoCiudad { get; set; }
        public bool Estado { get; set; }
    }


    public class JuzgadosGuidDto
    {
        public Guid IdJuzgado { get; set; }
        public string CodigoInterno { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public string NroCuenta { get; set; }
        public string CodigoOficina { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }
        public string? Contacto { get; set; }
        public int codigoCiudad { get; set; }
        public bool Estado { get; set; }
    }
}
