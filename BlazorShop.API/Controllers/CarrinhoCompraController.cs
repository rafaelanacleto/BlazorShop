using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ILogger<CarrinhoCompraController> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;

        public CarrinhoCompraController(ILogger<CarrinhoCompraController> logger, IProdutoRepository produtoRepository, ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }

        [HttpGet]
        [Route("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDTO>>> GetItens(int usuarioId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.GetItems(usuarioId);
                if (carrinhoItens == null)
                {
                    return NoContent(); //204 status code
                }

                var produtos = await _produtoRepository.GetAll() ?? throw new Exception("Não existe produtos ....");

                var carrinhosItensDTO = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItens);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       
    }
}