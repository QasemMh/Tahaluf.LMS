using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Book> SerachBook([FromBody]BookSearchDTO bookDto)
        {
            return _bookService.SearchBook(bookDto);
        }
        




    }
}
