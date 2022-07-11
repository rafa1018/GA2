using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad educativa
    /// </summary>
    public class SedeEntidadEducativa
    {


        public Guid SNE_SEDE_ID { get; set; }
        public Guid ENE_ID { get; set; }
        public string SNE_SEDE_NOMBRE_RAZON_SOCIAL { get; set; }
        public string ENE_CORREO_ELECTRONICO { get; set; }
        public int SNE_SEDE_DPC_ID { get; set; }
        public bool SNE_SEDE_ESTADO { get; set; }

    }
}