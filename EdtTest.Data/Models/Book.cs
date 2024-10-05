using System.ComponentModel.DataAnnotations;

namespace EdtTest.Data.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        /// <summary>
        /// The copies which the library has of this book
        /// </summary>
        public virtual ICollection<BookCopy> Copies { get; set; }
    }
}
