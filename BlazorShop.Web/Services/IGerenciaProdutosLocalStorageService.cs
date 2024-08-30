using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public interface IGerenciaProdutosLocalStorageService
    {
        Task<IEnumerable<ProdutosDTO>> GetCollection();
        Task RemoveCollection();
    }
}
