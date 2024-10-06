using EdtTest.Data.Models;
using EdtTest.Data;
using EdtTest.Services;
using EdtTest.Data.Filters;

namespace EdtTest.ServiceImplementations.Services
{
    public class BooksService(LibraryContext context) : IBooksService
    {
        private readonly LibraryContext _context = context;

        public IEnumerable<Book> FindBooks(BookFilter filter)
        {
            return [];
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Title).ThenBy(b => b.Authors);
        }
    }
}
