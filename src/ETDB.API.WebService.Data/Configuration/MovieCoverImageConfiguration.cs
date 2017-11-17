using ETDB.API.WebService.Data.Configuration.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration
{
    internal class MovieCoverImageConfiguration : MediaFileMappingConfiguration<MovieCoverImage>
    {

        public MovieCoverImageConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void Configure(EntityTypeBuilder<MovieCoverImage> builder)
        {
            base.Configure(builder);

            //builder.ToTable($"{nameof(MovieCoverImage)}s");
        }
    }
}
