using EdtTest.Data.Filters;
using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IBookLoansService
    {
        /// <summary>
        /// Start a new loan of a copy of a book for a member.
        /// </summary>
        /// <param name="bookCopyId">The ID of the book copy being loaned out.</param>
        /// <param name="libraryMemberId">The ID of the member loaning the book copy.</param>
        /// <returns>A newly created book loan.</returns>
        /// <exception cref="Exception">Thrown when saving the new entity fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when query execution fails or the book is already on loan.</exception>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        BookLoan StartLoan(int bookCopyId, int libraryMemberId);

        /// <summary>
        /// Updates a loan to show it has ended.
        /// </summary>
        /// <param name="bookCopyId">The book copy that was loaned.</param>
        /// <returns>The updated book loan.</returns>
        /// <exception cref="Exception">Thrown when updating the entity fails.</exception>
        BookLoan EndLoan(int bookCopyId);

        /// <summary>
        /// Find loans in the system.
        /// </summary>
        /// <param name="filter">The filter to apply to results.</param>
        /// <returns>A collection of loans mathcing the specified criteria.</returns>
        /// <exception cref="InvalidOperationException">Thrown when query execution fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        IEnumerable<BookLoan> FindBookLoans(BookLoanFilter filter);
    }
}
