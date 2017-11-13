﻿// <auto-generated />
using EntertainmentDatabase.REST.API.WebService.Data;
using EntertainmentDatabase.REST.API.WebService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EntertainmentDatabase.REST.API.WebService.Data.Migrations
{
    [DbContext(typeof(EntertainmentDatabaseWebServiceContext))]
    [Migration("20171113080556_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.ActionLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("HttpMethod")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("TraceEnd");

                    b.Property<string>("TraceId")
                        .IsRequired();

                    b.Property<DateTime>("TraceStart");

                    b.HasKey("Id");

                    b.ToTable("ActionLogs");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.ErrorLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("HttpMethod")
                        .IsRequired();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(4096);

                    b.Property<DateTime>("Occurrence");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("TraceId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("ConsumerMediaType");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ReleasedOn");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieActor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("ActorId");

                    b.Property<Guid>("MovieId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ActorId", "MovieId")
                        .IsUnique();

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieCoverImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<byte[]>("File");

                    b.Property<int>("MediaFileType");

                    b.Property<Guid>("MovieId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieCoverImages");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<byte[]>("File");

                    b.Property<bool>("IsCover");

                    b.Property<int>("MediaFileType");

                    b.Property<Guid>("MovieId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieFiles");
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieActor", b =>
                {
                    b.HasOne("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieCoverImage", b =>
                {
                    b.HasOne("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Movie", "Movie")
                        .WithOne("MovieCoverImage")
                        .HasForeignKey("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieCoverImage", "MovieId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EntertainmentDatabase.REST.API.WebService.Domain.Entities.MovieFile", b =>
                {
                    b.HasOne("EntertainmentDatabase.REST.API.WebService.Domain.Entities.Movie", "Movie")
                        .WithMany("MovieFiles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}