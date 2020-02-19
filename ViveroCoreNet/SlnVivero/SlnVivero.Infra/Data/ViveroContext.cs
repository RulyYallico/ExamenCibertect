using Microsoft.EntityFrameworkCore;
using SlnVivero.Core.Entities;
using SlnVivero.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Infra.Data
{
    public class ViveroContext : DbContext, IViveroContext
    {
        public ViveroContext(DbContextOptions<ViveroContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuración del modelo con Fluent API
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.ProductName) // para la columna product name
            //    .HasMaxLength(300)
            //    .IsRequired() // que sea not null
            //    .HasColumnType("varchar(300)") // el tipo de datos en BD
            //    .HasColumnName("p_name"); // personalizar el nombre de la columna


            // configurar una relación de muchos a muchos
            // modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });

            // Config Detalle de venta (relacion de muchos a muchos)
            modelBuilder.Entity<DetalleVenta>().HasKey(vp => new {vp.VentaId, vp.ProductId });

            // configurar la precisión para el campo UnitPrice de Product
            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(10,2)");

            // product name sea requerido
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired();

            // Config Venta
            modelBuilder.Entity<Venta>()
                .Property(v => v.Tax)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Venta>()
                .Property(v => v.TotalToPay)
                .HasColumnType("decimal(10,2)");

            // Config Detalle de venta
            modelBuilder.Entity<DetalleVenta>()
                .Property(dv => dv.Prices)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<DetalleVenta>()
                .Property(dv => dv.Discount)
                .HasColumnType("decimal(10,2)");
        }

        public int Commit()
        {
            return SaveChanges();
        }

        public bool Migrate()
        {
            try
            {
                Database.Migrate();
                return true;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        // agregar los db set que serán las tablas que se crearán en la BD
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        // public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
    }
}
