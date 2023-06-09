﻿// <auto-generated />
using System;
using AppNotificactions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppNotificactions.Migrations
{
    [DbContext(typeof(DatosDataContext))]
    partial class DatosDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("AppNotificactions.Data.Datos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Msg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Datos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaEnvio = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Msg = "Texto de prueba",
                            Titulo = "Titulo de prueba",
                            TopicId = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaEnvio = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Msg = "Texto de prueba",
                            Titulo = "Titulo de prueba",
                            TopicId = 2
                        });
                });

            modelBuilder.Entity("AppNotificactions.Data.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Topic", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "test"
                        },
                        new
                        {
                            Id = 2,
                            Name = "prueba"
                        });
                });

            modelBuilder.Entity("AppNotificactions.Data.Datos", b =>
                {
                    b.HasOne("AppNotificactions.Data.Topic", "Topic")
                        .WithMany("Datos")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("AppNotificactions.Data.Topic", b =>
                {
                    b.Navigation("Datos");
                });
#pragma warning restore 612, 618
        }
    }
}
