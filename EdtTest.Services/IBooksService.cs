using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
    }
}
