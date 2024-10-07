using EdtTest.Data.Filters;
using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IBooksService
    {
        /// <summary>
        /// Get all books on record.
        /// </summary>
        /// <returns>All books in the system.</returns>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Find books in the system.
        /// </summary>
        /// <param name="filter">The filter to apply to results.</param>
        /// <returns>A collection of books containing any which match the criteria.</returns>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        IEnumerable<Book> FindBooks(BookFilter filter);

        /// <summary>
        /// Create a new book and, optionally, create a copy of the new book.
        /// </summary>
        /// <param name="title">The title of the new book.</param>
        /// <param name="authors">The author(s) of the new book.</param>
        /// <param name="description">The description of the new book.</param>
        /// <param name="addCopy">If true, a book copy will be created for the new book.</param>
        /// <returns>The newly created book</returns>
        /// <exception cref="Exception">Thrown when saving the new entity fails.</exception>
        Book CreateBook(string title, string authors, string description, bool addCopy);
        BookCopy CreateBookCopy(int bookId);
    }
}
