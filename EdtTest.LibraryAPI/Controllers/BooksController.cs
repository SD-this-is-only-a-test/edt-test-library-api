using EdtTest.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController : ControllerBase
    {
        public IEnumerable<Book> Index()
        {
            throw new NotImplementedException();
        }
    }
}
