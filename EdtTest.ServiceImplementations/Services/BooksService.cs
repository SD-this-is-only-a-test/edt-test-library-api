using EdtTest.Data.Models;
using EdtTest.Data;
using EdtTest.Services;
using EdtTest.Data.Filters;
using Microsoft.EntityFrameworkCore;

namespace EdtTest.ServiceImplementations.Services
{
    public class BooksService(LibraryContext context) : IBooksService
    {
        private readonly LibraryContext _context = context;

        public Book CreateBook(string title, string authors, string description, bool addCopy)
        {
            var book = new Book { Authors = authors, Description = description, Title = title };

            if (addCopy)
                book.Copies = [ new BookCopy { Book = book } ];

            _context.Books.Add(book);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return book;
        }

        public BookCopy CreateBookCopy(int bookId)
        {
            bool bookExists;
            BookCopy bookCopy;

            try
            {
                bookExists = _context.Books.Any(b => b.ID == bookId);
            }
            catch (ArgumentNullException)
            {
                throw;
            }

            if (!bookExists)
                throw new InvalidOperationException("No matching book found");

            bookCopy = new BookCopy { BookID = bookId };

            _context.BookCopies.Add(bookCopy);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return bookCopy;
        }

        public IEnumerable<Book> FindBooks(BookFilter filter)
        {
            try
            {
                return _context.Books.Where(b =>
                    !filter.AvailableForLoanOnly ||
                    (
                        b.Copies.Count > 0 &&
                        b.Copies.All(c => c.Loans.Count == 0 || c.Loans.All(l => l.ReturnedDate != null && l.ReturnedDate <= DateTime.Now))
                    )
                );
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            try
            {
                return _context.Books.OrderBy(b => b.Title).ThenBy(b => b.Authors);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
