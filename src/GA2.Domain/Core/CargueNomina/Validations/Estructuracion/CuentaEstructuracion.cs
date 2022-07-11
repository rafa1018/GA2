using GA2.Application.Dto;
using System;
using System.Collections.Generic;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Estructura los datos para ser insertados y trabajados en la tabla cuenta
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public static class CuentaEstructuracion
    {
        /// <summary>
        /// Metodo que realiza la estructuración
        /// </summary>
        /// <param name="componentes"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public static List<CuentaDto> EstructurarCuenta(ComponentesDTO componentes)
        {
            List<CuentaDto> cuentas = new List<CuentaDto>();

            foreach (CuerpoArchivoDto registro in componentes.BODY)
            {
                CuentaDto cuenta = new CuentaDto();
                //cuenta.CTA_ID = Guid.NewGuid();
                cuenta.NumeroCuenta = int.Parse(registro.IDENTIFICACION);
                cuenta.Saldo = int.Parse(registro.VALOR.ToString());
                cuenta.FechaCreacion = DateTime.Parse((DateTime.Now).ToString("yyyy-MM-dd"));
                cuenta.IdDocumento = componentes.DOCUMENTO.DocumentoId;
                cuenta.IdCuentaHabiente = cuenta.NumeroCuenta;
                cuenta.FechaPrimerAporte = DateTime.Parse(cuenta.FechaCreacion.ToString("yyyy-MM-dd"));
                cuenta.SaldoDisponible = int.Parse(cuenta.Saldo.ToString());
                cuenta.Principal = 1;
                cuenta.FechaCierre = DateTime.Parse(DateTime.MaxValue.ToString("yyyy-MM-dd"));
                cuentas.Add(cuenta);
            }

            return cuentas;
        }
    }
}
