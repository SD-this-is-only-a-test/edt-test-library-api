using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class EndLoanRequest
    {
        [Required]
        public int BookCopyID { get; set; }
    }
}
