using EdtTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EdtTest.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryMember> Members { get; set; }
    }
}
