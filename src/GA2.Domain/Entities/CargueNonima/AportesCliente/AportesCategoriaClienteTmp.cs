using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Modelo tabla temporal de cargue nomina
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>27/04/2021</date>
    public class AportesCategoriaClienteTmp
    {
        public int CLI_ID { get; set; }
        public int CTG_ID { get; set; }
        public int APC_CUOTAS_ACUMULADAS { get; set; }
        public DateTime APC_FECHA_ULTIMA_CUOTA { get; set; }
        public DateTime APC_FECHA_PRIMERA_CUOTA { get; set; }
    }
}
