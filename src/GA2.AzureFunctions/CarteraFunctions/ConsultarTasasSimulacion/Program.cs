using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using ConsultarTasasSimulacion.Extensions;

namespace ConsultarTasasSimulacion
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddServicesDependencies();
                })
                .Build();

            host.Run();
        }
    }
}