using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDTO>> GetItens(int idUsuario);
        Task<CarrinhoItemDTO> AdicionaItem(CarrinhoItemAdicionaDTO itemDTO);
        Task<CarrinhoItemDTO> DeletaItem(int id);

    }
}
