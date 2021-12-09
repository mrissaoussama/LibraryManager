using DAOLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagerWebAPI.Controllers

{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        private Bookservice bookservice;
        public BookController(Bookservice bookservice)
        {
            this.bookservice = bookservice;
        }
        private IEnumerable<Book> book = new List<Book>
        {
          new Book( "1",  "C# Code", 150, "programmation"  ),
        new Book( "2",  "Java ", 100, "programmation"  ),
         new Book( "3",  "Coding", 200 , "programmation"  ),
};

        public IEnumerable<Book> GetBook()
        {
            return book;
        }
        [HttpGet("{id}")]
        public Book GetBook(String id)
        {
            return bookservice.FindById(id).First();
        }

        [HttpPost()]
        public void AddBook(String title, int quantity, String category)
        {
            bookservice.Add(title, quantity, category);
        }
        [HttpPatch(("{id}"))]
        public void UpdateBook(String id)
        {
            bookservice.Update(id);
        }
        [HttpDelete(("{id}"))]
        public void DeleteBook(String id)
        {
            bookservice.Delete(id);
        }
    }
}

