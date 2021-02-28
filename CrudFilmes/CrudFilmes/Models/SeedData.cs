using CrudFilmes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFilmes.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CrudFilmesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CrudFilmesContext>>()))
            {
                // Look for any movies.
                if (context.CadastFilmes.Any())
                {
                    return;   // DB has been seeded
                }

                context.CadastFilmes.AddRange(
                    new CadastFilmes
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genero = "Romantic Comedy",
                        Preco = 7.99M
                    },

                    new CadastFilmes
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genero = "Comedy",
                        Preco = 8.99M
                    },

                    new CadastFilmes
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genero = "Comedy",
                        Preco = 9.99M
                    },

                    new CadastFilmes
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genero = "Western",
                        Preco = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }






}

