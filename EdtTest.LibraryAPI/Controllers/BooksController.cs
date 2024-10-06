using EdtTest.Data.Filters;
using EdtTest.Data.Models;
using EdtTest.LibraryAPI.Models;
using EdtTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class BooksController(ILoggerFactory loggerFactory, IBooksService booksService) : ControllerBase
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<BooksController>();

        private readonly IBooksService _booksService = booksService;

        [HttpGet]
        public ApiResponse<IEnumerable<Book>> GetBooks()
        {
            var indexResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                indexResult.Data = _booksService.GetBooks();
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(GetBooks));
                indexResult.Errors = [ "Failed to get books", serviceError.Message ];
            }

            return indexResult;
        }

        [HttpPost]
        public ApiResponse<IEnumerable<Book>> FindBooks(BookFilter filter)
        {
            var findBooksResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                _ = _booksService.FindBooks(filter);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(FindBooks));
                findBooksResult.Errors = [ "Failed to find books", serviceError.Message ];
            }
            return findBooksResult;
        }
    }
}
