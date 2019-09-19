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
    [Route("api/localitems")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        public static List<Item> data = new List<Item>
        {
            new Item(id: 10, name: "Resul", quality: "High", quantity: 17),
            new Item(id: 6, name: "Christian", quality: "Medium", quantity: 30),
            new Item(id: 4, name: "Anders", quality: "High", quantity: 25),
            new Item(id: 3, name: "Peter", quality: "Low", quantity: 30)
        };
        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return data;
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("{id}")] 
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
        [HttpGet]
        [Route("{id}")] 
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


        // /api/localItems/Name/"substring"
        [HttpGet]
        [Route("Name/{substring}")]
        public List<Item> GetFromSubString(string substring)
        {
            return data.FindAll(i => i.Name.Contains(substring));
        }

        // /api/localItems/Quality/"substring"
        [HttpGet]
        [Route("Quality/{substring}")]
        public List<Item> getItemsQuality(string substring)
        {
            
          return data.FindAll(i => i.Quality.Contains(substring));
            
        }
        // /api/localItems/search?xxxx
        [HttpGet]
        [Route("search")]
        public List<Item> filterItems([FromQuery] FilterItem qitem)
        {
            List<Item> items = new List<Item>();


            foreach (Item ite in data)
            {
                if (qitem.HighQuantity <= ite.Quantity && qitem.LowQuantity <= ite.Quantity)
                {
                    items.Add(ite);
                }
            }

            return items;
        }
    }
}
