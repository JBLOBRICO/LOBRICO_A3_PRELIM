using System.Collections.Generic;

namespace LOBRICO_A3_PRELIM.Models
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Location { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
