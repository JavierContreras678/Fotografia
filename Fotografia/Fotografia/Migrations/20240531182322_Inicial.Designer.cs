﻿// <auto-generated />
using Fotografia.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fotografia.Migrations
{
    [DbContext(typeof(FotografiaDBContext))]
    [Migration("20240531182322_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fotografia.Modelos.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OpcionId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OpcionId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("Fotografia.Modelos.Opcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicioId");

                    b.ToTable("Opciones");
                });

            modelBuilder.Entity("Fotografia.Modelos.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaPedido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Fotografia.Modelos.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Fotografia.Modelos.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Fotografia.Modelos.Carrito", b =>
                {
                    b.HasOne("Fotografia.Modelos.Opcion", "Opcion")
                        .WithMany()
                        .HasForeignKey("OpcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fotografia.Modelos.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fotografia.Modelos.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Opcion");

                    b.Navigation("Pedido");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Fotografia.Modelos.Opcion", b =>
                {
                    b.HasOne("Fotografia.Modelos.Servicio", "Servicio")
                        .WithMany("Opciones")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Fotografia.Modelos.Pedido", b =>
                {
                    b.HasOne("Fotografia.Modelos.Persona", "Persona")
                        .WithMany("Pedidos")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Fotografia.Modelos.Persona", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Fotografia.Modelos.Servicio", b =>
                {
                    b.Navigation("Opciones");
                });
#pragma warning restore 612, 618
        }
    }
}
