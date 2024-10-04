using System.ComponentModel.DataAnnotations;

namespace EdtTest.Data.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }
    }
}
