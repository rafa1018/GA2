namespace GA2.Domain.Entities
{
    /// <summary>
    /// Conceptos tabla conceptos
    /// </summary>
    public class Concepto
    {
        public int CNC_ID { get; set; }
        public string CNC_DESCRIPCION { get; set; }
        public int CNC_FORMULA_CALCULO { get; set; }
        public int CNC_ORDEN { get; set; }
        public string CAT_TIPO_CONCEPTO { get; set; }
        public bool CNC_INTERES { get; set; }
    }

    public class ConceptoHomologado
    {
        public int CNH_ID { get; set; }
        public int CNC_ID { get; set; }
        public string CNH_CONCEPTO_CARGA { get; set; }
    }
}
