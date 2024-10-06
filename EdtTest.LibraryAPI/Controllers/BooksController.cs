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

        [HttpGet(Name = "GetBooks")]
        public ApiResponse<IEnumerable<Book>> Index()
        {
            var indexResult = new ApiResponse<IEnumerable<Book>>();

            try
            {
                indexResult.Data = _booksService.GetBooks();
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(BooksController), nameof(Index));
                indexResult.Errors = [ "Failed to get books", serviceError.Message ];
            }

            return indexResult;
        }
    }
}
