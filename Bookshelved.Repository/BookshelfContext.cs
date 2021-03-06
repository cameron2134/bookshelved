using Bookshelved.Core.DomainModels.Account;
using Bookshelved.Core.DomainModels.Book;
using Microsoft.EntityFrameworkCore;

namespace Bookshelved.Repository
{
    public class BookshelfContext : DbContext
    {
        public BookshelfContext(DbContextOptions<BookshelfContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Book Schema

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books", "Book");

                entity.HasOne<Series>(o => o.Series)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.SeriesID)
                .HasConstraintName("FK_Book_Series");

                entity.HasOne<Author>(o => o.Author)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.AuthorID)
                .HasConstraintName("FK_Book_Author");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors", "Book");
            });

            modelBuilder.Entity<BookProgress>()
                .ToTable("BookProgress", "Book");

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("Series", "Book");
            });

            modelBuilder.Entity<BookReview>(entity =>
            {
                entity.ToTable("Reviews", "Book");

                entity.HasOne<Book>(o => o.Book)
                    .WithMany(o => o.Reviews)
                    .HasForeignKey(o => o.BookID)
                    .HasConstraintName("FK_Reviews_Books");
                
                entity.HasOne<ApplicationUser>(o => o.ApplicationUser)
                    .WithMany(o => o.BookReviews)
                    .HasForeignKey(o => o.UserId)
                    .HasConstraintName("FK_Reviews_AspNetUsers");
            });

            #endregion Book Schema

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("AspNetUsers", "dbo");
            });
        }
    }
}