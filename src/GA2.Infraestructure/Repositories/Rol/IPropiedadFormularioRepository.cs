using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IPropiedadFormularioRepository
    {
        Task<PropiedadFormulario> ActualizarPropiedadFormulario(PropiedadFormulario propiedadFormulario);
        Task<PropiedadFormulario> CrearPropiedadFormulario(PropiedadFormulario propiedadFormulario);
        Task<PropiedadFormulario> EliminarPropiedadFormulario(PropiedadFormulario propiedadFormulario);
        Task<IEnumerable<PropiedadFormulario>> ObtenerPropiedadesFormularioPorFormularioId(Guid propiedadFormulario);
    }
}