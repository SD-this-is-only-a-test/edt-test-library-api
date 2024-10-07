using EdtTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class LoansController(ILoggerFactory loggerFactory, IBookLoansService bookLoansService) : ControllerBase
    {
        private readonly ILogger<LoansController> _logger = loggerFactory.CreateLogger<LoansController>();

        private readonly IBookLoansService _bookLoansService = bookLoansService;
    }
}
