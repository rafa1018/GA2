using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Entidad Prod. ObtenerDatosRepartoDto
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>22/06/2021</date>
    public class DatosRepartoDto
    {
        public Guid IdSolicitud { get; set; }
        public DateTime FechaReparto { get; set; }
        public string Compania { get; set; }
        public string NitCompania { get; set; }
        public string NaturalezaCompania { get; set; }
        public string Notaria { get; set; }
        public string CiudadNotaria { get; set; }
        public string Acto { get; set; }
        public int ValorVenta { get; set; }
        public string DireccionInmueble { get; set; }
        public string Matriculas { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DocumentoVendedor { get; set; }
        public string NombreVendedor { get; set; }
    }
}
