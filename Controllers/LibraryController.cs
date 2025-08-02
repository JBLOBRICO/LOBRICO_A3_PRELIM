using LOBRICO_A3_PRELIM.Models;
using LOBRICO_A3_PRELIM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LOBRICO_A3_PRELIM.Controllers
{
    public class LibraryController : Controller
    {
        private static Library _library = new Library { LibraryId = 1, Location = "Main Street Library" };
        private static List<User> _users = new List<User>();

        static LibraryController()
        {
            var authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "J.K. Rowling" },
                new Author { AuthorId = 2, Name = "George Orwell" },
                new Author { AuthorId = 3, Name = "Jane Austen" },
                new Author { AuthorId = 4, Name = "Mark Twain" },
                new Author { AuthorId = 5, Name = "Isaac Asimov" }
            };

            var books = new List<Book>
            {
                new Book { BookId = 101, Title = "Harry Potter", ISBN = "1111111111", Genre = Genre.Fantasy, IsAvailable = false, Author = authors[0], AuthorId = authors[0].AuthorId, BorrowedDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(10) },
                new Book { BookId = 102, Title = "1984", ISBN = "2222222222", Genre = Genre.ScienceFiction, IsAvailable = true, Author = authors[1], AuthorId = authors[1].AuthorId },
                new Book { BookId = 103, Title = "Pride and Prejudice", ISBN = "3333333333", Genre = Genre.Romance, IsAvailable = true, Author = authors[2], AuthorId = authors[2].AuthorId },
                new Book { BookId = 104, Title = "Adventures of Tom Sawyer", ISBN = "4444444444", Genre = Genre.Fiction, IsAvailable = true, Author = authors[3], AuthorId = authors[3].AuthorId },
                new Book { BookId = 105, Title = "Foundation", ISBN = "5555555555", Genre = Genre.ScienceFiction, IsAvailable = false, Author = authors[4], AuthorId = authors[4].AuthorId, BorrowedDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(5) },
                new Book { BookId = 106, Title = "Emma", ISBN = "6666666666", Genre = Genre.Romance, IsAvailable = true, Author = authors[2], AuthorId = authors[2].AuthorId },
                new Book { BookId = 107, Title = "Animal Farm", ISBN = "7777777777", Genre = Genre.Fiction, IsAvailable = true, Author = authors[1], AuthorId = authors[1].AuthorId },
                new Book { BookId = 108, Title = "Huckleberry Finn", ISBN = "8888888888", Genre = Genre.Fiction, IsAvailable = true, Author = authors[3], AuthorId = authors[3].AuthorId },
                new Book { BookId = 109, Title = "I, Robot", ISBN = "9999999999", Genre = Genre.ScienceFiction, IsAvailable = true, Author = authors[4], AuthorId = authors[4].AuthorId },
                new Book { BookId = 110, Title = "Sense and Sensibility", ISBN = "1010101010", Genre = Genre.Romance, IsAvailable = false, Author = authors[2], AuthorId = authors[2].AuthorId, BorrowedDate = DateTime.Now.AddDays(-3), ReturnDate = DateTime.Now.AddDays(12) }
            };

            var user1 = new User
            {
                UserId = 1,
                Username = "Alice",
                Email = "alice@email.com",
                BorrowedBooks = new List<Book> { books[0], books[4] } // Harry Potter & Foundation
            };

            var user2 = new User
            {
                UserId = 2,
                Username = "Bob",
                Email = "bob@email.com",
                BorrowedBooks = new List<Book> { books[9] } // Sense and Sensibility
            };

            _library.Books.AddRange(books);
            _users.Add(user1);
            _users.Add(user2);
        }

        // 📚 Book List View
        public IActionResult BookList()
        {
            var books = _library.Books.Select(book =>
            {
                var borrower = _users.FirstOrDefault(u => u.BorrowedBooks.Contains(book));
                return new BookViewModel
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorName = book.Author?.Name ?? "Unknown",
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    Availability = book.IsAvailable ? "Available" : "Borrowed",
                    BorrowerName = borrower?.Username ?? "None"
                };
            }).ToList();

            return View(books);
        }

        // 👤 Borrower/User View
        public IActionResult User()
        {
            var model = _users.Select(user => new BorrowerViewModel
            {
                Username = user.Username,
                Email = user.Email,
                BorrowedBooks = user.BorrowedBooks.Select(book => new BorrowedBookInfo
                {
                    Title = book.Title,
                    AuthorName = book.Author?.Name ?? "Unknown",
                    BorrowedDate = book.BorrowedDate,
                    ReturnDate = book.ReturnDate,
                    Status = book.IsAvailable ? "Returned" : "Borrowed"
                }).ToList()
            }).ToList();

            return View("User", model);
        }
    }
}
