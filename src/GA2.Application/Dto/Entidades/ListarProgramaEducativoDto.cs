using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Programa Educativa Dto
    /// </summary>
    public class ListarProgramaEducativoDto
    {
        public Guid IdEntidad { get; set; }
        public string RazonSocialEntidad { get; set; }
        public Guid IdPrograma { get; set; }
        public string Programa { get; set; }
        public Guid NivelEducativoId { get; set; }
        public string NivelEducativo { get; set; }

    }
}
