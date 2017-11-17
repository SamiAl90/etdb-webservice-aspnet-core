using ETDB.API.WebService.Data.Configuration.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration
{
    internal class ErrorLogConfiguration : LogInfoMappingConfiguration<ErrorLog>
    {
        public ErrorLogConfiguration(ModelBuilder modelBuilder) : base(modelBuilder){}

        protected override void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            base.Configure(builder);

            //builder.ToTable($"{nameof(ErrorLog)}s");

            builder.Property(errorLog => errorLog.Message)
                .IsRequired()
                .HasMaxLength(4096);
        }
    }
}
