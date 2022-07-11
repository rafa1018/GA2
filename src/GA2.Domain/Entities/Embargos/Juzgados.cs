using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Juzgados
    /// </summary>
    public class Juzgados
    {
        public string ID_JUZGADO { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public string NOMBRE { get; set; }
        public int ID_DPD { get; set; }
        public string DPD_NOMBRE { get; set; }
        public int ID_DPC { get; set; }
        public string DPC_NOMBRE { get; set; }
        public string NRO_CUENTA { get; set; }
        public string CODIGO_OFICINA { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string CELULAR { get; set; }
        public string CONTACTO { get; set; }
        public bool ESTADO { get; set; }
        public int DPC_CODIGO { get; set; }
    }


    public class JuzgadosGuid
    {
        public Guid ID_JUZGADO { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public string NOMBRE { get; set; }
        public int ID_DPD { get; set; }
        public string DPD_NOMBRE { get; set; }
        public int ID_DPC { get; set; }
        public string DPC_NOMBRE { get; set; }
        public string NRO_CUENTA { get; set; }
        public string CODIGO_OFICINA { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string CELULAR { get; set; }
        public string CONTACTO { get; set; }
        public bool ESTADO { get; set; }
        public int DPC_CODIGO { get; set; }
    }
}
