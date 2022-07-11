using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IEntidadesBusinessLogic
    {
        #region EntidadEducativa
        Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativa();
        Task<Response<IEnumerable<EntidadEducativaDto>>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativaDto entidad);
        Task<Response<EntidadEducativaDto>> CrearEntidadEducativa(EntidadEducativaDto EntidadEducativa);
        Task<Response<EntidadEducativaDto>> ActualizarEntidadEducativa(EntidadEducativaDto EntidadEducativa);
        Task<Response<EntidadEducativaDto>> EliminarEntidadEducativaPorId(string idEntidadEducativa);
        Task<Response<IEnumerable<SedeEntidadEducativaDto>>> ObtenerSedesPorEntidadEducativa(string idEntidadEducativa);
        Task<Response<SedeEntidadEducativaDto>> CrearSedeEntidadEducativa(SedeEntidadEducativaDto sedeEntidadEducativa);
        Task<Response<SedeEntidadEducativaDto>> EliminarSedesEntidadEducativaPorId(string idSedeEntidadEducativa);
        Task<Response<BloqueoEntidadEducativaDto>> BloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto);
        Task<Response<BloqueoEntidadEducativaDto>> DesbloqueoEntidadEducativa(BloqueoEntidadEducativaDto bloqueoEntidadEducativaDto);
        Task<Response<IEnumerable<BloqueoEntidadEducativaDto>>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa);
        Task<Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>> ObtenerCuentaBancariaPorEntidad(string idEntidad);
        Task<Response<CuentaBancariaEntidadEducativaDto>> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativa);
        Task<Response<CuentaBancariaEntidadEducativaDto>> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativaDto cuentaBancariaEntidadEducativaDto);
        Task<Response<CuentaBancariaEntidadEducativaDto>> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta);
        Task<Response<IEnumerable<ProgramaEducativoDto>>> ObtenerProgramaEducativo(Guid idEntidad);
        Task<Response<ProgramaEducativoDto>> CrearProgramaEducativo(ProgramaEducativoDto programaEducativo);
        Task<Response<IEnumerable<ListarProgramaEducativoDto>>> ObtenerProgramaEducativoPorEntidad(string idEntidad);
        Task<Response<ProgramaEducativoDto>> EliminarProgramaEducativoPorId(string idProgramaEducativo);
        Task<Response<ProgramaEducativoDto>> ActualizarProgramaEducativo(ProgramaEducativoDto ProgramaEducativo);
        Task<Response<bool>> CargarDocumentosEntidad(List<CargarDocumentosEntidadDto> CargarDocumentosEntidadDto, Guid idEntidad);
        Task<Response<IEnumerable<ConsultarArchivoPorEntidadDto>>> ConsultarArchivoPorEntidad(Guid IdEntidad);
        Task<FileResult> DescargarArchivoPorId(string rutaStorage);

        #endregion EntidadEducativa

    }
}