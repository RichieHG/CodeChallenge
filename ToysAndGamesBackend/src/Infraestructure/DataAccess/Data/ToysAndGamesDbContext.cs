using Domain.Entities;
using Infraestructure.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataAccess.Data
{
    public class ToysAndGamesDbContext : DbContext
    {
        public ToysAndGamesDbContext(DbContextOptions<ToysAndGamesDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
