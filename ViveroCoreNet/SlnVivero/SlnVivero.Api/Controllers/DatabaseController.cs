using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlnVivero.Core.Interfaces;

namespace SlnVivero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {

        private readonly IViveroContext _viveroContext;
        public DatabaseController(IViveroContext viveroContext)
        {
            _viveroContext = viveroContext;
        }

        [HttpGet("migrar")]
        [HttpGet("migrar2")]
        [HttpGet("migrar3")]
        [HttpGet("migrar123")]
        public string Migrar()
        {
            _viveroContext.Migrate();
            return "Migración Existosa.";
        }
    }
}