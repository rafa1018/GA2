using GA2.Domain.Entities;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Interface que expone los metodos paramtrizacion parametros repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>27/04/2021</date>
    public interface IParamCargueNominaRepository
    {
        Task<ParamCargueNom> ObtenerParametrosCargueNomina(int id);
    }
}