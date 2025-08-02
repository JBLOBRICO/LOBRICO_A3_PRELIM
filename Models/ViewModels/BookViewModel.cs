namespace LOBRICO_A3_PRELIM.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public LOBRICO_A3_PRELIM.Models.Genre Genre { get; set; }
        public string ISBN { get; set; }
        public string Availability { get; set; }
        public string BorrowerName { get; set; }
    }
}
