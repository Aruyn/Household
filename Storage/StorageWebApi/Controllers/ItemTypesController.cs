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
    public class ItemTypesController : ControllerBase
    {
        private readonly StorageContext db;

        public ItemTypesController(StorageContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<ItemType> Get()
        {
            return db.ItemTypes;
        }

        [HttpPost]
        public async Task Post(string description)
        {
            await db.ItemTypes.AddAsync(
                    new ItemType()
                    {
                        Id = Guid.NewGuid(),
                        Description = description
                    }
                );
        }
    }
}