using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestLibrary.model;

namespace ClassDemoRestService.DB
{
    public interface IManageItems
    {
        List<Item> getAllItems();



        Item GetItemFromId(int id);


        bool CreateItem(Item item);


        bool UpdateItem(Item item, int id);


        bool deleteItem(int id);
    }
}
