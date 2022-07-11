using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class AttachRequestDto
    {
        public string Radicado { get; set; }
        public List<FileDto> Files { get; set; }
        public string UserOperation { get; set; }
    }
}
