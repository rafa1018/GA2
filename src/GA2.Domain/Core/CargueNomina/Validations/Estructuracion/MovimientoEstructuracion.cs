using GA2.Application.Dto;
using System;
using System.Collections.Generic;

namespace GA2.Domain.Core.CargueNomina
{
    /// <summary>
    /// Estructura los datos para ser trabajados y enviados a la tabla movimiento
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public static class MovimientoEstructuracion
    {
        /// <summary>
        /// Metodo que realiza el analisis de los datos obtenidos de componentes
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="componentes"></param>
        /// <returns></returns>
        public static List<MovimientoDTO> EstructurarMovimiento(ComponentesDTO componentes)
        {
            List<MovimientoDTO> movimientos = new List<MovimientoDTO>();
            foreach (CuerpoArchivoDto registro in componentes.BODY)
            {
                MovimientoDTO movimiento = new MovimientoDTO();
                //movimiento.MVT_ID = Guid.NewGuid();
                movimiento.CTA_ID = int.Parse(registro.IDENTIFICACION);
                if (componentes.HEADER.FILE_TIPO == 1) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 2) movimiento.CNC_ID = 15;
                else if (componentes.HEADER.FILE_TIPO == 3) movimiento.CNC_ID = 2;
                else if (componentes.HEADER.FILE_TIPO == 4) movimiento.CNC_ID = 6;
                else if (componentes.HEADER.FILE_TIPO == 5) movimiento.CNC_ID = 4;
                else if (componentes.HEADER.FILE_TIPO == 6) movimiento.CNC_ID = 5;
                else if (componentes.HEADER.FILE_TIPO == 7) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 8) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 9) movimiento.CNC_ID = 2;
                else if (componentes.HEADER.FILE_TIPO == 10) movimiento.CNC_ID = 6;
                else if (componentes.HEADER.FILE_TIPO == 11) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 12) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 13) movimiento.CNC_ID = 1;
                else if (componentes.HEADER.FILE_TIPO == 14) movimiento.CNC_ID = 16;
                else if (componentes.HEADER.FILE_TIPO == 15) movimiento.CNC_ID = 3;
                movimiento.MVT_VALOR = registro.VALOR;
                movimiento.CAT_TIPO_MOVIMIENTO = 'C'.ToString();
                movimiento.MVT_FECHA_PROCESO = componentes.HEADER.FECHA_APORTES;
                movimiento.DCT_ID = componentes.DOCUMENTO.DocumentoId;
                string año = string.Empty, mes = string.Empty;
                char[] fecha = componentes.HEADER.FECHA_APORTES.ToString().ToCharArray();
                for (int caracter = 5; caracter <= 8; caracter++) año += fecha[caracter];
                for (int caracter = 2; caracter <= 3; caracter++) mes += fecha[caracter];
                movimiento.MVT_ANO_PERIODO = int.Parse(año);
                movimiento.MVT_MES_PERIODO = mes;
                movimiento.MVT_FECHA_MOVIMIENTO = registro.PERIODO;
                movimientos.Add(movimiento);
            }
            return movimientos;
        }
    }
}
