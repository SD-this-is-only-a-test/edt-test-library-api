using EdtTest.Data.Filters;
using EdtTest.Data.Models;
using EdtTest.LibraryAPI.Models;
using EdtTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdtTest.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class MembersController(ILoggerFactory loggerFactory, IMembersService membersService) : ControllerBase
    {
        private readonly ILogger<MembersController> _logger = loggerFactory.CreateLogger<MembersController>();

        private readonly IMembersService _membersService = membersService;

        [HttpGet]
        public ApiResponse<IEnumerable<LibraryMember>> GetMembers()
        {
            var getMembersResult = new ApiResponse<IEnumerable<LibraryMember>>();

            try
            {
                getMembersResult.Data = _membersService.GetMembers();
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(MembersController), nameof(GetMembers));
                getMembersResult.Errors = ["Failed to get members", serviceError.Message];
            }

            return getMembersResult;
        }

        [HttpPost]
        public ApiResponse<IEnumerable<LibraryMember>> FindMembers(MemberFilter filter)
        {
            var findMembersResult = new ApiResponse<IEnumerable<LibraryMember>>();

            try
            {
                findMembersResult.Data = _membersService.FindMembers(filter);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(MembersController), nameof(FindMembers));
                findMembersResult.Errors = ["Failed to find members", serviceError.Message];
            }

            return findMembersResult;
        }

        [HttpPost]
        public ApiResponse<LibraryMember> CreateMember(CreateMemberRequest request)
        {
            var createMemberResult = new ApiResponse<LibraryMember>();

            try
            {
                createMemberResult.Data = _membersService.CreateMember(request.Title, request.Forename, request.Surname, request.DateOfBirth);
            }
            catch (Exception serviceError)
            {
                _logger.LogError(serviceError, "{controller} method {method} failed", nameof(MembersController), nameof(CreateMember));
                createMemberResult.Errors = ["Failed to create member", serviceError.Message];
            }

            return createMemberResult;
        }
    }
}
