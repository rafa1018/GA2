using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{

    public class CierreMensualRequestProvider : ProviderRequestFactory, ICierreMensualRequestProvider
    {
        private readonly IOptions<ApisOptions> _optionsApis;

        public CierreMensualRequestProvider(ITokenClaims tokenClaims, IOptions<ApisOptions> optionsApis) : base(tokenClaims)
        {
            _optionsApis = optionsApis;
        }

        public async Task<Response<RespuestaCierreMensualDto>> CierreMensual(ProgramacionCierreMensual programacion)
        {
            ProgramacionCierreMensualDto cierreMensualDto = new ProgramacionCierreMensualDto() {
                TipoProceso = programacion.TIPO_PROCESO,
                ConceptosAhorro = programacion.CONCEPTOS_AHORRO,
                ConceptosCesantias = programacion.CONCEPTOS_CESANTIAS,
                CuentaAbonoAhorro = programacion.CUENTA_ABONO_AHORRO,
                CuentaAbonoCesantias = programacion.CUENTA_ABONO_CESANTIAS,
                Estado = programacion.ESTADO,
                FechaCargue = programacion.FECHA_CARGUE,
                FechaProcesamiento = programacion.FECHA_PROCESAMIENTO,
                GeneraActualizacion = programacion.GENERA_ACTUALIZACION,
                Id = programacion.ID,
                IPC = programacion.IPC,
                Anio = programacion.ANIO,
                Mes = programacion.MES,
                UsuarioProcesamiento = programacion.USUARIO_PROCESAMIENTO
            };         

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.CierreMensual;

            return await PostAsyncV2<Response<RespuestaCierreMensualDto>>(cierreMensualDto, new Uri(url), null);

        }

        public async Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ConsultarProgramacionCierreMensual;

            return await GetAsync<Response<IEnumerable<ProgramacionCierreMensualDto>>>(new Uri(url));

        }

        public async Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ReporteCierreMensual +
                    $"?request={Id}";
            var response = await GetAsync< Response<IEnumerable<ReporteCierreMensualDto>>>(new Uri(url));

            return response;

        }
    }
}
