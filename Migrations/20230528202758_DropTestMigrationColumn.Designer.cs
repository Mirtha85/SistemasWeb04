﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemasWeb01.Models;

#nullable disable

namespace SistemasWeb01.Migrations
{
    [DbContext(typeof(BdContexTiendaTecnoBoliviaSc))]
    [Migration("20230528202758_DropTestMigrationColumn")]
    partial class DropTestMigrationColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("SistemasWeb01.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionCategoria")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoriasdbcontex");
                });

            modelBuilder.Entity("SistemasWeb01.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagenProducto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecioProducto")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productosdbcontex");
                });

            modelBuilder.Entity("SistemasWeb01.Models.Producto", b =>
                {
                    b.HasOne("SistemasWeb01.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SistemasWeb01.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
