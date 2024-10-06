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

        [Test]
        public void ResultErrors_IsNot_Null_When_BookService_Throws_Error()
        {
            var filter = new BookFilter();
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            var formatter = new Func<It.IsAnyType, Exception?, string>((t, e) => string.Empty);

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.FindBooks(It.IsAny<BookFilter>())).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.FindBooks(filter);

            Assert.That(result.Errors, Is.Not.Null);
        }

        [Test]
        public void ResultErrors_Contains_ErrorMessage_When_BookService_Throws_Error()
        {
            var filter = new BookFilter();
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            string errorMessage = $"Book service error {DateTime.Now.Ticks}";
            var formatter = new Func<It.IsAnyType, Exception?, string>((t, e) => string.Empty);

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.FindBooks(It.IsAny<BookFilter>())).Throws(new Exception(errorMessage));

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.FindBooks(filter);

            CollectionAssert.Contains(result.Errors, errorMessage);
        }

        [Test]
        public void Error_IsLogged_When_BookService_Throws_Error()
        {
            var filter = new BookFilter();
            bool isLogged = false;
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            mLogger.Setup(m => m.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<object, Exception?, string>)It.IsAny<object>()))
                .Callback(() => { isLogged = true; });

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.FindBooks(It.IsAny<BookFilter>())).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            _ = controller.FindBooks(filter);

            Assert.That(isLogged, Is.True);
        }
    }
}
