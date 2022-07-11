using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Interfaz para solicitud de cesantias
    /// </summary>
    public interface ICesantiasBusinessLogic
    {
        Task<Response<ObtenerTramiteCesantiasDto>> ObtenerTramiteCesantias(ParametrosObtenerCesantiasDto solicitud);

        Task<Response<InformacionBasicaCesantiasDto>> InformacionBasicaCesantias(int numeroIdentificacion);
    }
}
