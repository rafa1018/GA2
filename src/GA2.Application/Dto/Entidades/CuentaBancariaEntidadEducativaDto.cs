using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Entidad Educativa Dto
    /// </summary>
    public class CuentaBancariaEntidadEducativaDto
    {
        public Guid IdCuentaBancaria { get; set; }
        public Guid IdEntidad { get; set; }
        public Guid IdEntidadBancaria { get; set; }
        public string RazonSocialEntidad { get; set; }
        public string NumeroCuenta { get; set; }
        public bool Estado { get; set; }

    }
}
