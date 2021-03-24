using System;

namespace StorageWebApi
{
    public class AddItemArg
    {
        public Guid ItemTypeId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsFreezed { get; set; }
    }
}