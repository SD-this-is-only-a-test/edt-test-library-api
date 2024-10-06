using EdtTest.LibraryAPI.Controllers;
using EdtTest.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace EdtTest.Tests.Controllers.Books
{
    public class IndexTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Result_IsNot_Null()
        {
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.Index();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ResultErrors_IsNot_Null_When_BookService_Throws_Error()
        {
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            mBooksService.Setup(m => m.GetBooks()).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.Index();

            Assert.That(result.Errors, Is.Not.Null);
        }

        [Test]
        public void ResultErrors_Contains_ErrorMessage_When_BookService_Throws_Error()
        {
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            string errorMessage = $"Book service error {DateTime.Now.Ticks}";

            mBooksService.Setup(m => m.GetBooks()).Throws(new Exception(errorMessage));

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.Index();

            CollectionAssert.Contains(result.Errors, errorMessage);
        }

        [Test]
        public void Error_IsLogged_When_BookService_Throws_Error()
        {
            bool isLogged = false;
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            var formatter = new Func<It.IsAnyType, Exception?, string>((t, e) => string.Empty);

            mLogger.Setup(m => m.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), formatter))
                .Callback(() => { isLogged = true; });

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.GetBooks()).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            _ = controller.Index();

            Assert.That(isLogged, Is.True);
        }
    }
}
