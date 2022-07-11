using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ResultadoVerificacionTercero
    {

        private string encontradoField;

        private string metodoField;

        private string listasField;

        private string errorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Encontrado
        {
            get
            {
                return this.encontradoField;
            }
            set
            {
                this.encontradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Metodo
        {
            get
            {
                return this.metodoField;
            }
            set
            {
                this.metodoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Listas
        {
            get
            {
                return this.listasField;
            }
            set
            {
                this.listasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }
}
