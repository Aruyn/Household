using System;
using StorageWebApi.DomainModels;

namespace StorageWebApi.DtoModels
{
    public class AddItemArg
    {
        public Guid ItemTypeId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public Location Location { get; set; }
    }
}