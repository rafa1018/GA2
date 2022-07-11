using System;
using System.IO;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Cuenta del storage
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>16/04/2021</date>
    public class CuentaStorage
    {
        public int ID { get; set; }
        public string CONTAINERNAME { get; set; }
        public string BLOBNAME { get; set; }
        public string MODULO { get; set; }
        public Stream FILE { get; set; }
        public Guid MODIFICADOPOR { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public Guid CREADOPOR { get; set; }
        public DateTime FECHACREACION { get; set; } = DateTime.Now;
        public bool ESTADO { get; set; } = true;
    }
}
