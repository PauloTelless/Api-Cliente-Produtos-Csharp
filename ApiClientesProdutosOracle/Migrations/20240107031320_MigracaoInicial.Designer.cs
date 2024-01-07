﻿// <auto-generated />
using System;
using ApiClientesProdutosOracle.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiClientesProdutosOracle.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240107031320_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiClientesProdutosOracle.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiClientesProdutosOracle.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR2(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ApiClientesProdutosOracle.Models.Produto", b =>
                {
                    b.HasOne("ApiClientesProdutosOracle.Models.Cliente", "Clientes")
                        .WithMany("Produtos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("ApiClientesProdutosOracle.Models.Cliente", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
