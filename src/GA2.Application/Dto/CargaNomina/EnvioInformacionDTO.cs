using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO listas de envio de info carga nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class EnvioInformacionDTO
    {
        public DocumentoDto DOCUMENTO { get; set; }
        public IEnumerable<MovimientoDTO> MOVIMIENTOS { get; set; }
        public IEnumerable<CuentaDto> CUENTAS { get; set; }
        public IEnumerable<AportesClienteDto> APORTESCLIENTES { get; set; }
        public NombreArchivoDto FILENAME { get; set; }
    }
}
