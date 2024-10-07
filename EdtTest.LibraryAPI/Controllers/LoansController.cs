using EdtTest.Data.Filters;
using EdtTest.Data.Models;
using EdtTest.LibraryAPI.Models;
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

        public ApiResponse<BookLoan> StartLoan(StartLoanRequest request)
        {
            var startLoanResult = new ApiResponse<BookLoan>();

            try
            {
                startLoanResult.Data = _bookLoansService.StartLoan(request.BookCopyID, request.LibraryMemberID);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(LoansController), nameof(StartLoan));
                startLoanResult.Errors = ["Failed to start loan", serviceError.Message];
            }

            return startLoanResult;
        }

        public ApiResponse<BookLoan> EndLoan(EndLoanRequest request)
        {
            var endLoanResult = new ApiResponse<BookLoan>();

            try
            {
                endLoanResult.Data = _bookLoansService.EndLoan(request.BookCopyID);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(LoansController), nameof(EndLoan));
                endLoanResult.Errors = ["Failed to end loan", serviceError.Message];
            }

            return endLoanResult;
        }

        public ApiResponse<IEnumerable<BookLoan>> FindLoans(BookLoanFilter filter)
        {
            var findLoansResult = new ApiResponse<IEnumerable<BookLoan>>();

            try
            {
                findLoansResult.Data = _bookLoansService.FindBookLoans(filter);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(LoansController), nameof(FindLoans));
                findLoansResult.Errors = ["Failed to find loans", serviceError.Message];
            }

            return findLoansResult;
        }
    }
}
