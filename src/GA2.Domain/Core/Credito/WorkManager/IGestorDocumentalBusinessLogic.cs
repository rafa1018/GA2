using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IGestorDocumentalBusinessLogic
    {
        Task<object> CrearRegistro(PeticionCreditoBasicaDto peticionCredito);
        Task<object> ActualizarRegistro(RequestUpdateDto request);
        Task<object> AttachFiles(AttachRequestDto request);
        Task<object> CrearFlujoFirmasComite(RequestFlujoFirmasDto request);
    }
}