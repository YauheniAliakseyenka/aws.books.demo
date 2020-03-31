using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Application.Contracts;
using Books.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Books.WebAPI.Demo.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("check")]
        public string Get()
        {
            return "Working";
        }

        [Produces("application/json")]
        [Route("{isbn}")]
        public async Task<Book> Get(string isbn)
        {
            return await _bookService.Get(isbn);
        }
    }
}