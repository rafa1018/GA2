using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Property of form 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class PropertyDto
    {
        public Guid FORMID { get; set; }
        public Guid ID { get; set; }
        public string DESCRIPTION { get; set; }
        public bool EDIT { get; set; }
        public bool VISIBLE { get; set; }
    }
}
