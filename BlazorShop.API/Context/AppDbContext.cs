using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //OnModel Creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Beleza",
                IconCSS = "Balde"
            });

            modelBuilder.Entity<Produtos>().HasData(new Produtos
            {
                Id = 1,
                Nome = "Beleza",
                Descricao = "Balse de Beleza",
                ImagemUrl = "/Imagens/Beleza/Beleza1.jpg",
                Preco = 100,
                Quantidade = 40,
                CategoriaId = 1,
            });
        }


    }
}