using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    //[XmlRoot(ElementName = "Table1")]
    //public class Table1
    //{
    //	[XmlElement(ElementName = "A001NUM_IDENTIFICACION")]
    //	public string A001NUM_IDENTIFICACION { get; set; }
    //	[XmlElement(ElementName = "A001PRIMER_APELLIDO")]
    //	public string A001PRIMER_APELLIDO { get; set; }
    //	[XmlElement(ElementName = "A001SEGUNDO_APELLIDO")]
    //	public string A001SEGUNDO_APELLIDO { get; set; }
    //	[XmlElement(ElementName = "A001PRIMER_NOMBRE")]
    //	public string A001PRIMER_NOMBRE { get; set; }
    //	[XmlElement(ElementName = "A001SEGUNDO_NOMBRE")]
    //	public string A001SEGUNDO_NOMBRE { get; set; }
    //	[XmlElement(ElementName = "A008CEDULA")]
    //	public string A008CEDULA { get; set; }
    //	[XmlElement(ElementName = "A008ROSTRO")]
    //	public string A008ROSTRO { get; set; }
    //	[XmlElement(ElementName = "A008HUELLA")]
    //	public string A008HUELLA { get; set; }
    //	[XmlElement(ElementName = "A008FIRMA")]
    //	public string A008FIRMA { get; set; }
    //	[XmlAttribute(AttributeName = "id", Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    //	public string Id { get; set; }
    //	[XmlAttribute(AttributeName = "rowOrder", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
    //	public string RowOrder { get; set; }
    //}

    //[XmlRoot(ElementName = "NewDataSet")]
    //public class NewDataSet
    //{
    //	[XmlElement(ElementName = "Table1")]
    //	public Table1 Table1 { get; set; }
    //	[XmlAttribute(AttributeName = "xmlns")]
    //	public string Xmlns { get; set; }
    //}

    //[XmlRoot(ElementName = "diffgram", Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    //public class Diffgram
    //{
    //	[XmlElement(ElementName = "NewDataSet")]
    //	public NewDataSet NewDataSet { get; set; }
    //	[XmlAttribute(AttributeName = "msdata", Namespace = "http://www.w3.org/2000/xmlns/")]
    //	public string Msdata { get; set; }
    //	[XmlAttribute(AttributeName = "diffgr", Namespace = "http://www.w3.org/2000/xmlns/")]
    //	public string Diffgr { get; set; }
    //}

    // NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false)]
    public partial class diffgram
    {

        private NewDataSet newDataSetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public NewDataSet NewDataSet
        {
            get
            {
                return this.newDataSetField;
            }
            set
            {
                this.newDataSetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private NewDataSetTable1 table1Field;

        /// <remarks/>
        public NewDataSetTable1 Table1
        {
            get
            {
                return this.table1Field;
            }
            set
            {
                this.table1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class NewDataSetTable1
    {

        private uint a001NUM_IDENTIFICACIONField;

        private string a001PRIMER_APELLIDOField;

        private string a001SEGUNDO_APELLIDOField;

        private string a001PRIMER_NOMBREField;

        private string a001SEGUNDO_NOMBREField;

        private byte a008CEDULAField;

        private byte a008ROSTROField;

        private byte a008HUELLAField;

        private byte a008FIRMAField;

        private string idField;

        private byte rowOrderField;

        /// <remarks/>
        public uint A001NUM_IDENTIFICACION
        {
            get
            {
                return this.a001NUM_IDENTIFICACIONField;
            }
            set
            {
                this.a001NUM_IDENTIFICACIONField = value;
            }
        }

        /// <remarks/>
        public string A001PRIMER_APELLIDO
        {
            get
            {
                return this.a001PRIMER_APELLIDOField;
            }
            set
            {
                this.a001PRIMER_APELLIDOField = value;
            }
        }

        /// <remarks/>
        public string A001SEGUNDO_APELLIDO
        {
            get
            {
                return this.a001SEGUNDO_APELLIDOField;
            }
            set
            {
                this.a001SEGUNDO_APELLIDOField = value;
            }
        }

        /// <remarks/>
        public string A001PRIMER_NOMBRE
        {
            get
            {
                return this.a001PRIMER_NOMBREField;
            }
            set
            {
                this.a001PRIMER_NOMBREField = value;
            }
        }

        /// <remarks/>
        public string A001SEGUNDO_NOMBRE
        {
            get
            {
                return this.a001SEGUNDO_NOMBREField;
            }
            set
            {
                this.a001SEGUNDO_NOMBREField = value;
            }
        }

        /// <remarks/>
        public byte A008CEDULA
        {
            get
            {
                return this.a008CEDULAField;
            }
            set
            {
                this.a008CEDULAField = value;
            }
        }

        /// <remarks/>
        public byte A008ROSTRO
        {
            get
            {
                return this.a008ROSTROField;
            }
            set
            {
                this.a008ROSTROField = value;
            }
        }

        /// <remarks/>
        public byte A008HUELLA
        {
            get
            {
                return this.a008HUELLAField;
            }
            set
            {
                this.a008HUELLAField = value;
            }
        }

        /// <remarks/>
        public byte A008FIRMA
        {
            get
            {
                return this.a008FIRMAField;
            }
            set
            {
                this.a008FIRMAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public byte rowOrder
        {
            get
            {
                return this.rowOrderField;
            }
            set
            {
                this.rowOrderField = value;
            }
        }
    }


}
