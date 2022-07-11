using System;
namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Validacion Identidad
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class ValidacionIdentidadDto
    {
        public Guid Id { get; set; }
        public int TidId { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroCelular { get; set; }
        public int AceptaHabeas { get; set; }
        public int AceptaTerminos { get; set; }
        public DateTime FechaValidaIdentidad { get; set; }
        public DateTime FechaValidaOtp { get; set; }
        public string IdAplicacion { get; set; }
        public string CodigoOtp { get; set; }
        public string Delay { get; set; }
        public int PasoValidacion { get; set; }
        public string UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
        /// <summary>
        /// Propiedades auxiliar ingreso codigo OTP, provisional en pruebas para el envio del codigo OTP del front
        /// </summary>
        public string CodigoOtpIngresado { get; set; }


        /// <summary>
        /// Las propiedades representadas hacia abajo no realizan ningun Mapper, ya que son solo variables auxiliares para el modelo
        /// para enviar al FrontEnd
        /// Propiedades auxiliares de logica de negocio para la clase ValidacionIdentidadDto
        /// </summary>
        /// <author>John Byron Aguelo Gonzalez</author>
        /// <date>05/05/2021</date>
        public int idError { get; set; }
        public string DescripcionError { get; set; }
        public int IdPantalla { get; set; }

        /// <summary>
        /// Propiedades auxiliares de la SimulacionSolicitudDto para la clase ValidacionIdentidadDto
        /// </summary>
        /// <author>John Byron Aguelo Gonzalez</author>
        /// <date>05/05/2021</date>
        public Guid IdSolicitud { get; set; }
        public int TcrId { get; set; }
        public Int64 NumeroPreaprobado { get; set; }
        public string RutaPdfResumen { get; set; }
        public string ValorPrestamo { get; set; }
        public string ValorVivienda { get; set; }
        public string TipoVivienda { get; set; }
        public string ViviendaVis { get; set; }



        /// <summary>
        /// Propiedades auxiliares de la clase SocSolicitudCredito para la clase ValidacionIdentidadDto
        /// </summary>
        /// <author>John Byron Aguelo Gonzalez</author>
        /// <date>05/05/2021</date>
        public Guid SocId { get; set; }
    }
}
