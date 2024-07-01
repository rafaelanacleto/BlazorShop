using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Produtos>> GetAll()
        {
            var produto = await _appDbContext.Produtos
                    .Include(x => x.Categoria)
                    .ToListAsync();

            if (produto.Count == 0)
            {
                return null;
            }  

            return produto.OrderBy(x => x.Id).ToList();
        }

        public async Task<Produtos> GetById(int id)
        {
             var produto = await _appDbContext.Produtos
                    .Include(x => x.Categoria)
                    .SingleOrDefaultAsync(c => c.Id == id);

            if (produto is null)
            {
                return null;
            }  

            return produto;
        }

        public async Task<IEnumerable<Produtos>> GetProdutoPorCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}