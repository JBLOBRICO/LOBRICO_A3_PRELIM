using System.Collections.Generic;

namespace LOBRICO_A3_PRELIM.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
