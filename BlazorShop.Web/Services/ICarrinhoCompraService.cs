using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDTO>> GetItens(int usuarioId);
        Task<CarrinhoItemDTO> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItemDTO> DeletaItem(int id);
        Task<CarrinhoItemDTO> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        event Action<int> OnCarrinhoCompraChanged;
        void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade);

    }
}
