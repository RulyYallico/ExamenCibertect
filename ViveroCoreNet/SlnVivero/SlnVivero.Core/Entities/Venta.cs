using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string VoucherType { get; set; }
        public string VoucherSeries { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime DateToBuy { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalToPay { get; set; }
        public bool State { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }

    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Prices { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateToBuy { get; set; }
    }
}
