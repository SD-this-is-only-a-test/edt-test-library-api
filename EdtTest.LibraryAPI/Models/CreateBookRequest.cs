using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateBookRequest
    {
        [Required(AllowEmptyStrings = false)]
        public required string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Authors { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Description { get; set; }

        public bool AddCopy { get; set; }
    }
}
