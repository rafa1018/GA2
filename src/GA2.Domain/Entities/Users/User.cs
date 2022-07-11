using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Table USERS
    /// </summary>
    public class User
    {
       
        public Guid USR_ID { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_SEGUNDONOMBRE { get; set; }
        public string USR_APELLIDO { get; set; }
        public string USR_SEGUNDOAPELLIDO { get; set; }
        public string USR_IDENTIFICACION { get; set; }
        public int TID_ID { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_USERNAME { get; set; }
        public string USR_PASSWORD { get; set; }

        public Guid USR_MODIFICADOPOR { get; set; }
        public DateTime USR_FECHAMODIFICACION { get; set; }
        public Guid USR_CREADOPOR { get; set; }
        public DateTime USR_FECHACREACION { get; set; }
        public bool USR_ESTADO { get; set; }
        public string TID_CODIGO { get; set; }

        public bool ACTIVE_DIRECTORY { get; set; }

        public string TOKEN { get; set; }

    

    }
}



