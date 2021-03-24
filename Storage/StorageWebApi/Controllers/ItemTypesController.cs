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
        [HttpGet]
        public IEnumerable<ItemType> Get()
        {
            using (var db = new StorageContext())
            {
                return db.ItemTypes;
            }
        }

        [HttpPost]
        public async Task Post(string description)
        {
            using (var db = new StorageContext())
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
}