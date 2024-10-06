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

            mContext.Setup(m => m.Books).Returns(Mock.Of<DbSet<Book>>());

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

            Book[] books = [
                bookOnLoan,
                new Book { ID = 2, Title = "BookB", Authors = "AuthorA", Copies = [ new BookCopy { ID = 2, BookID = 2, Loans = [] } ] },
                new Book { ID = 3, Title = "BookC", Authors = "AuthorC", Copies = [ new BookCopy {  ID = 3, BookID = 3, Loans = [ new BookLoan { ID = 2, CopyID = 3, MemberID = 1, ReturnByDate = DateTime.Now.AddDays(-7), ReturnedDate = DateTime.Now.AddDays(-8)}] }]}
            ];

            Assert.Fail("Still building test");
        }
    }
}
