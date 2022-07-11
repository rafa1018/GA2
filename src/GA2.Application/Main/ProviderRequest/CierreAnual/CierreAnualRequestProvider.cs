using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{

    public class CierreAnualRequestProvider : ProviderRequestFactory, ICierreAnualRequestProvider
    {
        private readonly IOptions<ApisOptions> _optionsApis;

        public CierreAnualRequestProvider(ITokenClaims tokenClaims, IOptions<ApisOptions> optionsApis) : base(tokenClaims)
        {
            _optionsApis = optionsApis;
        }

        public async Task<Response<RespuestaCierreAnualDto>> CierreAnual(ProgramacionCierreAnual programacion)
        {
            ProgramacionCierreAnualDto cierreAnualDto = new ProgramacionCierreAnualDto() {
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

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.CierreAnual;

            return await PostAsyncV2<Response<RespuestaCierreAnualDto>>(cierreAnualDto, new Uri(url), null);

        }

        public async Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ConsultarProgramacionCierreAnual;

            return await GetAsync<Response<IEnumerable<ProgramacionCierreAnualDto>>>(new Uri(url));

        }
    }
}
