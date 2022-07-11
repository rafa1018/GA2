using AplicarPago.Extensions;
using Microsoft.Extensions.Hosting;

namespace ConsultarTasasSimulacion
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services => {
                    services.AddServicesDependencies();
                })
                .Build();

            host.Run();
        }
    }
}