using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class InformacionConyugueDto
    {


        public Guid Id { get; set; }
        public Guid SolicitudId { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public int DepartamentoExpedicionId { get; set; }
        public int CiudadExpedicionId { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int DepartamentoNacimientoId { get; set; }
        public int CiudadNacimientoId { get; set; }
        public string Celular { get; set; }
        public string CorreoPersonal { get; set; }
        public string ActividadLaboral { get; set; }
        public string OtraActividad { get; set; }
        public string EmpresaLabora { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }


    }
}
