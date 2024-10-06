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
    }
}
