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
            Assert.Fail("We don't have an association between copies and loans!");
        }
    }
}
