using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Entities;
using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorShop.API.Controllers
{
    [ApiController]
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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDTO>> GetItem(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.GetItem(id);

                if (carrinhoItem == null)
                {
                    return NotFound($"Item não encontrado"); // not found 404 status code
                }

                var produtos = await _produtoRepository.GetById(carrinhoItem.Id) ?? throw new Exception("Não existe produtos ....");

                var carrinhosItensDTO = carrinhoItem.ConverterCarrinhoItemParaDto(produtos);
                return Ok(carrinhosItensDTO);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDTO>> PostItem(CarrinhoItemAdicionaDto carrinho)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.AdicionaItem(carrinho);

                if (carrinhoItem == null)
                {
                    return NotFound($"Item não encontrado"); // not found 404 status code
                }

                var produtos = await _produtoRepository.GetById(carrinhoItem.Id) ?? throw new Exception("Não existe produtos ....");

                var carrinhosItensDTO = carrinhoItem.ConverterCarrinhoItemParaDto(produtos);

                return CreatedAtAction(actionName: nameof(GetItem), new { id = carrinhosItensDTO.Id }, carrinhosItensDTO);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDTO>> DeletaItem(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.DeletaItem(id);
                
                if (carrinhoItem == null)
                {
                    return NotFound();
                }

                var produto = await _produtoRepository.GetById(carrinhoItem.ProdutoId);

                if (produto is null)
                    return NotFound();

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}