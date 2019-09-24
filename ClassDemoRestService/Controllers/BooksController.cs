using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestLibrary.model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        //http://cars-rest.azurewebsites.net/api/Books
        private static List<Book> books = new List<Book>()
        {
            new Book(isbn13: "ABCDFDGERTDL13", name: "Resul", year: 1996),
            new Book(isbn13: "BGFHDUIJKLA13", name: "Abdul", year: 1998),
            new Book(isbn13: "UHFJDYTFGDH13", name: "Shabab", year: 1997)


        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Books/5
        [HttpGet("{isbn13}")]
        public Book Get(string isbn13)
        {
            return books.Find(c => c.Isbn13 == isbn13);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book item = Get(isbn13);
            if (item != null)
            {
                item.Isbn13 = value.Isbn13;
                item.Year = value.Year;
                item.Name = value.Name;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book car = Get(isbn13);
            if (car != null)
            {
                books.Remove(car);
            }
        }
    }
}
