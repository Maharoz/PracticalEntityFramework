using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace InventoryDatabaseCore
{
    public class InventoryDbContext:DbContext
    {
        private static IConfigurationRoot _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Data Source = localhost;Initial Catalog=InventoryManager; Integrated Security=True");
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true,
                    reloadOnChange: true);

                _configuration = builder.Build();

                var cnstr = _configuration.GetConnectionString("InventoryManager");
                optionsBuilder.UseSqlServer(cnstr);

            }
        }
        public DbSet<Item> Items { get; set; }
        public InventoryDbContext():base()
        {

        }
        public InventoryDbContext(DbContextOptions options):base()
        {
            
        }
    }
}
