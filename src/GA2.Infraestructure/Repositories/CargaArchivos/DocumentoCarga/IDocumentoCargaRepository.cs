using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IDocumentoCargaRepository
    {
        Task<Documento> ActualizarDocumentoCarga(Documento documentoCarga);
        Task<Documento> CambiarEstadoAProcesar(int documentoId);
        Task<Documento> CrearDocumentoCarga(Documento documentoCarga);
        Task<IEnumerable<Documento>> ObtenerDocumentosCarga(int esdId);
        Task<Documento> ObtenerDocumentosPorId(int documentoId);
    }
}