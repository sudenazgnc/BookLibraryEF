namespace BookLibraryEF.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public List<User> Users { get; set; }
    }
}
