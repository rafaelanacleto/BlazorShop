using BlazorShop.API.Entities;

namespace BlazorShop.API.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> GetAll();
        Task<Produtos> GetById(int id);
        Task<IEnumerable<Produtos>> GetProdutoPorCategoria(int id);
        
    }
}
