﻿using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration.Base
{
    internal abstract class MediaFileMappingConfiguration<T> : EntityMappingConfiguration<T> where T : class, IMediaFile, new()
    {
        protected override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);


            builder.Property(mediaFile => mediaFile.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(mediaFile => mediaFile.Extension)
                .IsRequired()
                .HasMaxLength(16);
        }

        protected MediaFileMappingConfiguration(ModelBuilder modelBuilder) : base(modelBuilder){}
    }
}
