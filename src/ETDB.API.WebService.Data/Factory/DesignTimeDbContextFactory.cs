using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ETDB.API.WebService.Data.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebServiceContext>
    {
        public WebServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var context = new WebServiceContext(configuration);
            return context;
        }
    }
}
