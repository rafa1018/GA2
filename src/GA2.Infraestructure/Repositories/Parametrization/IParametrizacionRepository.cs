using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// lRepository de parametrizacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/202</date>
    /// </summary>
    public interface IParametrizacionRepository
    {
        /// <summary>
        /// Metodo Obtener seguro
        /// </summary>
        /// <author>Edgar Andrés Riaño Suarez</author>
        /// <date>2/03/202</date>
        /// <returns>Lista de seguros</returns>
        Task<SeguroParametrizacion> ObtenerSeguro();
        /// <summary>
        /// Metodo Crear y Actualizar seguro mediante el Dto
        /// </summary>
        /// <author>Edgar Andrés Riaño Suarez</author>
        /// <date>2/03/202</date>
        /// <returns>Modelo Crear Seguro</returns>
        Task<SeguroParametrizacion> CrearSeguro(SeguroParametrizacion insuraceparametrizacion);
        /// <summary>
        /// Metodo Obtener Tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de tasas</returns>
        Task<TasaParametrizacion> ObtenerTasa();
        /// <summary>
        /// Metodo Crear y Actualizar Tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Tasa</returns>
        Task<TasaParametrizacion> CrearTasa(TasaParametrizacion rateparametrizacion);
        /// <summary>
        /// Metodo Obtener Plazo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de plazos</returns>
        Task<PlazoParametrizacion> ObtenerPlazo();
        /// <summary>
        /// Metodo Crear y Actualizar Plazo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Plazos</returns>
        Task<PlazoParametrizacion> CrearPlazo(PlazoParametrizacion deadlineparametrizacion);
        /// <summary>
        /// Metodo Obtener Legal Tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Legal Tasa</returns>
        Task<IEnumerable<LegalTasaParametrizacion>> ObtenerLegalTasa();
        /// <summary>
        /// Metodo Crear Legal Tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Legal Tasa</returns>
        Task<LegalTasaParametrizacion> CrearLegalTasa(LegalTasaParametrizacion legaltasaparametrizacion);
        /// <summary>
        /// Metodo Actualizar Legal Tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Actualizar Legal Tasa</returns>
        Task<LegalTasaParametrizacion> ActualizarLegalTasa(LegalTasaParametrizacion legalTasaparametrizacion);
        /// <summary>
        /// Metodo Eliminar Legal Tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Eliminar Legal Tasa</returns>
        Task<LegalTasaParametrizacion> EliminarLegalTasa(LegalTasaParametrizacion legalTasaparametrizacion);
        /// <summary>
        /// Metodo Obtener Legal Alivio
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Legal Alivio</returns>
        Task<LegalAlivioParametrizacion> ObtenerLegalAlivio();
        /// <summary>
        /// Metodo Crear y Actualizar Legal Alivio mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Legal Alivio</returns>
        Task<LegalAlivioParametrizacion> CrearLegalAlivio(LegalAlivioParametrizacion legalalivioparametrizacion);
        /// <summary>
        /// Metodo Obtener Legal GMF
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Legal GMF</returns>
        Task<LegalGmfParametrizacion> ObtenerLegalGmf();
        /// <summary>
        /// Metodo Crear y Actualizar Legal GMF mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Legal GMF</returns>
        Task<LegalGmfParametrizacion> CrearLegalGmf(LegalGmfParametrizacion legalgmfparametrizacion);
        /// <summary>
        /// Metodo Obtener Parametrizacion de Liquidacion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Liquidacion</returns>
        Task<LiquidacionParametrizacion> ObtenerLiquidacion();
        /// <summary>
        /// Metodo Crear y Actualizar Parametrizacion de Liquidacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Liquidacion</returns>
        Task<LiquidacionParametrizacion> CrearLiquidacion(LiquidacionParametrizacion settlementparametrizacion);
        Task<IEnumerable<ParametroTransaccion>> ObtenerParametrosTransaccion();
        Task<ParametroTransaccion> ActualizarParametroTransaccion(ParametroTransaccion parametrotransaccion);
        Task<ParametroTransaccion> CrearParametroTransaccion(ParametroTransaccion parametrotransaccion);

        /// <summary>
        /// Metodo para obtener los archivos parametrizados por modalidad
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>14/10/2021</date>
        /// <returns>Lista de archivos parametrizados</returns>
        Task<IEnumerable<ParametrizacionArchivoModalidad>> ObtenerParametrizacionArchivosModalidad(int tipoModalidadId);

        /// <summary>
        /// Metodo para obtener los archivos parametrizados por entidad
        /// </summary>
        /// <author> Edwin Lopez </author>
        /// <date>29/03/2022</date>
        /// <param name="entidadId"></param>
        /// <returns></returns>
        Task<IEnumerable<ParametrizacionArchivoEntidadEducativa>> ObtenerParametrizacionArchivosEntidadEducativa(string entidadId);
    }
}
