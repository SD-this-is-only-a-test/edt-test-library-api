using EdtTest.Data.Models;
using EdtTest.Data;
using EdtTest.Services;
using EdtTest.Data.Filters;
using Microsoft.EntityFrameworkCore;

namespace EdtTest.ServiceImplementations.Services
{
    public class MembersService(LibraryContext context) : IMembersService
    {
        private readonly LibraryContext _context = context;

        public LibraryMember CreateMember(string title, string forename, string surname, DateTime dateOfBirth)
        {
            LibraryMember member = new LibraryMember
            {
                Title = title,
                Forename = forename,
                Surname = surname,
                DateOfBirth = dateOfBirth
            };

            _context.Members.Add(member);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return member;
        }

        public IEnumerable<LibraryMember> FindMembers(MemberFilter filter)
        {
            try
            {
                return _context.Members.Where(m =>
                    (filter.Forename == null || m.Forename.StartsWith(filter.Forename)) &&
                    (filter.Surname == null || m.Surname.StartsWith(filter.Surname)))
                    .OrderBy(m => m.Surname)
                    .ThenBy(m => m.Forename)
                    .ThenBy(m => m.Title);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        public IEnumerable<LibraryMember> GetMembers()
        {
            try
            {
                return _context.Members.OrderBy(m => m.Surname)
                    .ThenBy(m => m.Forename)
                    .ThenBy(m => m.Title);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
