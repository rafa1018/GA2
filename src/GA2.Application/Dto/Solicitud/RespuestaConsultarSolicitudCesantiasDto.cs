using System;

namespace GA2.Application.Dto
{
    public class RespuestaConsultarSolicitudCesantiasDto
    {
        public int NumeroSolicitud { get; set; }
        public string ProcesoDescripcion { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal ValorRetirar { get; set; } //SOL_VALOR_A_RETIRAR
        public string TareaNombre { get; set; }
        public string EstadoSolicitud { get; set; }
        public int IdCliente { get; set; }
    }
}
