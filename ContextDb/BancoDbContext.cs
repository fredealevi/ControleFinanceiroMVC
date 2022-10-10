using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_Financeiro.ContextDb
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
        {

        }
        
        public DbSet<Receita> Receitas {get; set;}
    }
}