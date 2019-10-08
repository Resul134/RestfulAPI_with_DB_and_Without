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

        
        static void Main(string[] args)
        {
            ItemsConsume listItems = new ItemsConsume();

            Task<IList<Item>> items = listItems.getItems();

            
 
            foreach (var item in items.Result)
            {
                Console.WriteLine(item.ToString());

            }

            Task<List<Item>> getone = listItems.getOneItem("Peter");
            List<Item> ddd = getone.Result;

            foreach (var one in getone.Result)
            {
                Console.WriteLine("The element you were looking for: " + one);
            }

            Console.ReadLine();
            
           

           



        }


        
    }
}
