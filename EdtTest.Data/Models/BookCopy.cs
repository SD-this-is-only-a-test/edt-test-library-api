using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdtTest.Data.Models
{
    public class BookCopy
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookID { get; set; }

        /// <summary>
        /// This is the book of which this is a copy
        /// </summary>
        public virtual Book Book { get; set; }

        /// <summary>
        /// Loans of this book copy
        /// </summary>
        public virtual ICollection<BookLoan> Loans { get; set; }
    }
}
