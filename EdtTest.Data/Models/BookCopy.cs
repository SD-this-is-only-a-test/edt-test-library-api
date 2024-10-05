using System.ComponentModel.DataAnnotations;

namespace EdtTest.Data.Models
{
    public class BookCopy
    {
        [Key]
        public int ID { get; set; }

        public int BookID { get; set; }

        public virtual Book Book { get; set; }
    }
}
