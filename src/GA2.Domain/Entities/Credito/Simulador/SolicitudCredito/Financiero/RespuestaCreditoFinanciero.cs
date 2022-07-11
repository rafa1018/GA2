using System;

namespace GA2.Domain.Entities
{
    public class RespuestaCreditoFinanciero
    {
        public Guid SOF_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public string SOF_CONCEPTO_SALARIO { get; set; }
        public int SOF_VALOR_CONCEPTO_SALARIO { get; set; }
        public string SOF_CONCEPTO_1 { get; set; }
        public int SOF_VALOR_CONCEPTO_1 { get; set; }
        public string SOF_CONCEPTO_2 { get; set; }
        public int SOF_VALOR_CONCEPTO_2 { get; set; }
        public string SOF_CONCEPTO_3 { get; set; }
        public int SOF_VALOR_CONCEPTO_3 { get; set; }
        public string SOF_CONCEPTO_4 { get; set; }
        public int SOF_VALOR_CONCEPTO_4 { get; set; }
        public string SOF_CONCEPTO_5 { get; set; }
        public int SOF_VALOR_CONCEPTO_5 { get; set; }
        public string SOF_CONCEPTO_6 { get; set; }
        public int SOF_VALOR_CONCEPTO_6 { get; set; }
        public int SOF_VALOR_TOTAL_INGRESOS { get; set; }
        public int SOF_VALOR_TOTAL_EGRESOS { get; set; }
        public string SOF_DIRECCION_VIVIENDA { get; set; }
        public string SOF_MATRICULA_VIVIENDA { get; set; }
        public int SOF_VALOR_COMERCIAL_VIVIENDA { get; set; }
        public string SOF_MARCA_VEHICULO { get; set; }
        public string SOF_PLACA_VEHICULO { get; set; }
        public int SOF_VALOR_COMERCIAL_VEHICULO { get; set; }
        public Guid SOF_CREADO_POR { get; set; }
        public DateTime SOF_FECHA_CREACION { get; set; }
        public Guid SOF_ACTUALIZADO_POR { get; set; }
        public DateTime SOF_FECHA_ACTUALIZA { get; set; }
    }
}
