﻿using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompraRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemDTO itemDTO)
        {
            try
            {
                Carrinho car = new Carrinho();
                car = itemDTO;

                var carrinho = await _appDbContext.Carrinho.Add(itemDTO);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidade carrinhoItemAtualiza)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> DeletaItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarrinhoItem>> GetItems(string usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
