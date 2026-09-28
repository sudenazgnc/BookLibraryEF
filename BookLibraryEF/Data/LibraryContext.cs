using Microsoft.EntityFrameworkCore;
using BookLibraryEF.Models;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Users)
            .WithMany(u => u.Books);

            modelBuilder.Entity<Author>().HasData(
            new Author { AuthorID = 1, AuthorName = "George Orwell", AuthorInfo = "English novelist and essayist, journalist and critic." },
            new Author { AuthorID = 2, AuthorName = "Harper Lee", AuthorInfo = "American novelist best known for To Kill a Mockingbird." },
            new Author { AuthorID = 3, AuthorName = "F. Scott Fitzgerald", AuthorInfo = "American essayist and short story writer." },
            new Author { AuthorID = 4, AuthorName = "J.D. Salinger", AuthorInfo = "American writer known for The Catcher in the Rye." },
            new Author { AuthorID = 5, AuthorName = "Jane Austen", AuthorInfo = "English novelist known primarily for her six major novels." },
            new Author { AuthorID = 6, AuthorName = "Unknown Author", AuthorInfo = "The author information for this book is not registered in the system." }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { BookID = 1, Title = "1984", ImageUrl = "/images/books/1984 Cover.jpg", ReleaseYear = 1949, Price = 3.1, AuthorID = 1 },
            new Book { BookID = 2, Title = "To Kill a Mockingbird", ImageUrl = "/images/books/To Kill A Mockingbird Cover.jpg", ReleaseYear = 1960, Price = 4.2, AuthorID = 2 },
            new Book { BookID = 3, Title = "The Great Gatsby", ImageUrl = "/images/books/The Great Gatsby Cover.jpg", ReleaseYear = 1925, Price = 3.6, AuthorID = 3 },
            new Book { BookID = 4, Title = "The Catcher in the Rye", ImageUrl = "/images/books/The Catcher in the Rye Cover.jpg", ReleaseYear = 1951, Price = 2.8, AuthorID = 4 },
            new Book { BookID = 5, Title = "Pride and Prejudice", ImageUrl = "/images/books/Pride and Prejudice Cover.jpg", ReleaseYear = 1813, Price = 4.5, AuthorID = 5 }
        );

        base.OnModelCreating(modelBuilder);
    }
}