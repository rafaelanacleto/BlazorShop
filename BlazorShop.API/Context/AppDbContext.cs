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
                IconCSS = "fas fa-spa"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 2,
                Nome = "Moveis",
                IconCSS = "fas fa-couch"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 3,
                Nome = "Eletronicos",
                IconCSS = "fa fa-headphones"
            });

            modelBuilder.Entity<Produtos>().HasData(new Produtos
            {
                Id = 1,
                Nome = "Beleza",
                Descricao = "Balse de Beleza",
                ImagemUrl = "/Imagens/Beleza/Beleza1.jpg",
                Preco = 10,
                Quantidade = 40,
                CategoriaId = 1,
            });

            modelBuilder.Entity<Produtos>().HasData(new Produtos
            {
                Id = 2,
                Nome = "Fones",
                Descricao = "Fone Bluetofh",
                ImagemUrl = "/Imagens/Eletronicos/fones1.jpg",
                Preco = 300,
                Quantidade = 2,
                CategoriaId = 3,
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NomeUsuario = "Rafael"
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                NomeUsuario = "Alice"
            });

            //carrinho do user
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                Id = 1,
                UsuarioId = 1,
            });
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                Id = 2,
                UsuarioId = 2,
            });


        }

    }
}