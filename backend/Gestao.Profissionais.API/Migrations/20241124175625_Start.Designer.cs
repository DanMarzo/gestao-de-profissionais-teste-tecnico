﻿// <auto-generated />
using System;
using Gestao.Profissionais.API.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestao.Profissionais.API.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20241124175625_Start")]
    partial class Start
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Gestao.Profissionais.API.Domain.EspecialidadeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("especialidades_pk");

                    b.ToTable("especialidades", (string)null);
                });

            modelBuilder.Entity("Gestao.Profissionais.API.Domain.ProfissionalEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<long>("EspecialidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("profissional_pk");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("profissionais", (string)null);
                });

            modelBuilder.Entity("Gestao.Profissionais.API.Domain.ProfissionalEntity", b =>
                {
                    b.HasOne("Gestao.Profissionais.API.Domain.EspecialidadeEntity", "Especialidade")
                        .WithMany("Profissionais")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("Gestao.Profissionais.API.Domain.EspecialidadeEntity", b =>
                {
                    b.Navigation("Profissionais");
                });
#pragma warning restore 612, 618
        }
    }
}