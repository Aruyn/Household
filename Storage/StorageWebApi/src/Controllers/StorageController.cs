using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageWebApi.Database;
using StorageWebApi.DtoModels;
using StorageWebApi.DomainModels;
using StorageWebApi.Database.Models;

namespace StorageWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly StorageContext db;

        public StorageController(StorageContext db)
    {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return db.StoredItems
            .ToArray()
                .GroupBy(i => i.ItemId)
                .Select(grp =>
                    new Item
                    {
                        Description = db.ItemTypes.First( i => i.Id == grp.Key).Description,
                        Amount = grp.Count(),
                        ExpiredDates = grp.Select(i => i.ExpiredDate).OrderBy(d => d).ToArray()
                    });  
        }

        [HttpPost]
        public async Task Post(AddItemArg arg)
        { 
            var newItemTypeId = Guid.NewGuid();
            if(arg.ItemTypeId == default){
                 await db.ItemTypes.AddAsync(
                        new ItemType()
                        {
                            Id = newItemTypeId,
                            Description = arg.Description
                        }
                    );
            }

            await db.StoredItems.AddAsync(
                    new StoredItem()
                    {
                        Id = Guid.NewGuid(),
                        ItemId = arg.ItemTypeId == default ? newItemTypeId : arg.ItemTypeId,
                        AddedDate =  arg.AddedDate,
                        ExpiredDate = arg.ExpiredDate,
                        Location = arg.Location
                    }
                );
            await db.SaveChangesAsync();
        }

        [HttpPost]
        public async Task UseItem(string description)
        { 
            var itemType = db.ItemTypes.ToArray().SingleOrDefault(i => i.Description == description);

            if(itemType == default){
                return;
            }

            db.StoredItems.Remove(
                    db.StoredItems.ToArray().Where(i => i.ItemId == itemType.Id).OrderBy(i => i.ExpiredDate).First()
                );
                
            await db.SaveChangesAsync();
        }
    }
}