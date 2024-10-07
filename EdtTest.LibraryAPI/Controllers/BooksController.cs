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
            var getBooksResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                getBooksResult.Data = _booksService.GetBooks();
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(GetBooks));
                getBooksResult.Errors = [ "Failed to get books", serviceError.Message ];
            }

            return getBooksResult;
        }

        [HttpPost]
        public ApiResponse<IEnumerable<Book>> FindBooks(BookFilter filter)
        {
            var findBooksResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                findBooksResult.Data = _booksService.FindBooks(filter);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(FindBooks));
                findBooksResult.Errors = [ "Failed to find books", serviceError.Message ];
            }
            return findBooksResult;
        }

        [HttpPost]
        public ApiResponse<Book> CreateBook(CreateBookRequest request)
        {
            var createBookResult = new ApiResponse<Book>();

            try
            {
                createBookResult.Data = _booksService.CreateBook(request.Title, request.Authors, request.Description, request.AddCopy);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(CreateBook));
                createBookResult.Errors = [ "Failed to create a new book", serviceError.Message ];
            }

            return createBookResult;
        }
    }
}
