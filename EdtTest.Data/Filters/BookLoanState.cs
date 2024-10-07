namespace EdtTest.Data.Filters
{
    public enum BookLoanState : byte
    {
        /// <summary>
        /// All loans regardless of return state.
        /// </summary>
        All = 0,
        /// <summary>
        /// Loans where the copy has not been returned.
        /// </summary>
        NotReturned = 1,
        /// <summary>
        /// Loans where the copy has been returned.
        /// </summary>
        Returned = 2,
    }
}
