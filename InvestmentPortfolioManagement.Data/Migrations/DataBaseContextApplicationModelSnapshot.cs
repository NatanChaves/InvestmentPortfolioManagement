﻿// <auto-generated />
using System;
using InvestmentPortfolioManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvestmentPortfolioManagement.Data.Migrations
{
    [DbContext(typeof(DataBaseContextApplication))]
    partial class DataBaseContextApplicationModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvestmentPortfolioManagement.Data.Entities.FundoImobiliario", b =>
                {
                    b.Property<int>("FundoImobiliarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoNegociacao")
                        .HasColumnType("int");

                    b.Property<int>("CorretoraExcutora")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFundo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("FundoImobiliarioId");

                    b.ToTable("FundosImobiliarios");
                });

            modelBuilder.Entity("InvestmentPortfolioManagement.Data.Entities.Investimento", b =>
                {
                    b.Property<int>("InvestimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCliente")
                        .HasColumnType("int");

                    b.Property<int>("CorretoraExcutora")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FundoImobiliarioId")
                        .HasColumnType("int");

                    b.Property<string>("NomeFundo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("InvestimentoId");

                    b.HasIndex("FundoImobiliarioId")
                        .IsUnique();

                    b.ToTable("Investimentos");
                });

            modelBuilder.Entity("InvestmentPortfolioManagement.Data.Entities.Investimento", b =>
                {
                    b.HasOne("InvestmentPortfolioManagement.Data.Entities.FundoImobiliario", "FundoImobiliario")
                        .WithOne("Investimento")
                        .HasForeignKey("InvestmentPortfolioManagement.Data.Entities.Investimento", "FundoImobiliarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
