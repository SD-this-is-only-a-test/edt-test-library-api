using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateMemberRequest
    {
        [Required(AllowEmptyStrings = false)]
        public required string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Forename { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
