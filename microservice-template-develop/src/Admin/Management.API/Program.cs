#region

using Autofac.Extensions.DependencyInjection;
using Microservices.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

#endregion

namespace Management.API
{
    /// <summary>
    ///     Create and run a web host
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        ///     Create a host builder
        /// </summary>
        /// <param name="args">Params from command lines</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                       .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        /// <summary>
        ///     Entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build().Run();
        }

        #endregion
    }
}