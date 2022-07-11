using GA2.Application.Main;
using GA2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core.DocumentsCreators.Riesgo
{
    public class RiesgoPdfCreator : ProvividerRiesgoPdf
    {
        internal async Task<FileResult> GenerarFichaRiesgo( DatosSolicitudComite respuesta, 
                                                            SimulacionCliente simulacion,
                                                            SimulacionDatosPersonales datos, 
                                                            ConsultaSolicitudCredito solicitud,
                                                            string fileBase,
                                                            string header,
                                                            string footer,
                                                            string css)
        {
            Dictionary<string, string> Values = new Dictionary<string, string>();
            string styles = css;
            var conversorALetras = new NumerosALetras();
            var tipoDocumento = string.Empty;
            switch (solicitud.TID_ID)
            {
                case 1:
                    tipoDocumento = "CEDULA DE CIUDADANIA";
                    break;
                default:
                    tipoDocumento = "";
                    break;

            }

            Values.Add("$FechaSistema", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            Values.Add("$FechaProceso", simulacion.SMC_FECHA_SIMULACION.ToString("dd/MM/yyyy"));
            Values.Add("$NumeroSolicitud", respuesta.SOC_NUMERO_SOLICITUD.ToString());
            Values.Add("$TipoIdentificacion", tipoDocumento);
            Values.Add("$NumeroIdentificacion", datos.SDP_NUMERO_DOCUMENTO);
            Values.Add("$Nombres", datos.SDP_NOMBRES_APELLIDOS);
            Values.Add("$Ingresos", respuesta.TOTAL_INGRESOS.ToString("$#,##0"));
            Values.Add("$Egresos", respuesta.TOTAL_EGRESOS.ToString("$#,##0"));
            Values.Add("$CuotasAportadas", datos.SDP_CUOTAS.ToString());
            Values.Add("$MontoSolicitado", respuesta.SOP_VALOR_CREDITO.ToString("$#,##0"));
            Values.Add("$ValorCuota", simulacion.SMC_VALOR_CUOTA.ToString("$#,##0"));
            Values.Add("$PlazoCredito", respuesta.PLAZO_FINANCIACION.ToString());
            Values.Add("$CapacidadPagoDesprendible", "desprendible");
            Values.Add("$CapacidadPago", "sin desprendible");
            Values.Add("$Resultado", respuesta.SOC_DECISION_BURO);
            Values.Add("$LineaCredito", solicitud.TCR_ID == 2 ? "HIPOTECARIO" : "LEASING HABITACIONAL");
            Values.Add("$ProbabilidadIncumplimiento", "probabilidadincumplimiento");
            Values.Add("$PorcentajePE", "pe");
            Values.Add("$Elaboro", "");
            Values.Add("$Reviso", "");

            return await base.CrearDocumento(fileBase, css, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString().ToUpper(), Values, null, header, footer);

        }
    }
}

