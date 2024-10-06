using System.ComponentModel.DataAnnotations;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Authors { get; set; }

        [Required]
        public string Description { get; set; }

        public bool AddCopy { get; set; }
    }
}
