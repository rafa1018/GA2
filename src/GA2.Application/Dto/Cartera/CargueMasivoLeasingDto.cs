using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GA2.Application.Dto
{
    public class CargueMasivoLeasingDto
    {
        [JsonPropertyName("credito")]
        public string Nro_Credito { get; set; }

        [JsonPropertyName("Identificacion")]
        public string Identificacion { get; set; }

        [JsonPropertyName("Ciudad_Expedicion")]
        public string Ciudad_Expedicion { get; set; }

        [JsonPropertyName("Fecha_Expedicion_Documento")]
        public string Fecha_Expedicion_Documento { get; set; }

        [JsonPropertyName("Afiliado")]
        public string Afiliado { get; set; }

        [JsonPropertyName("Direccion_Residencia")]
        public string Direccion_Residencia { get; set; }

        [JsonPropertyName("Telefono")]
        public string Telefono { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("Fecha_Nacimiento")]
        public string Fecha_Nacimiento { get; set; }

        [JsonPropertyName("Ciudad_Nacimiento")]
        public string Ciudad_Nacimiento { get; set; }

        [JsonPropertyName("Edad")]
        public string Edad { get; set; }

        [JsonPropertyName("Estado_Civil")]
        public string Estado_Civil { get; set; }

        [JsonPropertyName("Categoria")]
        public string Categoria { get; set; }

        [JsonPropertyName("Grado")]
        public string Grado { get; set; }

        [JsonPropertyName("Genero")]
        public string Genero { get; set; }

        [JsonPropertyName("tasa_Credito")]
        public string tasa_Credito { get; set; }

        [JsonPropertyName("Canon_inicial")]
        public string Canon_inicial { get; set; }

        [JsonPropertyName("Canon_Extraordinario")]
        public string Canon_Extraordinario { get; set; }

        [JsonPropertyName("Clase_Inmueble")]
        public string Clase_Inmueble { get; set; }

        [JsonPropertyName("Direccion_Inmueble")]
        public string Dirección_Inmueble { get; set; }

        [JsonPropertyName("Ciudad_Inmueble")]
        public string Ciudad_Inmueble { get; set; }

        [JsonPropertyName("Matricula_Inmueble")]
        public string Matricula_Inmueble { get; set; }

        [JsonPropertyName("Escritura_Inmueble")]
        public string Escritura_Inmueble { get; set; }

        [JsonPropertyName("Fecha_Escritura")]
        public string Fecha_Escritura { get; set; }

        [JsonPropertyName("Notaria")]
        public string Notaria { get; set; }

        [JsonPropertyName("Linderos_inmueble")]
        public string Linderos_inmueble { get; set; }

        [JsonPropertyName("Estado_vivienda")]
        public string Estado_vivienda { get; set; }

        [JsonPropertyName("Descripcion_Inmueble")]
        public string Descripción_Inmueble { get; set; }

        [JsonPropertyName("ScoreTranunion")]
        public string ScoreTranunion { get; set; }

        [JsonPropertyName("Valor_Comercial_inmueble")]
        public string Valor_Comercial_inmueble { get; set; }

        [JsonPropertyName("Fecha_Solicitud")]
        public string Fecha_Solicitud { get; set; }

        [JsonPropertyName("Fecha_Desembolso")]
        public string Fecha_Desembolso { get; set; }

        [JsonPropertyName("Fecha_Finaliza_Pagos")]
        public string Fecha_Finaliza_Pagos { get; set; }

        [JsonPropertyName("TipoCreditoSublínea")]
        public string TipoCreditoSublínea { get; set; }

        [JsonPropertyName("Monto_Aprobado")]
        public string Monto_Aprobado { get; set; }

        [JsonPropertyName("Saldo_Capital")]
        public string Saldo_Capital { get; set; }

        [JsonPropertyName("Vlor_Cuota")]
        public string Vlor_Cuota { get; set; }

        [JsonPropertyName("Porc_Seguro_Vida")]
        public string Porc_Seguro_Vida { get; set; }

        [JsonPropertyName("Porc_Seguro_Hogar")]
        public string Porc_Seguro_Hogar { get; set; }

        [JsonPropertyName("Fecha_ultimo_Pago")]
        public string Fecha_ultimo_Pago { get; set; }

        [JsonPropertyName("Fecha_proximo_Pago")]
        public string Fecha_proximo_Pago { get; set; }

        [JsonPropertyName("Plazo")]
        public string Plazo { get; set; }

        [JsonPropertyName("Cuotas_Pendientes")]
        public string Cuotas_Pendientes { get; set; }

        [JsonPropertyName("Valor_Opcion_Compra")]
        public string Valor_Opcion_Compra { get; set; }

        [JsonPropertyName("AcuInteresCorriente")]
        public string Valor_Causación_Acumulada_Interes_Corriente { get; set; }

        [JsonPropertyName("AcuInteresRemanente")]
        public string Valor_Causación_Acumulada_Interes_Remanente { get; set; }

        [JsonPropertyName("CausacionSeguroVida")]
        public string Valor_Causación_Seguro_Vida { get; set; }

        [JsonPropertyName("CausacionSeguroHogar")]
        public string Valor_Causación_Seguro_Hogar { get; set; }


    }
}


