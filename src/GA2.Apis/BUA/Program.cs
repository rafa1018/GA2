using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GA2.Apis.BUA
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creacion del host de servicios
        /// </summary>
        /// <param name="args">Argumentos de entrada</param>
        /// <author>Edgar Andrés Riaño</author>
        /// <date>26/02/2021</date>
        /// <returns>Host</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
