﻿using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETDB.API.WebService.Data.Configuration
{
    internal class ActorConfiguration : EntityMappingConfiguration<Actor>
    {
        protected override void Configure(EntityTypeBuilder<Actor> builder)
        {
            base.Configure(builder);

            builder.Property(actor => actor.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(actor => actor.LastName)
                .HasMaxLength(128)
                .IsRequired();
        }

        public ActorConfiguration(ModelBuilder modelBuilder) : base(modelBuilder){}
    }
}
