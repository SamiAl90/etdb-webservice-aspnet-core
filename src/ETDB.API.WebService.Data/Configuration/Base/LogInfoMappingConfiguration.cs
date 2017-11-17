using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration.Base
{
    internal abstract class LogInfoMappingConfiguration<T> : EntityMappingConfiguration<T> where T : class, ILogInfo, new()
    {
        protected LogInfoMappingConfiguration(ModelBuilder modelBuilder) : base(modelBuilder){}

        protected override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(errorLog => errorLog.Path)
                .IsRequired();
            builder.Property(errorLog => errorLog.HttpMethod)
                .IsRequired();
            builder.Property(errorLog => errorLog.TraceId)
                .IsRequired();
        }
    }
}
