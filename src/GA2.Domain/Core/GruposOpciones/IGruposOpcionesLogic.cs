using GA2.Application.Dto.GrupoOpciones;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IGruposOpcionesLogic
    {

        Task<Response<IEnumerable<GrupoOpcionesDto>>> ObtenerGruposOpciones();
        Task<Response<GrupoOpcionesDto>> CrearGruposOpciones(GrupoOpcionesDto grupo);

        Task<Response<GrupoOpcionesDto>> EliminarGruposOpciones(GrupoOpcionesDto grupo);
        Task<Response<GrupoOpcionesDto>> ActualizaGruposOpciones(GrupoOpcionesDto grupo);

        Task<Response<IEnumerable<OpcionesDto>>> ObtenerOpciones();
    }
}
