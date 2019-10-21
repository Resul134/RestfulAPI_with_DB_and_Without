using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using RestLibrary.model;
namespace ConsumeRest
{
    public class Program
    {

        
        static async Task Main(string[] args)
        {
            ItemsConsume Items = new ItemsConsume();

            Task<IList<Item>> itemsList = Items.getItems();

            
 
            foreach (var item in itemsList.Result)
            {
                Console.WriteLine(item.ToString());

            }

            Task<List<Item>> getone = Items.getOneItem("Peter");
            List<Item> ddd = getone.Result;

            foreach (var oneItem in getone.Result)
            {
                Console.WriteLine("The element you were looking for: " + oneItem);
            }

            Console.ReadLine();


            

          
            await Items.Post(new Item(35, "Resulsen", "Medium", 3.33));

            


            Console.ReadLine();

            foreach (var newItems in itemsList.Result)
            {
                Console.WriteLine(newItems.ToString());
            }









        }


        
    }
}
