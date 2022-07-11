using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Propiedades Dto de Documento Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class DocumentoActividadDto

    {
        public int Id { get; set; }
        public int AflId { get; set; }
        public int TdcId { get; set; }
        public int Orden { get; set; }
        public char Obligatorio { get; set; }
        public char Cargar { get; set; }
        public char Visualiza { get; set; }
        public char VisualizaCliente { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
