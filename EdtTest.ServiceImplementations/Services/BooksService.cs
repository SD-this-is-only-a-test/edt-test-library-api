using EdtTest.Data.Models;
using EdtTest.Data;
using EdtTest.Services;

namespace EdtTest.ServiceImplementations.Services
{
    public class BooksService(LibraryContext context) : IBooksService
    {
        private readonly LibraryContext _context = context;

        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
