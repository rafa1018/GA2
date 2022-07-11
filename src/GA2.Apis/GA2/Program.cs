using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GA2.Apis.GA2
{
    /// <summary>
    /// Progrma GA2 API
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Metodo de entrada
        /// </summary>
        /// <param name="args"></param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>07/03/2021</date>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create host application
        /// </summary>
        /// <param name="args"></param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>08/03/2021</date>
        /// <returns>Host services</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
