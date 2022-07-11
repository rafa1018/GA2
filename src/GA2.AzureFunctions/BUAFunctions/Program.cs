using BUAFunctions.Extensions;
using IdentityFunctions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BUAFunctions
{
    public class Program
    {
        public static void Main()
        {
            IConfiguration configuration = null;
            var host = new HostBuilder()

                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var configurationRoot = builder.AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables().Build();
                    configuration = configurationRoot;
                })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(x =>
                {
                    x.AddServicesDependencies();
                    x.AddJwtDocumentation(configuration);
                    x.AddGlobalSettinsOptions(configuration);
                })
                .Build();

            host.Run();
        }
    }
}