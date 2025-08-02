namespace LOBRICO_A3_PRELIM.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        // 👇 ADD THESE
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
