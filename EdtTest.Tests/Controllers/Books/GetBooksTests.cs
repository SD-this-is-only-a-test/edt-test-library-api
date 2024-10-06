using EdtTest.Data.Models;
using EdtTest.LibraryAPI.Controllers;
using EdtTest.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace EdtTest.Tests.Controllers.Books
{
    public class GetBooksTests
    {
        [Test]
        public void Result_IsNot_Null()
        {
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.GetBooks();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ResultErrors_IsNot_Null_When_BookService_Throws_Error()
        {
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            var formatter = new Func<It.IsAnyType, Exception?, string>((t, e) => string.Empty);

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.GetBooks()).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.GetBooks();

            Assert.That(result.Errors, Is.Not.Null);
        }

        [Test]
        public void ResultErrors_Contains_ErrorMessage_When_BookService_Throws_Error()
        {
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();
            string errorMessage = $"Book service error {DateTime.Now.Ticks}";
            var formatter = new Func<It.IsAnyType, Exception?, string>((t, e) => string.Empty);

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.GetBooks()).Throws(new Exception(errorMessage));

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.GetBooks();

            CollectionAssert.Contains(result.Errors, errorMessage);
        }

        [Test]
        public void Error_IsLogged_When_BookService_Throws_Error()
        {
            bool isLogged = false;
            Mock<ILogger<BooksController>> mLogger = new Mock<ILogger<BooksController>>();
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            mLogger.Setup(m => m.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<object, Exception?, string>)It.IsAny<object>()))
                .Callback(() => { isLogged = true; });

            mLoggerFactory.Setup(m => m.CreateLogger(It.IsAny<string>())).Returns(mLogger.Object);

            mBooksService.Setup(m => m.GetBooks()).Throws<Exception>();

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            _ = controller.GetBooks();

            Assert.That(isLogged, Is.True);
        }

        [Test]
        public void ResultData_Is_BooksServiceResult()
        {
            Book[] books =
            [
                new Book(){ ID = 1, Title = "Title 1", Authors = "Author1, Author1-2" },
                new Book(){ ID = 2, Title = "Title 2", Authors = "Author2" }
            ];
            Mock<ILoggerFactory> mLoggerFactory = new Mock<ILoggerFactory>();
            Mock<IBooksService> mBooksService = new Mock<IBooksService>();

            mBooksService.Setup(m => m.GetBooks()).Returns(() => books);

            var controller = new BooksController(mLoggerFactory.Object, mBooksService.Object);

            var result = controller.GetBooks();

            CollectionAssert.AreEqual(books, result.Data);
        }
    }
}
