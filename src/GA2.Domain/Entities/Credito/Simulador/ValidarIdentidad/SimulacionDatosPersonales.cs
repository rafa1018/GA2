using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla Simulacion Datos Personales
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class SimulacionDatosPersonales
    {
        public Guid SDP_ID { get; set; }
        public Guid SLS_ID { get; set; }
        public int FRZ_ID { get; set; }
        public int CTG_ID { get; set; }
        public int GRD_ID { get; set; }
        public string SDP_NUMERO_DOCUMENTO { get; set; }
        public string SDP_NOMBRES_APELLIDOS { get; set; }
        public int SDP_EDAD { get; set; }
        public DateTime SDP_FECHA_AFILIACION { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public string SDP_DIRECCION { get; set; }
        public string SDP_TELEFONO_FIJO { get; set; }
        public string SDP_TELEFONO_CELULAR { get; set; }
        public string SDP_E_MAIL { get; set; }
        public int SDP_CUOTAS { get; set; }
        public string SDP_REGIMEN { get; set; }
        public decimal SDP_VALOR_INMUEBLE { get; set; }
        public int TVV_ID { get; set; }
        public int DPD_ID_INMUEBLE { get; set; }
        public int DPC_ID_INMUEBLE { get; set; }
        public Guid SDP_USUARIO_ACTUALIZA { get; set; }
        public DateTime SDP_FECHA_ACTUALIZA { get; set; }
        public string DEPARTAMENTO_RESIDENCIA { get; set; }
        public string CIUDAD_RESIDENCIA { get; set; }
        public string DEPARTAMENTO_INMIUEBLE { get; set; }
        public string CIUDAD_INMUEBLE { get; set; }
        public string FUERZA { get; set; }
        public string CATEGORIA { get; set; }
        public string GRADO { get; set; }
        public string TIPO_VIVIENDA { get; set; }
        public int TPA_ID { get; set; }
        public string TIPO_ACTOR { get; set; }
        public string UNIDAD_EJECUTORA { get; set; }
        public object UEJ_ID { get; set; }
    }
}
