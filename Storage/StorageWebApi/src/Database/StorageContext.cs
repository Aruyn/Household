using System;
using Microsoft.EntityFrameworkCore;
using StorageWebApi.Database.Models;

namespace StorageWebApi.Database
{
    public class StorageContext : DbContext
    {
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<StoredItem> StoredItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseSqlite($"Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbfile", "storage.db")}");
        }
    }
}