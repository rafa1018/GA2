using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GA2.Apis.Identity
{
    /// <summary>
    /// Programa Inicio GA2
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Metodo de entrada principal GA2
        /// </summary>
        /// <param name="args">Argumentos de entrada</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>19/02/2021</date>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creacion del host de servicios
        /// </summary>
        /// <param name="args">argumentos de entrada</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>19/02/2021</date>
        /// <returns>Host</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
