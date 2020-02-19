﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlnVivero.Core.Entities;
using SlnVivero.Core.Interfaces;

namespace SlnVivero.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IViveroContext _context;
        private readonly IProductService _productService;

        public ProductController(IViveroContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet("ListAll")]
        public ActionResult ObtenerTodos()
        {
            return Ok(_productService.ObtenerPrimeros2Productos());
        }

        [HttpGet("{productId}")]
        public ActionResult ObtenerPorId(int ProductId)
        {
            return Ok(_context.Products.Find(ProductId));
        }

        [HttpPost]
        public ActionResult Insertar(Product request)
        {
            var registroCorrecto = _productService.RegistrarProducto(request);
            if (!registroCorrecto)
            {
                return BadRequest("Ocurrió un error con la solicitud enviada");
            }
            return Ok("se registró el producto satisfactoriamente");
        }


        [HttpPut]
        public ActionResult Actualizar(Product product)
        {
            Product productoExistente = null;
            try
            {
                // obtener el producto de BD
                productoExistente = _context.Products.Find(product.ProductId);
            }
            catch (System.Exception)
            {
                return BadRequest("No se pudo obtener la información del producto existente");
            }


            // si no existe, devolver un error
            if (productoExistente == null)
            {
                return BadRequest("El producto no existe");
            }

            productoExistente.ProductName = product.ProductName == null ? productoExistente.ProductName : product.ProductName;
            // productoExistente.Discontinued = product.Discontinued;
            productoExistente.State = product.State;
            productoExistente.UnitPrice = product.UnitPrice;
            productoExistente.UnitsInStock = product.UnitsInStock;

            try
            {
                var resultado = _context.Commit();

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                // log del error (ex)
                return BadRequest("Ocurrió un error al tratar de grabar en BD");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            // obtener la entidad que se quiere eliminar
            var productoAEliminar = _context.Products.Find(id);
            if (productoAEliminar == null)
            {
                return BadRequest("El producto no existe");
            }

            _context.Products.Remove(productoAEliminar);

            return Ok(_context.Commit());
        }

    }
}