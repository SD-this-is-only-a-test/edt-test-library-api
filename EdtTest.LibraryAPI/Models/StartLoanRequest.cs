using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class StartLoanRequest
    {
        [Required]
        public int BookCopyID { get; set; }

        [Required]
        public int LibraryMemberID { get; set; }
    }
}
