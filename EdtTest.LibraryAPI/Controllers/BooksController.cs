using EdtTest.Data.Models;
using EdtTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController(ILoggerFactory loggerFactory, IBooksService booksService) : ControllerBase
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<BooksController>();

        public IEnumerable<Book> Index()
        {
            throw new NotImplementedException();
        }
    }
}
