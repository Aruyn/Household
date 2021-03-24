using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageWebApi.Database;
using StorageWebApi.Database.Models;

namespace StorageWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            using (var db = new StorageContext())
            {
                return db.StoredItems
                    .GroupBy(i => i.ItemId)
                    .Select(grp =>
                        new Item
                        {
                            Description = db.ItemTypes.First( i => i.Id == grp.Key).Description,
                            Amount = grp.Count(),
                            ExpiredDates = grp.Select(i => i.ExpiredDate).ToArray()
                        });  
            }
        }

        [HttpPost]
        public async Task Post(AddItemArg arg)
        {
            using (var db = new StorageContext())
            {
                await db.StoredItems.AddAsync(
                    new StoredItem()
                    {
                        Id = Guid.NewGuid(),
                        ItemId = arg.ItemTypeId,
                        AddedDate =  arg.AddedDate,
                        ExpiredDate = arg.ExpiredDate,
                        IsFreezed = arg.IsFreezed
                    }
                );
            }
        }
    }
}