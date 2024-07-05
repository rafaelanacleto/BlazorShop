using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _restClient;
        public ProdutoService(HttpClient restClient)
        {
            _restClient = restClient;           
        }

        public async Task<IEnumerable<ProdutosDTO>> GetProdutos()
        {
            try
            {
                var produto = await _restClient.GetFromJsonAsync<IEnumerable<ProdutosDTO>>("api/Produto");

                return produto;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}