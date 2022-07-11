using GA2.GA2Functions.Extensions;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GA2.GA2Functions
{
    public class Program
    {
        public static void Main()
        {
            IConfiguration configuration = null;
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
                .ConfigureOpenApi()
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var configurationRoot = builder.AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables().Build();
                    configuration = configurationRoot;
                })
                .ConfigureServices(x =>
                {
                    x.AddServicesDependencies();
                    x.AddGlobalSettinsOptions(configuration);
                })
                .Build();

            host.Run();
        }
    }
}