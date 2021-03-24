using Microsoft.EntityFrameworkCore;
using StorageWebApi.Database.Models;

namespace StorageWebApi.Database
{
    public class StorageContext : DbContext
    {
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<StoredItem> StoredItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\storage.db");
    }
}