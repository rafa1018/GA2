using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IEntidadesRepository
    {
        Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativa();
        Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativa entidad);
        Task<IEnumerable<ProgramaEducativo>> ObtenerProgramaEducativo(Guid idEntidad);
        Task<ProgramaEducativo> CrearProgramaEducativo(ProgramaEducativo programaEducativo);
        Task<IEnumerable<NivelEducativo>> ObtenerNivelEducativoCesantias(Guid idPrograma);
        Task<EntidadEducativa> CrearEntidadEducativa(EntidadEducativa entidadEducativa);
        Task<EntidadEducativa> ActualizarEntidadEducativa(EntidadEducativa entidadEducativa);
        Task<EntidadEducativa> EliminarEntidadEducativaPorId(string EntidadEducativaId);
        Task<IEnumerable<SedeEntidadEducativa>> ObtenerSedesPorEntidadEducativa(string entidadEducativaId);
        Task<SedeEntidadEducativa> CrearSedeEntidadEducativa(SedeEntidadEducativa sedeEntidadEducativa);
        Task<SedeEntidadEducativa> EliminarSedeEntidadEducativaPorId(string sedeEntidadEducativaId);
        Task<IEnumerable<ListarProgramaEducativo>> ObtenerProgramaEducativoPorEntidad(string idEntidad);
        Task<ProgramaEducativo> EliminarProgramaEducativoPorId(string idProgramaEducativo);
        Task<ProgramaEducativo> ActualizarProgramaEducativo(ProgramaEducativo programaEducativo);
        Task<BloqueoEntidadEducativa> BloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa);
        Task<BloqueoEntidadEducativa> DesbloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa);
        Task<IEnumerable<BloqueoEntidadEducativa>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa);
        Task<IEnumerable<CuentaBancariaEntidadEducativa>> ObtenerCuentaBancariaPorEntidad(string idEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa);
        Task<CuentaBancariaEntidadEducativa> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta);
        Task<InsertarArchivoEntidad> InsertarArchivoPorEntidad(InsertarArchivoEntidad insertarArchivoEntidad);
        Task<IEnumerable<ConsultarArchivoPorEntidad>> ConsultarArchivoPorEntidad(Guid IdEntidad);



    }
}