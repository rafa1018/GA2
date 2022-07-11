using GA2.Application.Dto;
using System;
using System.Collections.Generic;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Estructura los datos para ser cargados a la tabla de aportes de clientes
    /// </summary>
    public static class AportesClientesEstructuracion
    {
        /// <summary>
        /// Metodo que realiza la estructuración
        /// </summary>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static List<AportesClienteDto> EstructurarAportes(List<CuentaDto> cuentas)
        {
            List<AportesClienteDto> aportes = new List<AportesClienteDto>();
            foreach (CuentaDto cuenta in cuentas)
            {
                AportesClienteDto aporte = new AportesClienteDto();
                aporte.CLI_ID = cuenta.NumeroCuenta;
                aporte.APC_FECHA_PRIMERA_CUOTA = DateTime.Parse(cuenta.FechaPrimerAporte.ToString("yyyy-MM-dd"));
                aporte.APC_FECHA_ULTIMA_COUTA = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                aporte.APC_CUOTAS_ACUMULADAS = 1;

                aportes.Add(aporte);
            }

            return aportes;
        }
    }
}
