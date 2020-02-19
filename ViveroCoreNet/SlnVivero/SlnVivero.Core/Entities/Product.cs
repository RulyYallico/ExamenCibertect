using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public string Picture { get; set; }
        public int UnitsInStock { get; set; }
        public bool State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        // esta propiedad indica la relación de muchos a muchos con Category
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
