using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RestLibrary.model;

namespace ClassDemoRestService.DB
{
    public class ManageItems : IManageItems
    {
        private const string ConnectionString =
            "Server=tcp:alexanderdbserver.database.windows.net,1433;Initial Catalog=AlexanderDB;Persist Security Info=False;User ID=alex5955;Password=DBpass123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Item> getAllItems()
        {
            List<Item> ItemList = new List<Item>();
            string queryString = "SELECT * FROM Items";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Quality = reader.GetString(2);
                        item.Quantity = reader.GetDouble(3);
                        ItemList.Add(item);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return ItemList;
        }

        public Item GetItemFromId(int id)
        {
            Item item = new Item();
            string queryString = "SELECT * FROM Items WHERE Id=" + id;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Quality = reader.GetString(2);
                        item.Quantity = reader.GetDouble(3);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return item;
        }

        

        public bool CreateItem(Item item)
        {
            int noRows;
            string queryString = "INSERT INTO Items (Id,Name,Quality,Quantity) VALUES (@Id,@Name,@Quality,@Quantity)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Quality", item.Quality);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Connection.Open();
                    noRows = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return false;
                }
            }

            return noRows == 1;
        }

        public bool UpdateItem(Item item, int id)
        {
            string queryString = "UPDATE Items SET Id=@id,Name=@name, Quality=@quality, Quantity=@quantity WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", item.Id);
                    command.Parameters.AddWithValue("@name", item.Name);
                    command.Parameters.AddWithValue("@quality", item.Quality);
                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }

        public bool deleteItem(int id)
        {
            string queryString = "DELETE FROM Items WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch(SqlException)
                {
                    
                    return false;
                }
            }

            return true;

        }
    }
}
