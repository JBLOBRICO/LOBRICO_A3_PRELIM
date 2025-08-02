namespace LOBRICO_A3_PRELIM.Models.ViewModels
{
    public class BorrowedBookInfo
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
    }

    public class BorrowerViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<BorrowedBookInfo> BorrowedBooks { get; set; }
    }
}
