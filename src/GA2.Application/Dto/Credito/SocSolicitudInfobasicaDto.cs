using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SocSolicitudInfobasicaDto
    {

        public Guid SobId { get; set; }
        public Guid SolicitudCreditoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicionDocumento { get; set; }
        public int DepartamentoExpedicionId { get; set; }
        public int CiudadExpedicionId { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int DepartamentoNacimientoId { get; set; }
        public int CiudadNacimientoId { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string NivelEducacion { get; set; }
        public int FuerzaId { get; set; }
        public int CategoriaId { get; set; }
        public int GradoId { get; set; }
        public int DepartamentoResidenciaId { get; set; }
        public int CiudadResidenciaId { get; set; }
        public string DireccionResidencia { get; set; }
        public string CorreoPersonal { get; set; }
        public string TelefonoResidencia { get; set; }
        public string Celular { get; set; }
        public int DepartamentoOficinaId { get; set; }
        public int CiudadOficinaId { get; set; }
        public string DireccionOficina { get; set; }
        public string CorreoInstitucional { get; set; }
        public string TelefonoOficina { get; set; }
        public int ActividadEconomicaId { get; set; }
        public int ProfesionId { get; set; }
        public string  TieneTrasaccionesMe { get; set; }
        public string TipoTransaccionMe { get; set; }
        public string TipoProductoMe { get; set; }
        public string BancoTransaccionMe { get; set; }
        public string NumeroProductoMe { get; set; }
        public decimal SaldoPromedioCuentasMe { get; set; }
        public string MonedaTransaccionMe { get; set; }
        public int DepartamentoTaransaccionMeId { get; set; }
   
        public Guid CreadoPorId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPorId { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
