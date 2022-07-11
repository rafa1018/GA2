using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Fields")]
    public class Fields
    {
        [XmlElement(ElementName = "Field")]
        public List<Field> Field { get; set; }

        public void Add(Field field)
        {
            Field.Append(field);
        }

        public bool Any()
        {
            if (Field.Any())
                return true;
            else
                return false;
        }
    }
}