using CrudFilmes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFilmes.Data
{
    public class CrudFilmesContext : DbContext
{

        public CrudFilmesContext(DbContextOptions<CrudFilmesContext> options)
            : base(options)
        {
        }


        public DbSet<CadastFilmes> CadastFilmes { get; set; }


    }




}


