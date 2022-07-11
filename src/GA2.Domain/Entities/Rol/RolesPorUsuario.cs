using System;

namespace GA2.Domain.Entities
{
    public class RolesPorUsuario
    {
        public Guid RLP_ID { get; set; }
        public Guid RL_ID { get; set; }
        public Guid USR_ID { get; set; }
        public Guid RLP_MODIFICADOPOR { get; set; }
        public DateTime RLP_FECHAMODIFICACION { get; set; }
        public Guid RLP_CREADOPOR { get; set; }
        public DateTime RLP_FECHACREACION { get; set; }
        public bool RLP_ESTADO { get; set; }




    }
}
