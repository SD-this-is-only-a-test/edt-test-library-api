using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateBookCopyRequest
    {
        [Required]
        public int BookID { get; set; }
    }
}
