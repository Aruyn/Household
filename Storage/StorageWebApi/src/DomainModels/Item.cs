using System;
using System.Linq;

namespace StorageWebApi.DomainModels
{
    public class Item
    {
        public DateTime[] ExpiredDates { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}