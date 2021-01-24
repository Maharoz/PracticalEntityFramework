using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace InventoryDatabaseCore
{
    public class InventoryDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemGenre>()
                .HasIndex(ig => new { ig.ItemId, ig.GenreId })
                .IsUnique()
                .IsClustered(false);
}
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryColor> CaategoryColor { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public InventoryDbContext() : base()
        {

        }
        public InventoryDbContext(DbContextOptions options) : base()
        {

        }


        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                //System.Diagnostics.Debug.WriteLine($"{entry.Entity} has state {entry.State}");
                if(entry.Entity is FullAuditModel)
                {
                    var referenceEntity = entry.Entity as FullAuditModel;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = System.DateTime.Now;
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = System.DateTime.Now;
                            break;
                        default:
                            break;

                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
