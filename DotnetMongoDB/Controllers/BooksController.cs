using DotnetMongoDB.Models;
using DotnetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.GetBooks();
        }

    }
}
