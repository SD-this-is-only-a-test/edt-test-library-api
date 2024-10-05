using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdtTest.Data.Models
{
    public class BookLoan
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Copy))]
        public int CopyID { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberID { get; set; }

        /// <summary>
        /// The date that the book should be returned by
        /// </summary>
        public DateTime ReturnByDate { get; set; }

        /// <summary>
        /// The date that the book copy was returned, otherwise null
        /// </summary>
        public DateTime? ReturnedDate { get; set; }

        /// <summary>
        /// The book copy which has been loaned out
        /// </summary>
        public virtual BookCopy Copy { get; set; }

        /// <summary>
        /// The library member who has borrowed the book
        /// </summary>
        public virtual LibraryMember Member { get; set; }
    }
}
