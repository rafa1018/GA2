using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Form submodule
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class FormDto : BaseEntity
    {
        public string DESCRIPTION { get; set; }
        public IEnumerable<PropertyDto> PROPERTIES { get; set; }
        public Guid SUBMODULEID { get; set; }
        public bool VISIBLE { get; set; }

    }
}
