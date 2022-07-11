using GA2.Application.Dto.Haberes;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IIntegracionesGA2HaberesBusinessLogic
    {
        Task<FileResult> GenerarReporteHaberes(Uri url, HaberesRequestDto request, Guid userId);
    }
}