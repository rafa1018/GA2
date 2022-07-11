using IdentityFunctions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GA2.IdentityFunctions
{
    public class Program
    {
        public static void Main(string[] args)
        {
             IConfiguration configuration = null;
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                   var configurationRoot =  builder.AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables().Build();
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