using EdtTest.Data.Filters;
using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> FindBooks(BookFilter filter);
    }
}
