using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Table roles
    /// </summary>
    public class Rol
    {
        [Key]
        public Guid RL_ID { get; set; }
        public string RL_DESCRIPCION { get; set; }
        public Guid RL_MODIFICADOPOR { get; set; }
        public DateTime RL_FECHAMODIFICACION { get; set; }
        public Guid RL_CREADOPOR { get; set; }
        public DateTime RL_FECHACREACION { get; set; }
        public bool RL_ESTADO { get; set; }
    }
}
