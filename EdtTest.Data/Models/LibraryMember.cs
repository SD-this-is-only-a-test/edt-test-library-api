using System.ComponentModel.DataAnnotations;

namespace EdtTest.Data.Models
{
    public class LibraryMember
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// We may require the DoB if the library were to have age restricted content
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
