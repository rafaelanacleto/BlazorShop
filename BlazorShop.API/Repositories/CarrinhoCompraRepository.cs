using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompraRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDTO itemDTO)
        {
            
            if(await CarrinhoItemJaExiste(itemDTO.CarrinhoId, itemDTO.ProdutoId) == false)
            {
                //verifica se o produto existe e cria um novo item no carrinho
                var item = await (from produto in _appDbContext.Produtos
                                  where produto.Id == itemDTO.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = itemDTO.CarrinhoId,
                                      ProdutoId = produto.Id,
                                      Quantidade = itemDTO.Quantidade,
                                  }).SingleOrDefaultAsync();

                //se o item existe então incluir item no carrinho 
                if (item is not null)
                {
                    var result = await _appDbContext.CarrinhoItem.AddAsync(item);
                    await _appDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;

        }

        private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, int produtoId)
        {
            return await _appDbContext.CarrinhoItem.AnyAsync(c => c.CarrinhoId == carrinhoId && c.ProdutoId == produtoId);
        }

        public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidade carrinhoItemAtualiza)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> DeletaItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoItem> GetItem(int id)
        {
            return await (from carrinhoItem in _appDbContext.CarrinhoItem
                          where carrinhoItem.Id == id
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarrinhoItem>> GetItems(int usuarioId)
        {
            return await (from carrinho in _appDbContext.Carrinho
                          join carrinhoItem in _appDbContext.CarrinhoItem
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).ToListAsync();
        }
    }
}
