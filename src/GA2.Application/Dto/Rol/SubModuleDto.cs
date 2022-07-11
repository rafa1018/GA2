using GA2.Transversals.Commons;
using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Submodule menu app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class SubModuleDto : BaseEntity
    {
        public Guid MODULEID { get; set; }
        public ModuleDto MODULE { get; set; }
        public string DESCRIPTION { get; set; }
        public bool VISIBLE { get; set; }
        public FormDto FORM { get; set; }
    }
}
