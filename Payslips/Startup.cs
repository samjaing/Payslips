using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payslips.Model;
using Payslips.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Payslips
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IServiceProvider provider;

        public IServiceProvider Provider => provider;
        public IConfiguration Configuration => configuration;
        public Startup()
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              //              .AddJsonFile($"appsettings.{environment}.json", optional: true)
                //            .AddEnvironmentVariables()
                            .Build();

            var services = new ServiceCollection();

            // add necessary services
            services.AddSingleton(configuration);
            services.AddSingleton<ITaxCalculator, TaxCalculator>();
            // build the pipeline

            provider = services.BuildServiceProvider();
        }
  
    }
}
