namespace EdtTest.LibraryAPI.Models
{
    public class ApiResponse<TResponseData>
    {
        public TResponseData? Data { get; set; }
        public string[] Errors { get; set; } = [];
    }
}
