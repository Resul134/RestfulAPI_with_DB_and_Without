using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestLibrary;
using RestLibrary.model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        public static List<Item> data = new List<Item>()
        {
            new Item(id: 10, name: "Resul", quality: "High", quantity: 30)
        };
        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return data;
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "GetItems")]
        public Item Get(int id)
        {
            return data.Find(c => c.Id == id);
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            data.Add(value);
            
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }
    }
}
