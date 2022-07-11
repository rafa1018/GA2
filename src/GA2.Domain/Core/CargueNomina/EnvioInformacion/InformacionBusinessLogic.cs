using GA2.Application.Dto;
using GA2.Domain.Core.CargueNomina;
using System.Collections.Generic;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Logica de negocio para descomponer los componentes en listas y poder ser enviados a la bd
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class InformacionBusinessLogic
    {
        /// <summary>
        /// Metodo que organiza la informacion
        /// </summary>
        /// <param name="componentes"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public static EnvioInformacionDTO OrganizarInformacion(ComponentesDTO componentes)
        {
            DocumentoDto documento = componentes.DOCUMENTO;
            List<MovimientoDTO> movimientos = MovimientoEstructuracion.EstructurarMovimiento(componentes);
            List<CuentaDto> cuentas = CuentaEstructuracion.EstructurarCuenta(componentes);
            List<AportesClienteDto> aportes = AportesClientesEstructuracion.EstructurarAportes(cuentas);
            NombreArchivoDto filename = componentes.FILENAME;
            return new EnvioInformacionDTO() { DOCUMENTO = documento, MOVIMIENTOS = movimientos, CUENTAS = cuentas, APORTESCLIENTES = aportes, FILENAME = filename };
        }
    }
}
