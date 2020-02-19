﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlnVivero.Infra.Data;

namespace SlnVivero.Infra.Migrations
{
    [DbContext(typeof(ViveroContext))]
    [Migration("20200206135811_MigrationInitialVivero")]
    partial class MigrationInitialVivero
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlnVivero.Core.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Picture");

                    b.Property<bool>("State");

                    b.Property<DateTime>("Updated");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("VentaId");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("DateToBuy");

                    b.Property<int>("DetalleVentaId");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Prices")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity");

                    b.HasKey("VentaId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("DetalleVentas");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Picture");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<bool>("State");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UnitsInStock");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("NameRol");

                    b.Property<bool>("State");

                    b.HasKey("RolId");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres");

                    b.Property<int>("CellPhone");

                    b.Property<DateTime>("Created");

                    b.Property<int>("DNI");

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int?>("RolId");

                    b.Property<bool>("State");

                    b.Property<DateTime>("Updated");

                    b.HasKey("UserId");

                    b.HasIndex("RolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.Venta", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateToBuy");

                    b.Property<bool>("State");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalToPay")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("UserId");

                    b.Property<string>("VoucherNumber");

                    b.Property<string>("VoucherSeries");

                    b.Property<string>("VoucherType");

                    b.HasKey("VentaId");

                    b.HasIndex("UserId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.DetalleVenta", b =>
                {
                    b.HasOne("SlnVivero.Core.Entities.Product", "Product")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SlnVivero.Core.Entities.Venta", "Venta")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.Product", b =>
                {
                    b.HasOne("SlnVivero.Core.Entities.Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.User", b =>
                {
                    b.HasOne("SlnVivero.Core.Entities.Rol")
                        .WithMany("Users")
                        .HasForeignKey("RolId");
                });

            modelBuilder.Entity("SlnVivero.Core.Entities.Venta", b =>
                {
                    b.HasOne("SlnVivero.Core.Entities.User")
                        .WithMany("Ventas")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}