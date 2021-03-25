using System;

namespace StorageWebApi.Database.Models
{
    public class StoredItem
    {
        public Guid Id {get; set;}
        public Guid ItemId {get; set;}
        public DateTime AddedDate {get; set;}
        public DateTime ExpiredDate {get; set;}
        public Location Location { get; set; }
    }
}