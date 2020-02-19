using Microsoft.EntityFrameworkCore;
using SlnVivero.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Interfaces
{
    public interface IViveroContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        //DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Rol> Rols { get; set; }
        DbSet<Venta> Ventas { get; set; }
        DbSet<DetalleVenta> DetalleVentas { get; set; }
        /// <summary>
        /// Internamente este método invocará el método SaveChanges del contexto
        /// </summary>
        /// <returns></returns>
        int Commit();
        /// <summary>
        /// Método para migrar la BD
        /// </summary>
        /// <returns></returns>
        bool Migrate();
    }
}
