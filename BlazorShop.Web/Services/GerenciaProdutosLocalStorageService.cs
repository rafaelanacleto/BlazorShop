using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Models.DTOs;
﻿using Blazored.LocalStorage;

namespace BlazorShop.Web.Services
{
    public class GerenciaProdutosLocalStorageService : IGerenciaProdutosLocalStorageService
    {
        private const string key = "ProdutoCollection";

        private readonly ILocalStorageService localStorageService;
        private readonly IProdutoService produtoService;

        public GerenciaProdutosLocalStorageService(ILocalStorageService localStorageService,
            IProdutoService produtoService)
        {
            this.localStorageService = localStorageService;
            this.produtoService = produtoService;
        }

        public async Task<IEnumerable<ProdutosDTO>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<IEnumerable<ProdutosDTO>>(key)
                             ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<ProdutosDTO>> AddCollection()
        {
            var produtoCollection = await this.produtoService.GetItens();
            if (produtoCollection != null)
            {
                await this.localStorageService.SetItemAsync(key, produtoCollection);
            }
            return produtoCollection;
        }
    }
}