namespace BookLibraryEF.Models;
public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorInfo { get; set; }
        public List<Book> Books { get; set; }
    }