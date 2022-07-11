using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad educativa
    /// </summary>
    public class EntidadEducativa
    {

        public Guid ENE_ID { get; set; }
        public int ENE_TIPO_IDENTIFICACION { get; set; }
        public string ENE_NIT { get; set; }
        public string ENE_NOMBRE_RAZON_SOCIAL { get; set; }
        public string ENE_CORREO_ELECTRONICO { get; set; }
        public int ENE_DPC_ID { get; set; }
        public string ENE_DIRECCION { get; set; }
        public string ENE_TELEFONO { get; set; }
        public string ENE_NOMBRE_CONTACTO { get; set; }
        public bool ENE_ESTADO{ get; set; }

    }
}