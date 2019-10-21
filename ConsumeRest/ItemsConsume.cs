using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestLibrary.model;

namespace ConsumeRest
{
    public class ItemsConsume
    {
        private string URI = "http://cars-rest.azurewebsites.net/api/localItems";

        public async Task<IList<Item>> getItems()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<Item> clist =
                    JsonConvert.DeserializeObject<IList<Item>>(content);
                return clist;
            }
        }

        public async Task<List<Item>> getOneItem(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + "/Name/" + name );
                List<Item> getone = JsonConvert.DeserializeObject<List<Item>>(content);
                return getone;
            }
        }

        public async Task Post(Item item)
        {

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.ASCII, "application/json");
                await client.PostAsync(URI, content);
            }
        }


        public async Task Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(URI + "/" + id);
            }
        }




    }
}
