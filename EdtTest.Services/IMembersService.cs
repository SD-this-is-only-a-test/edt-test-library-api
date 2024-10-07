using EdtTest.Data.Filters;
using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IMembersService
    {
        IEnumerable<LibraryMember> GetMembers();
        IEnumerable<LibraryMember> FindMembers(MemberFilter filter);
        LibraryMember CreateMember(string title, string forename, string surname, DateTime dateOfBirth);
    }
}
