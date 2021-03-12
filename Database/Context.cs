using System;
using AzureStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureStorage.Database
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Catalogo> Catalogos { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Catalogo>().HasKey(x => new { x.id });
        }
    }
}
