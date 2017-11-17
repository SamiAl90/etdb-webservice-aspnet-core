using ETDB.API.WebService.Data.Configuration.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration
{
    internal class MovieFileConfiguration : MediaFileMappingConfiguration<MovieFile>{
        public MovieFileConfiguration(ModelBuilder modelBuilder) : base(modelBuilder){}

        protected override void Configure(EntityTypeBuilder<MovieFile> builder)
        {
            base.Configure(builder);
        }
    }
}
