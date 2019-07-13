using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ObrasBibliograficas.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObrasBibliograficas.Repository.Context
{
    public class ObrasBibliograficasContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
