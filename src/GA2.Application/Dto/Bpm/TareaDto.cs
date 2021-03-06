using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class TareaDto
    {
        public Guid TRA_ID { get; set; }
        public Guid PCS_ID { get; set; }
        public string TRA_NOMBRE { get; set; }
        public DateTime TRA_FECHAINICIO { get; set; }
        public DateTime TRA_FECHAFIN { get; set; }
        public DateTime TRA_CIERRE_ESTIMADO { get; set; }
        public bool TRA_ACTIVA { get; set; }
        public Guid RL_ID_RESPONSABLE { get; set; }
        public IEnumerable<UsuarioDto> TRA_ACTORES { get; set; }
        public Guid TRA_CREATEDOPOR { get; set; }
        public DateTime TRA_FECHACREACION { get; set; }
        public Guid TRA_MODIFICADOPOR { get; set; }
        public DateTime TRA_FECHAMODIFICACION { get; set; }
        public Guid TRA_ID_ENTRADA { get; set; }
        public Guid TRA_ID_SALIDA { get; set; }
        public int TRA_ORDEN { get; set; }
    }
}
