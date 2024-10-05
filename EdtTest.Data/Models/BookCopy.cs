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

        public virtual Book Book { get; set; }
    }
}
