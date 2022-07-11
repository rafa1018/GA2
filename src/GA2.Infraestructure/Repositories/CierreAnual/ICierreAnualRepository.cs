using Azure;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICierreAnualRepository
    {
        Task<List<int>> ObtenerCategoriaConceptos(string concepto);
        Task<int> ObtenerCuentaAbono(string concepto);
        Task<ProgramacionCierreAnual> ProgramarCierreAnual(ParametrosCierreAnual programacionCierre, CierreAnual cierre);
        Task<IPC> ObtenerIPCMes();
        Task<ProgramacionCierreAnual> ActualizaEstadoCierreAnual(Guid id, int estado);
        Task<IEnumerable<ProgramacionCierreAnual>> ConsultarProgramacionCierreAnual();
        Task<bool> ValidarExisteCierre(int anio, int mes);


    }
}