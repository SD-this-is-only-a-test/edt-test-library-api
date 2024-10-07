using EdtTest.Data.Filters;
using EdtTest.Data.Models;

namespace EdtTest.Services
{
    public interface IMembersService
    {
        /// <summary>
        /// Get all members from the system.
        /// </summary>
        /// <returns>All member data in the system.</returns>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        IEnumerable<LibraryMember> GetMembers();

        /// <summary>
        /// Search for members in the system.
        /// </summary>
        /// <param name="filter">The filter to apply to members.</param>
        /// <returns>A collection of LibraryMember matching the specified criteria.</returns>
        /// <exception cref="ArgumentNullException">Thrown when query execution fails.</exception>
        IEnumerable<LibraryMember> FindMembers(MemberFilter filter);

        /// <summary>
        /// Create a new LibraryMember
        /// </summary>
        /// <param name="title">The title (Mr, Mrs, Ms, Miss, etc).</param>
        /// <param name="forename">The forename of the new member.</param>
        /// <param name="surname">The surname of the new member.</param>
        /// <param name="dateOfBirth">The date of birth of the new member.</param>
        /// <returns>The newly created member.</returns>
        /// <exception cref="Exception">Thrown when saving the new entity fails.</exception>
        LibraryMember CreateMember(string title, string forename, string surname, DateTime dateOfBirth);
    }
}
