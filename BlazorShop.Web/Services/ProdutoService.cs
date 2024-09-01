using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;
using Microsoft.Extensions.Logging;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _restClient;
        public ILogger<ProdutoService> _logger;


        public ProdutoService(HttpClient restClient, ILogger<ProdutoService> logger)
        {
            _restClient = restClient;
            _logger = logger;
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

        public async Task<IEnumerable<ProdutosDTO>> GetItens()
        {
            try
            {
                var produtosDto = await _restClient.GetFromJsonAsync<IEnumerable<ProdutosDTO>>("api/produtos");
                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos : api/produtos ");
                throw;
            }
        }


        public async Task<ProdutosDTO> GetProdutoById(int id)
        {
            try
            {
                var response = await _restClient.GetAsync($"api/Produto/{id}");


                if (response.IsSuccessStatusCode) //status code 200 -  299
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) // 204
                    {
                        return default; //retorna valor padrão / empty
                    }

                    return await response.Content.ReadFromJsonAsync<ProdutosDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    System.Console.WriteLine("errp");
                    throw new Exception("Status code");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public async Task<ProdutosDTO> GetItem(int id)
        {
            try
            {
                var response = await _restClient.GetAsync($"api/produtos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProdutosDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutosDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={id}");
                throw;
            }
        }

    }
}