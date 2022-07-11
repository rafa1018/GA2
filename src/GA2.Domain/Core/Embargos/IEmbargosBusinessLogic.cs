using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IEmbargosBusinessLogic
    {
        #region Juzgados

        Task<Response<JuzgadosGuidDto>> ObtenerJuzgadoById(Guid id);

        Task<Response<JuzgadosDto>> ActualizarJuzgado(JuzgadosDto Juzgado);
        Task<Response<JuzgadosDto>> CrearJuzgado(JuzgadosDto juzgado);
        Task<Response<JuzgadosDto>> EliminarJuzgadoPorId(string idJuzgado);
        Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorCiudad(JuzgadoDptoCiudadDto juzgadoDptoCiudad);
        Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorDepartamento(int idDpto);
        Task<Response<IEnumerable<JuzgadosDto>>> ObtenerJuzgadosPorNombre(string nombreDpto);

        #endregion Juzgados


        Task<Response<IEnumerable<TiposProcesosDto>>> ObtenerTiposProcesosEmbargos();

        Task<Response<IEnumerable<TipoEmbargosDto>>> ObtenerTiposEmbargos();

        Task<Response<EmbargosDto>> InsertarEmbargo(InsetEmbargosDto embargo,Guid user_Id);

        Task<Response<IEnumerable<EmbargosDto>>> ObtenerEmbargos();

        Task<Response<EmbargosDto>> EliminarEmbargo(Guid Id);

        Task<Response<EmbargosDto>> ActualizarEmbargo(InsetEmbargosDto embargo, Guid user_Id);

        Task<Response<EmbargoCuentaConceptoDto>> InsertarEmbargoCuentaConcepto(EmbargoCuentaConceptoDto dto,Guid user_Id);

        Task<Response<IEnumerable<EmbargoCuentaConceptoDto>>> ObtenerEmbargosCuentaConcepto();

        Task<Response<EmbargoCuentaConceptoDto>> EliminarEmbargoCuentaConcepto(Guid Id);

        Task<Response<EmbargoCuentaConceptoDto>> ActualizarEmbargoCuentaConcepto(EmbargoCuentaConceptoDto emb, Guid user_Id);

        Task<Response<IEnumerable<TipoRetencionDto>>> ObtenerTiposRetenciones();

        Task<Response<BeneficiariosPagoEmbargoDto>> InsertarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargoDto be, Guid user_Id);

        Task<Response<BeneficiariosPagoEmbargoDto>> ActualizarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargoDto be, Guid user_Id);

        Task<Response<BeneficiariosPagoEmbargoDto>> EliminarBeneficiariosPagoEmbargos(Guid Id);

        Task<Response<IEnumerable<BeneficiariosPagoEmbargoDto>>> ObtenerBeneficiariosEmbargo();

        Task<Response<IEnumerable<EmbargosDto>>> ObtenerEmbargosRangoFecha(DateTime FechaInicial, DateTime FechaFinal);

        Task<Response<DesembargoDto>> InsertarDesembargo(Guid Id);

        Task<Response<IEnumerable<ObtenerDesembargoDto>>> ObtenerDesembargo();

        Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasPorRadicadoWordManager(string numeroRadicado);

    }
}