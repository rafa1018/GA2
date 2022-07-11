using GA2.Transversals.Commons;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Table Module app
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>23/03/2021</date>
    public class ModuleDto : BaseEntity
    {
        public string DESCRIPTION { get; set; }
        public bool VISIBLE { get; set; }
        public IEnumerable<SubModuleDto> SUBMODULES { get; set; }
    }
}
