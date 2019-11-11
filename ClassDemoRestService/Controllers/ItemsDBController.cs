using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassDemoRestService.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestLibrary.model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/ItemsDB")]
    [ApiController]
    public class ItemsDBController : ControllerBase
    {
        //api/ItemsDB
        // GET: api/ItemsDB


        [HttpGet]
        public IEnumerable<Item> Get()
        {
            ManageItems mngItem = new ManageItems();
            return mngItem.getAllItems();
        }

        // GET: api/ItemsDB/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            ManageItems mngItem = new ManageItems();
            return mngItem.GetItemFromId(id);
        }

        // POST: api/ItemsDB
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            ManageItems mngItem = new ManageItems();
            mngItem.CreateItem(value);
        }

        // PUT: api/ItemsDB/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody]Item value)
        {
            ManageItems mngItem = new ManageItems();
            mngItem.UpdateItem(value, id);
        }
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            ManageItems mngItem = new ManageItems();
            // DELETE: a
            mngItem.deleteItem(id);
        }
    }
    
}
