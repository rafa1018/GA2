using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class FormularioCreditoBasicaDto
    {

        public List<TipoIdentificacionDto> TiposIdentificacion { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; }
        public List<FuerzasDto> Fuerzas { get; set; }
        public List<CategoriaDto> Categorias { get; set; }
        public List<SexoDto> Sexos { get; set; }
        public List<EstadoCivilDto> EstadosCiviles { get; set; }
        public List<NivelAcademicoCatalogoDto> NivelesAcademicos { get; set; }
        public List<ProfesionDto> Profeciones { get; set; }
        public RespuestaCreditoBasicaDto CreditoBasica { get; set; }
     

    }
}
