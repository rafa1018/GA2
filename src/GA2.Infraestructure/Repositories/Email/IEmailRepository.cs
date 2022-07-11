using GA2.Domain.Entities.Email;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IEmailRepository
    {
        Task<bool> EnviarEmail(EmailModel email);
        Task<EmailModel> GuardarCorreo(EmailModel email);
    }
}