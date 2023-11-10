using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubikBook.Database.Context;

namespace RubikBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ProductApiController(DatabaseContext context)
        {
            _context = context;
        }



        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var productTitle = _context.Products.Where(p => p.ProductName.Contains(term)).Select(p => p.ProductName).ToList();

                return Ok(productTitle);
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
