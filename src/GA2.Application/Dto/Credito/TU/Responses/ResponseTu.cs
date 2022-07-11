namespace GA2.Application.Dto
{
    public class ResponseTu
    {
        public string idAplication { get; set; }
        public int codigoError { get; set; }
        public string detalleError { get; set; }
        public int codigoRechazo { get; set; }
        public string tipoRechazo { get; set; }
        public string detalleRechazo { get; set; }
        public string codigoOtp { get; set; }
        public string delayOtp { get; set; }
        public string decision { get; set; }
        public string score { get; set; }
        public decimal capacidadEndeudamiento { get; set; }
        public decimal porcentajeEndeudamiento { get; set; }
        public string historialCredito { get; set; }
        public string huellaConsulta { get; set; }
    }
}
