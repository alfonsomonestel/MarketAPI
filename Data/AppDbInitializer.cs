using MarketAPI.Models;
using Microsoft.CodeAnalysis.Elfie.Model.Structures;
using System;
using System.IO.Pipelines;

namespace MarketAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Categoria
                if (!context.Categoria.Any())
                {
                    context.Categoria.AddRange(new List<CategoriaModel>()
                    {
                        new CategoriaModel()
                        {
                            Id = 1,
                            Nome = "Refrigerante",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 2,
                            Nome = "Cerveja",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 3,
                            Nome = "Massas",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 4,
                            Nome = "Higiene",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 5,
                            Nome = "Limpeza",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 6,
                            Nome = "Carne",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 7,
                            Nome = "Peixe",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 8,
                            Nome = "Frango",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 9,
                            Nome = "Frutas",
                            Situacao = true
                        },
                        new CategoriaModel()
                        {
                            Id = 10,
                            Nome = "Liquor",
                            Situacao = false
                        },
                        new CategoriaModel()
                        {
                            Id = 11,
                            Nome = "Ferramentas",
                            Situacao = true
                        }                        
                    });
                    context.SaveChanges();
                }
                //Produtos
                if (!context.Produto.Any())
                {
                    context.Produto.AddRange(new List<ProdutoModel>()
                    {
                        new ProdutoModel()
                        {
                            Id = 1,
                            Nome = "Coca Cola 2L",
                            Descricao = "Coca Cola 2L - Bebida gaseificada sabor aritificial de Cola",
                            CategoriaId = 1,
                            Preco = 9.90M,
                            Situacao = true
                        },
                        new ProdutoModel()
                        {
                            Id = 2,
                            Nome = "Guaraná Antártica 2L",
                            Descricao = "Guaraná Antártica 2L - Bebida gaseificada sabor aritificial de Guaraná",
                            CategoriaId = 1,
                            Preco = 9.90M,
                            Situacao = true
                        },
                        new ProdutoModel()
                        {
                            Id = 3,
                            Nome = "Cerveja Amstel 355ml",
                            Descricao = "Cerveja Amstel Lager - Produto com origem de Amsterdam",
                            CategoriaId = 2,
                            Preco = 3.48M,
                            Situacao = true
                        },
                        new ProdutoModel()
                        {
                            Id = 4,
                            Nome = "Cerveja Heineken 355ml",
                            Descricao = "Cerveja Heineken Lager - Produto com origem brasileira",
                            CategoriaId = 2,
                            Preco = 4.98M,
                            Situacao = false
                        }
                    }) ;
                    context.SaveChanges();
                }
            }

        }
    }
}
