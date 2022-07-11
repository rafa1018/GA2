using System;

namespace GA2.Domain.Entities
{
    public class ParametrizacionArchivoEntidadEducativa
    {
        public Guid ENE_PAM_ID { get; set; }
        public Guid ENE_ID { get; set; }
        public string ENE_PAM_NOMBRE_ARCHIVO { get; set; }
        public string ENE_PAM_DESCRIPCION_ARCHIVO { get; set; }
        public bool ENE_PAM_REQUERIDO { get; set; }
        public bool ENE_PAM_ESTADO { get; set; }
        public int ENE_PAM_ORDEN { get; set; }
    }
}
