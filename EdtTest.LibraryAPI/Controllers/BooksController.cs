using EdtTest.Data.Models;
using EdtTest.LibraryAPI.Models;
using EdtTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController(ILoggerFactory loggerFactory, IBooksService booksService) : ControllerBase
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<BooksController>();

        private readonly IBooksService _booksService = booksService;

        public ApiResponse<IEnumerable<Book>> Index()
        {
            var indexResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                _ = _booksService.GetBooks();
            }
            catch (Exception)
            {
                indexResult.Errors = [ "Failed to get books" ];
            }

            return indexResult;
        }
    }
}
