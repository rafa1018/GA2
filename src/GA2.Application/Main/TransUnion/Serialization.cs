using GA2.Application.Dto;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GA2.Application.Main.TU
{
    public static class Serialization
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = new UTF8Encoding(false),
                    OmitXmlDeclaration = true
                };

                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, value, ns);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static T Deserialize<T>(this T value)
        where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(value.ToString()))
                return (T)ser.Deserialize(sr);
        }

        public static DCResponse DeserializeDC(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DCResponse));

            using (StringReader sr = new StringReader(xml))
                return (DCResponse)ser.Deserialize(sr);
        }

        public static ApplicationData DeserializeRC(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ApplicationData));

            using (StringReader sr = new StringReader(xml))
                return (ApplicationData)ser.Deserialize(sr);
        }
        public static ExamDetails DeserializeED(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ExamDetails));

            using (StringReader sr = new StringReader(xml))
                return (ExamDetails)ser.Deserialize(sr);
        }
        public static Applicants DeserializeApps(string xml)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Applicants));

            using (StringReader sr = new StringReader(xml))
                return (Applicants)ser.Deserialize(sr);
        }

    }
}
