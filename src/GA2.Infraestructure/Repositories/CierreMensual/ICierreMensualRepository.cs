using Azure;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICierreMensualRepository
    {
        Task<List<int>> ObtenerCategoriaConceptos(string concepto);
        Task<int> ObtenerCuentaAbono(string concepto);
        Task<ProgramacionCierreMensual> ProgramarCierreMensual(ParametrosCierreMensual programacionCierre, CierreMensual cierre);
        Task<IPC> ObtenerIPCMes();
        Task<ProgramacionCierreMensual> ActualizaEstadoCierreMensual(Guid id, int estado);
        Task<IEnumerable<ProgramacionCierreMensual>> ConsultarProgramacionCierreMensual();
        Task<bool> ValidarExisteCierre(int anio, int mes);
        Task<IEnumerable<ReporteCierreMensual>> ReporteCierreMensual(Guid Id);


    }
}