using BookLibraryEF.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryEF.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
        }

        public IActionResult AddBook()
        {
            ViewBag.Authors = _context.Authors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RentBook()
        {
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Books = _context.Books.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult RentBook(int userId, int bookId)
        {
            var user = _context.Users.Include(u => u.Books).FirstOrDefault(u => u.UserID == userId);
            var book = _context.Books.Find(bookId);

            if (user != null && book != null)
            {
                bool alreadyRented = user.Books.Any(b => b.BookID == bookId);

                if (!alreadyRented)
                {
                    user.Books.Add(book); 
                    _context.SaveChanges();
                    return RedirectToAction("Index"); 
                }
                else
                { 
                    TempData["ErrorMessage"] = "Error: This user has already rented this book!";
                    return RedirectToAction("RentBook");
                }
            }

            return RedirectToAction("Index");
        }
    }
}