using Domain.Entities;
using Infraestructure.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataAccess.Data
{
    public class ToysAndGamesCosmosDbContext : DbContext
    {
        public ToysAndGamesCosmosDbContext(
            DbContextOptions<ToysAndGamesCosmosDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Product> Product { get; set; }

        public static void CheckAndSeedDatabaseAsync(
            DbContextOptions<ToysAndGamesCosmosDbContext> options)
        {
            using var context = new ToysAndGamesCosmosDbContext(options);
            //var _ = context.Database.EnsureDeleted();
            if(context.Database.EnsureCreated())
            {
                context.Company.AddRange(Seed.Companies);
                context.Product.AddRange(Seed.Products);
                context.SaveChanges();
            }
        }

    }
}

