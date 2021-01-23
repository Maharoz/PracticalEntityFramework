using InventoryDatabaseCore;
using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Activity0302_EFCoreNewDb
{
    class Program
    {

        static IConfigurationRoot _configuration;
        static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;
        static void Main(string[] args)
        {
            BuildOptions();
            Console.WriteLine(_configuration.GetConnectionString("InventoryManager"));
            DeleteAllItems();
            InsertItems();
            UpdateItems();
            ListInventory();




        }
        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString
            ("InventoryManager"));

        }
        static void ListInventory()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.Take(5).OrderBy(x => x.Name).ToList();
                items.ForEach(x => Console.WriteLine($"New Item:{ x.Name}"));
            }
        }

        static void InsertItems()
        {
            var items = new List<Item>()
            {
                 new Item() { Name = "Top Gun"},
                 new Item() { Name = "Batman Begins"},
                 new Item() { Name = "Inception"},
                 new Item() { Name = "Star Wars: The Empire Strikes Back"},
                 new Item() { Name = "Remember the Titans"}
            };

            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                db.AddRange(items);
                db.SaveChanges();
            }

        }

        static void DeleteAllItems()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.ToList();
                db.Items.RemoveRange(items);
                db.SaveChanges();
            }
        }


        static void UpdateItems()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.
            Options))
            {
                var items = db.Items.ToList();
                foreach (var item in items)
                {
                    item.LastModifiedUserId = 1;
                    item.CurrentOrFinalPrice = 9.99M;

                }
                db.Items.UpdateRange(items);
                db.SaveChanges();

            }
        }
    }
}
