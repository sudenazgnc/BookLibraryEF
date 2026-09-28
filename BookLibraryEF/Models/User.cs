namespace BookLibraryEF.Models;

public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }