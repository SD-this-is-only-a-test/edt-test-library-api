using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EdtTest.LibraryAPI.Models
{
    public class CreateBookRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Authors { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        public bool AddCopy { get; set; }
    }
}
