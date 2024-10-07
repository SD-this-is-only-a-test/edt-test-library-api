using EdtTest.Data.Models;
using EdtTest.Services;
using EdtTest.Data.Filters;
using EdtTest.Data;
using Microsoft.EntityFrameworkCore;

namespace EdtTest.ServiceImplementations.Services
{
    public class BookLoansService(LibraryContext context) : IBookLoansService
    {
        private readonly LibraryContext _context = context;

        public BookLoan EndLoan(int bookCopyId)
        {
            BookLoan loan;

            try
            {
                loan = _context.BookLoans.Single(l => l.CopyID == bookCopyId && l.ReturnedDate == null);
                loan.ReturnedDate = DateTime.Now;
                _context.SaveChanges();
            }
            catch (DbUpdateException) // save failed
            {
                throw;
            }
            catch (ArgumentNullException) // query failed
            {
                throw;
            }
            catch (InvalidOperationException) // query failed
            {
                throw;
            }

            return loan;
        }

        public IEnumerable<BookLoan> FindBookLoans(BookLoanFilter filter)
        {
            if (filter.LoanState == BookLoanState.All && !filter.LibraryMemberID.HasValue && !filter.BookCopyID.HasValue)
            {
                try
                {
                    return _context.BookLoans.OrderByDescending(l => l.ReturnByDate);
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
            }

            try
            {
                return _context.BookLoans.Where(l =>
                    ( filter.LoanState == BookLoanState.All || (filter.LoanState == BookLoanState.Returned && l.ReturnedDate != null) || (filter.LoanState == BookLoanState.NotReturned && l.ReturnedDate == null) ) &&
                    ( filter.LibraryMemberID == null || l.MemberID == filter.LibraryMemberID ) &&
                    ( filter.BookCopyID == null || l.CopyID == filter.BookCopyID )
                ).OrderByDescending(l => l.ReturnByDate);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        public BookLoan StartLoan(int bookCopyId, int libraryMemberId)
        {
            bool existingLoanExists;

            try
            {
                existingLoanExists = _context.BookLoans.Any(l => l.CopyID == bookCopyId && l.ReturnedDate == null);
            }
            catch (ArgumentNullException)
            {
                throw;
            }

            if (existingLoanExists)
            {
                throw new InvalidOperationException("This book is already on loan");
            }

            BookLoan loan = new BookLoan { CopyID = bookCopyId, MemberID = libraryMemberId, ReturnByDate = DateTime.Today.AddDays(14) };

            _context.BookLoans.Add(loan);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return loan;
        }
    }
}
