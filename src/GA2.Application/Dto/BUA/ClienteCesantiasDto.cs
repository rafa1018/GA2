using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Cliente Cesantias
    /// <author>Erwin Pantoja España</author>
	/// <date>07/10/2021</date>
    /// </summary>
    public class ClienteCesantiasDto
    {
        #region Cliente
        public int IdCliente { get; set; }
        public int IdTipoActor { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoPersonal { get; set; }
        public string NumeroCelular { get; set; }
        public string TelefonoResidencia { get; set; }
        public string Direccion { get; set; }
        public List<SaldoDto> Saldos { get; set; }
        #endregion
    }
}
