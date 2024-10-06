using EdtTest.Data;
using EdtTest.Data.Filters;
using EdtTest.ServiceImplementations.Services;
using Moq;

namespace EdtTest.Tests.Services.Books
{
    public class FindBooksTests
    {
        [Test]
        public void ServiceResult_IsNot_Null()
        {
            Mock<LibraryContext> mContext = new Mock<LibraryContext>();
            BooksService service = new BooksService(mContext.Object);
            var filter = new BookFilter();

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
    }
}
