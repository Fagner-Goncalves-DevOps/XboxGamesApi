﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations.SqlDb
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(185)
                        .HasColumnType("varchar(185)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("ProdutoGeneroId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoTipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoGeneroId");

                    b.HasIndex("ProdutoTipoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Core.Entities.ProdutoGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProdutoGenero");
                });

            modelBuilder.Entity("Core.Entities.ProdutoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProdutoTipo");
                });

            modelBuilder.Entity("Core.Entities.Produto", b =>
                {
                    b.HasOne("Core.Entities.ProdutoGenero", "ProdutoGenero")
                        .WithMany()
                        .HasForeignKey("ProdutoGeneroId")
                        .IsRequired();

                    b.HasOne("Core.Entities.ProdutoTipo", "ProdutoTipo")
                        .WithMany()
                        .HasForeignKey("ProdutoTipoId")
                        .IsRequired();

                    b.Navigation("ProdutoGenero");

                    b.Navigation("ProdutoTipo");
                });
#pragma warning restore 612, 618
        }
    }
}