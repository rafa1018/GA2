using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de respuesta al consultar las cesantias de un usuario
    /// </summary>
    public class ObtenerTramiteCesantiasDto
    {
        public string TIPO_CREDITO { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        public int NUMERO_SOLICITUD { get; set; }
        public int CEDULA_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string ACTIVIDAD { get; set; }
        public int ID_ACTIVIDAD_FLUJO { get; set; }
        public int ORDEN { get; set; }
        public string ESTADO_ACTIVIDAD { get; set; }
        public int ID_CUENTA { get; set; }
        public Guid ID_SIMULACION { get; set; }
        public int ID_ESTADO_ACTIVIDAD { get; set; }
        public Guid USUARIO_RESPONSABLE { get; set; }
        public int ID_TIPO_CREDITO { get; set; }
        public string CONVENIO_ASEGURADORA { get; set; }
        public int CODIGO_ASEGURADORA { get; set; }
        public int ASEGURADORA { get; set; }
        public string NO_CELULAR { get; set; }
        public string CORREO_PERSONAL { get; set; }
        public string DIRECCION_RESIDENCIA { get; set; }
        public string TELEFONO_RESIDENCIA { get; set; }
        public string TIPO_INMUEBLE { get; set; }
        public string TIPO_VIVIENDA { get; set; }
        public int VALOR_INMUEBLE { get; set; }
        public int VALOR_CREDITO { get; set; }
        public int PLAZO_FINANCIEACION { get; set; }
        public decimal PORC_FINANCIACION { get; set; }
        public string CAPTURA_DATOS { get; set; }
        public string ACTIVIDAD_PRINCIPAL { get; set; }
        public string CARGA_ARCHIVO { get; set; }
        public string VISUALIZAR_ARCHIVOS { get; set; }
        public string PUEDE_DELEGAR { get; set; }
        public string ENVIO_NITICACION { get; set; }
        public string ENVIO_NOTICIACION_VENC { get; set; }
        public string COLOR_GRILLA { get; set; }
        public Guid TRS_ID { get; set; }
        public string PANELES { get; set; }
        public string GENERA_PDF_RESUMEN { get; set; }
        public string CONSULTA_BURO { get; set; }
        public string CONSULTA_RIESGO { get; set; }
        public string GENERA_DOC_LEGALIZACION { get; set; }
        public Guid USUARIO_RIESGO { get; set; }

        // campos para cesantias
        public int clienteId { get; set; }
    }
}
