using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateMemberRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Forename { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
