using SlnVivero.Core.Entities;
using SlnVivero.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlnVivero.Core.Services
{
    public class ProductService : IProductService
    {
        // campo para utilizar el contexto
        private readonly IViveroContext _viveroContext;

        public ProductService(IViveroContext viveroContext)
        {
            _viveroContext = viveroContext;
        }

        public List<Product> ObtenerPrimeros2Productos()
        {
            return _viveroContext.Products.ToList();
        }

        public bool RegistrarProducto(Product nuevoProducto)
        {
            // validaciones
            if (string.IsNullOrEmpty(nuevoProducto.ProductName))
            {
                return false;
            }


            // fluent syntax 
            var productsWithSameName = _viveroContext.Products.Where(p => p.ProductName.ToUpper() == nuevoProducto.ProductName.ToUpper());

            if (productsWithSameName.Count() > 0)
            {
                // significa que existen productos registrados que tienen el mismo nombre que el que se desea registrar
                return false;
            }


            // agregar el proucto a BD
            _viveroContext.Products.Add(nuevoProducto);

            return _viveroContext.Commit() > 0;
        }
    }
}
