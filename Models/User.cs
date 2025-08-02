using System.Collections.Generic;

namespace LOBRICO_A3_PRELIM.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}
