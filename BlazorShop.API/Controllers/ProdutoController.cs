using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoRepository _productService;

        public ProdutoController(AppDbContext db, ILogger<ProdutoController> logger, IProdutoRepository produtoRepository)
        {
            _db = db;
            _logger = logger;
            _productService = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            try
            {
                var produtos = await _productService.GetAll();

                if (produtos == null)
                {
                    return NotFound();
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProdutosById(int id)    
        {
            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}