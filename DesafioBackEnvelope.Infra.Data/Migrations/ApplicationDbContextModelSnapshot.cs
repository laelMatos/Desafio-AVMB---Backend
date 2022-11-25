﻿// <auto-generated />
using System;
using DesafioBackEnvelope.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioBackEnvelope.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioBackEnvelope.Domain.DadosEnvelope", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("Envelope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dataEnvioAgendado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataHoraCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoContratado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoContratante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hashSHA256")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hashSHA512")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("horaEnvioAgendado")
                        .HasColumnType("datetime2");

                    b.Property<int>("idRepositorio")
                        .HasColumnType("int");

                    b.Property<int>("idUsuário")
                        .HasColumnType("int");

                    b.Property<string>("incluirHashTodasPaginas")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("mensagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mensagemObservadores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("motivoCancelamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroPaginas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objetoContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permitirDespachos")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<byte>("status")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("statusContrato")
                        .HasColumnType("tinyint");

                    b.Property<string>("usarOrdem")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("id");

                    b.ToTable("Envelope", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
