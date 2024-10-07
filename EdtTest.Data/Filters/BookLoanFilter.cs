namespace EdtTest.Data.Filters
{
    public class BookLoanFilter
    {
        public int? BookCopyID { get; set; }
        public int? LibraryMemberID { get; set; }
        public BookLoanState LoanState { get; } = BookLoanState.All;
    }
}
