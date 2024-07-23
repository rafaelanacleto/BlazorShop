using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDTO itemDTO);
        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidade carrinhoItemAtualiza);
        Task<CarrinhoItem> DeletaItem(int id);
        Task<CarrinhoItem> GetItem(int id);
        Task<IEnumerable<CarrinhoItem>> GetItems(int usuarioId);

    }
}
