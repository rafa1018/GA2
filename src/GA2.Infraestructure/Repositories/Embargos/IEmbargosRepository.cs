using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IEmbargosRepository
    {

        #region Juzgados


        Task<JuzgadosGuid> ObtenerJuzgadoById(Guid id);
        Task<Juzgados> ActualizarJuzgado(Juzgados Juzgado);
        Task<Juzgados> CrearJuzgado(Juzgados Juzgado);
        Task<Juzgados> EliminarJuzgadoPorId(string idJuzgado);
        Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorCiudad(int idDpto, int idCiudad);
        Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorDepartamento(int idDpto);
        Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorNombre(string nombreJuzgado);

        #endregion

        Task<IEnumerable<TiposProcesos>> ObtenerTiposProcesosEmbargos();

        Task<IEnumerable<TipoEmbargos>> ObtenerTiposEmbargos();

        Task<Embargo> InsertarEmbargo(Embargo embargo);


        Task<IEnumerable<Embargo>> ObtenerEmbargos();

        Task<Embargo> EliminarEmbargo(Guid Id);

        Task<Embargo> ActualizarEmbargo(Embargo embargo);

        Task<EmbargoCuentaConcepto> InsertarEmbargoCuentaConcepto(EmbargoCuentaConcepto ecc);


        Task<Embargo> ObtenerEmbargoWorkManeger(string numero);

        Task<IEnumerable<EmbargoCuentaConcepto>> ObtenerEmbargosCuentaConcepto();

        Task<EmbargoCuentaConcepto> EliminarEmbargoCuentaConcepto(Guid Id);


        Task<EmbargoCuentaConcepto> ActualizarEmbargoCuentaConcepto(EmbargoCuentaConcepto ecc);


        Task<IEnumerable<TipoRetencion>> ObtenerTiposRetenciones();

        Task<BeneficiariosPagoEmbargo> InsertarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargo be);

        Task<BeneficiariosPagoEmbargo>  ActualizarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargo be);


        Task<BeneficiariosPagoEmbargo> EliminarBeneficiariosPagoEmbargos(Guid Id);

        Task<IEnumerable<BeneficiariosPagoEmbargo>> ObtenerBeneficiariosEmbargo();

        Task<IEnumerable<Embargo>> ObtenerEmbargosRangoFecha(DateTime FechaInicial,DateTime FechaFinal);

        Task<Desembargo> InsertarDesembargo(Guid Id);

        Task<IEnumerable<ObtenerDesembargo>> ObtenerDesembargo();

        Task<TipoIdentificacion> ObtenerTipoIdentificacionById(int TIPO);




    }
}