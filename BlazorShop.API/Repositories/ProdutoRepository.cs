using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Context;

namespace BlazorShop.API.Repositories
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }





        
    }
}