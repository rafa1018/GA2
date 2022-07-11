using System;

namespace GA2.Application.Dto
{
    public class ClienteCedulaDto
    {
        #region Cliente
        public int IdCliente { get; set; }
        public int IdTipoActor { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaExpedicionDocumento { get; set; }
        public int IdDepartamentoExpedicionDocumento { get; set; }
        public int IdCiudadExpedicionDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdDepartamentoNacimiento { get; set; }
        public int IdCiudadNacimiento { get; set; }
        public string Sexo { get; set; }
        public string unidadCliente { get; set; }
        public string EstadoCivil { get; set; }
        public int IdProfesion { get; set; }
        public int IdCategoria { get; set; }
        public int IdFuerza { get; set; }
        public int IdGrado { get; set; }
        #endregion
    }
}
