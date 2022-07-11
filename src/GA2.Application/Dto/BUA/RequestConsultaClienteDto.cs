
namespace GA2.Application.Dto
{
    public class RequestConsultaClienteDto
    {
        public int tipoDocumentoId { get; set; }
        public string numeroDocumento { get; set; }
        public int idCliente { get; set; }
    }

    public class ConsultaClienteDto
    {
        public int tipoDocumentoId { get; set; }
        public string numeroDocumento { get; set; }
     
    }
}
