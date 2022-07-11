using Microsoft.Extensions.Hosting;
using ObtenerProductoCliente.Extensions;

namespace ObtenerProductoCliente
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