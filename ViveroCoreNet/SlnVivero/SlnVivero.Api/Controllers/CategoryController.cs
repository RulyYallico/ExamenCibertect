using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlnVivero.Core.Interfaces;

namespace SlnVivero.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IViveroContext _context;
        private readonly IProductService _productService;

        public CategoryController(IViveroContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet("ListAll")]
        public ActionResult ObtenerTodos()
        {
            return Ok(_context.Categories);
        }
    }
}