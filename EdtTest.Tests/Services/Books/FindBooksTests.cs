using EdtTest.Data;
using EdtTest.Data.Filters;
using EdtTest.Data.Models;
using EdtTest.ServiceImplementations.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EdtTest.Tests.Services.Books
{
    public class FindBooksTests
    {
        [Test]
        public void ServiceResult_IsNot_Null()
        {
            var filter = new BookFilter();
            Mock<LibraryContext> mContext = new Mock<LibraryContext>();

            mContext.Setup(m => m.Books).Returns(GetDbSet());

            BooksService service = new BooksService(mContext.Object);

            var result = service.FindBooks(filter);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Service_Throws_Exception_When_Context_Throws_Exception()
        {
            var filter = new BookFilter();
            Mock<LibraryContext> mContext = new Mock<LibraryContext>();

            mContext.Setup(m => m.Books).Throws<Exception>();

            BooksService service = new BooksService(mContext.Object);

            Assert.Throws<Exception>(() => service.FindBooks(filter));
        }

        [Test]
        public void Results_Excludes_BooksWithCopiesOnLoan()
        {
            Book bookOnLoan = new Book()
            {
                Title = "BookA",
                Authors = "AuthorA",
                ID = 1,
                Copies = [
                    new BookCopy() {
                        ID = 1,
                        BookID = 1,
                        Loans = [
                            new BookLoan() {
                                ID = 1,
                                CopyID = 1,
                                MemberID = 1,
                                ReturnByDate = DateTime.Now.AddDays(7),
                                ReturnedDate = null
                            }
                        ]
                    }
                ]
            };

            Book[] books =
            [
                bookOnLoan,
                // this book has never been on loan
                new Book { ID = 2, Title = "BookB", Authors = "AuthorA", Copies = [ new BookCopy { ID = 2, BookID = 2, Loans = [] } ] },
                // this book has been on loan but has been returned
                new Book { ID = 3, Title = "BookC", Authors = "AuthorC", Copies = [ new BookCopy {  ID = 3, BookID = 3, Loans = [ new BookLoan { ID = 2, CopyID = 3, MemberID = 1, ReturnByDate = DateTime.Now.AddDays(-7), ReturnedDate = DateTime.Now.AddDays(-8)}] }]}
            ];


            var filter = new BookFilter { AvailableForLoanOnly = true };
            var dbSet = GetDbSet(books);
            Mock<LibraryContext> mContext = new Mock<LibraryContext>();

            mContext.Setup(c => c.Books).Returns(dbSet);

            BooksService service = new BooksService(mContext.Object);

            var serviceResult = service.FindBooks(filter);

            CollectionAssert.DoesNotContain(serviceResult, bookOnLoan);
        }

        private static DbSet<Book> GetDbSet(params Book[] books)
        {
            var booksQueryable = books.AsQueryable();
            Mock<DbSet<Book>> mBooks = new Mock<DbSet<Book>>();

            mBooks.As<IQueryable<Book>>().Setup(b => b.Provider).Returns(booksQueryable.Provider);
            mBooks.As<IQueryable<Book>>().Setup(b => b.Expression).Returns(booksQueryable.Expression);
            mBooks.As<IQueryable<Book>>().Setup(b => b.ElementType).Returns(booksQueryable.ElementType);
            mBooks.As<IQueryable<Book>>().Setup(b => b.GetEnumerator()).Returns(booksQueryable.GetEnumerator());

            return mBooks.Object;
        }
    }
}
