using System;
using System.Linq;
using ETDB.API.WebService.Data.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ETDB.API.WebService.Data
{
    public class WebServiceContext : DbContext
    {
        private readonly IConfigurationRoot configurationRoot;
        private const string Production = "Production";
        private const string Development = "Development";

        public WebServiceContext(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                                  WebServiceContext.Development;

            optionsBuilder.UseSqlServer(environmentName
                .Equals(WebServiceContext.Development, StringComparison.OrdinalIgnoreCase)
                ? this.configurationRoot.GetConnectionString(WebServiceContext.Development)
                : environmentName
                    .Equals(WebServiceContext.Production, StringComparison.OrdinalIgnoreCase)
                    ? this.configurationRoot.GetConnectionString(WebServiceContext.Production)
                    : throw new ArgumentException(nameof(environmentName)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ActionLogConfiguration(modelBuilder)
                .ConfigureEntity();

            new ErrorLogConfiguration(modelBuilder)
                .ConfigureEntity();

            new MovieConfiguration(modelBuilder)
                .ConfigureEntity();

            new MovieCoverImageConfiguration(modelBuilder)
                .ConfigureEntity();

            new MovieFileConfiguration(modelBuilder)
                .ConfigureEntity();

            new ActorConfiguration(modelBuilder)
                .ConfigureEntity();

            new MovieActorConfiguration(modelBuilder)
                .ConfigureEntity();

            this.DisableCascadeDelete(modelBuilder);
        }

        private void DisableCascadeDelete(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(entity => entity.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
