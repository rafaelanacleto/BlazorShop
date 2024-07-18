using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        public Task<CarrinhoItem> AdicionaItem(CarrinhoItemDTO itemDTO)
        {
            throw new NotImplementedException();
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
