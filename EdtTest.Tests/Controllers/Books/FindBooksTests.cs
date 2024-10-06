using EdtTest.Data.Filters;
using EdtTest.LibraryAPI.Controllers;
using EdtTest.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace EdtTest.Tests.Controllers.Books
{
    public class FindBooksTests
    {
        [Test]
        public void Result_IsNot_Null()
        {
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.FindBooks(new BookFilter());

            Assert.That(result, Is.Not.Null);
        }
    }
}
