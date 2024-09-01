using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutosDTO>> GetProdutos();
        Task<ProdutosDTO> GetProdutoById(int id);

        Task<IEnumerable<ProdutosDTO>> GetItens();
        Task<ProdutosDTO> GetItem(int id);

    }
}