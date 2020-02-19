using SlnVivero.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Interfaces
{
    public interface IProductService
    {
        List<Product> ObtenerPrimeros2Productos();
        /// <summary>
        /// Lo que hace el método
        /// </summary>
        /// <param name="nuevoProducto">El nuevo producto que se va a isnertar</param>
        /// <returns></returns>
        bool RegistrarProducto(Product nuevoProducto);

        /// <summary>
        /// Lo que hace el método
        /// </summary>
        /// <param name="categorias"></param>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        // int AgregarDetalleVenta(IList<Category> categorias, int idProducto);
    }
}
