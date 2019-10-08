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

        public async Task<bool> Post(Item item)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);
                HttpResponseMessage awaitVar = await postAsync;

                if (awaitVar.IsSuccessStatusCode)
                {
                    string jsonResStr = awaitVar.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }
            }
            return ok;
        }




    }
}
