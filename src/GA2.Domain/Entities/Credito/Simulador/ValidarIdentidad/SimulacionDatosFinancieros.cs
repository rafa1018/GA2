using System;
namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Simulacion Datos Financieros
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class SimulacionDatosFinancieros
    {
        public Guid SDF_ID { get; set; }
        public Guid SLS_ID { get; set; }
        public string SDF_DESCRIPCION_SALARIO { get; set; }
        public float SDF_VALOR_SALARIO { get; set; }
        public string SDF_DESCRIPCION_OTRO_INGRESOS { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS { get; set; }
        public string SDF_DESCRIPCION_OTRO_ING1 { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS1 { get; set; }
        public string SDF_DESCRIPCION_OTRO_ING2 { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS2 { get; set; }
        public string SDF_DESCRIPCION_OTRO_ING3 { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS3 { get; set; }
        public string SDF_DESCRIPCION_OTRO_ING4 { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS4 { get; set; }
        public string SDF_DESCRIPCION_OTRO_ING5 { get; set; }
        public float SDF_VALOR_OTROS_INGRESOS5 { get; set; }
        public float SDF_VALOR_TOTAL_INGRESOS { get; set; }
        public float SDF_VALOR_TOTAL_EGRESOS { get; set; }
        public Guid SDF_USUARIO_ACTUALIZA { get; set; }
        public DateTime SDF_FECHA_ACTUALIZA { get; set; }
    }
}
