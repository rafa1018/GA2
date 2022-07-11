using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// lBusinessLogic de Parametrizacion 
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public interface IParametrizacionBusinessLogic
    {
        Task<Response<ParametrizacionSeguroDto>> ObtenerSeguro();
        Task<Response<ParametrizacionTasaDto>> ObtenerTasa();
        Task<Response<ParametrizacionPlazosDto>> ObtenerPlazo();
        Task<Response<IEnumerable<ParametrizacionLegalTasaDto>>> ObtenerLegalTasa();
        Task<Response<ParametrizacionLegalAlivioDto>> ObtenerLegalAlivio();
        Task<Response<ParametrizacionLegalGmfDto>> ObtenerLegalGmf(); 
        Task<Response<ParametrizacionLiquidacionDto>> ObtenerLiquidacion();
        Task<Response<ParametrizacionSeguroDto>> CrearSeguro(ParametrizacionSeguroDto parametrizacionseguroDto);
        Task<Response<ParametrizacionTasaDto>> CrearTasa(ParametrizacionTasaDto parametrizaciontasaDto);
        Task<Response<ParametrizacionPlazosDto>> CrearPlazo(ParametrizacionPlazosDto parametrizaciondeadlineDto);
        Task<Response<ParametrizacionLegalTasaDto>> CrearLegalTasa(ParametrizacionLegalTasaDto parametrizacionlegaltasaDto);
        Task<Response<ParametrizacionLegalAlivioDto>> CrearLegalAlivio(ParametrizacionLegalAlivioDto parametrizacionLegalalivioDto);
        Task<Response<ParametrizacionLegalGmfDto>> CrearLegalGmf(ParametrizacionLegalGmfDto parametrizacionLegalGmfDto);
        Task<Response<ParametrizacionLiquidacionDto>> CrearLiquidacion(ParametrizacionLiquidacionDto parametrizacionliquidacionDto);
        Task<Response<ParametrizacionLegalTasaDto>> ActualizarLegalTasa(ParametrizacionLegalTasaDto parametrizacionlegaltasaDto);
        Task<Response<ParametroTransaccionDto>> ActualizarParametroTransaccion(ParametroTransaccionDto parametrotransaccion);
        Task<Response<ParametrizacionLegalTasaDto>> EliminarLegalTasa(ParametrizacionLegalTasaDto parametrizacionlegaltasaDto);
        Task<Response<ParametroTransaccionDto>> CrearParametroTransaccion(ParametroTransaccionDto parametrotransaccion);
        Task<Response<IEnumerable<ParametroTransaccionDto>>> ObtenerParametrosTransaccion();
        Task<Response<IEnumerable<ParametrizacionArchivoModalidadDto>>> ObtenerParametrizacionArchivosModalidad(int tipoModalidadId);
        Task<Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>> ObtenerParametrizacionArchivosEntidadEducativa(string entidadId);
        
    }
}
