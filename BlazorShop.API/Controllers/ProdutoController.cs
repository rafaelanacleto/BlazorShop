using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProdutoController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            try
            {
                IEnumerable<Produtos> produtos = _db.Produtos.ToList();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}