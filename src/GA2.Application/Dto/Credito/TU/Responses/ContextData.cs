using GA2.Application.Dto.Credito.TU.Requests;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "ContextData")]
    public class ContextData
    {
        [XmlElement(ElementName = "Field")]
        //public IEnumerable<Field> Field { get; set; }
        public List<Field> Field { get; set; }
    }
}
