using GA2.Application.Dto;
using GA2.Application.Dto.Haberes;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class HaberesBusinessLogic : IHaberesBusinessLogic
    {
        private readonly IIntegracionesGA2HaberesBusinessLogic _integraciones;
        private readonly IOptions<CHKeysOptions> _optionsCH;
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        public HaberesBusinessLogic(IIntegracionesGA2HaberesBusinessLogic integraciones, IOptions<CHKeysOptions> optionsCH, ICreditoBusinessLogic creditoBusinessLogic)
        {
            _integraciones = integraciones;
            _optionsCH = optionsCH;
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        public async Task<FileResult> GenerarReporteHaberes(HaberesRequestDto haberesRequest)
        {
            var url = _optionsCH.Value.UrlCajaHonor + "api/generarreportehaberes";
            var uri = new Uri(url);
            var cuenta = new CuentaDto();
            cuenta = (await this._creditoBusinessLogic.ObtenerCuentaById(haberesRequest.ClienteIdentificacion)).Data;
                        
            if (cuenta != null)
            {
                haberesRequest.CuentaId = cuenta.NumeroCuenta;
            }
            else
            {
                throw new Exception("La cuenta no se encuentra");
            }
            return await this._integraciones.GenerarReporteHaberes(uri, haberesRequest, Guid.NewGuid());
        }
    }
}
