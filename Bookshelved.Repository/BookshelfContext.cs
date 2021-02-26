using Bookshelved.Core.DomainModels;
using Bookshelved.Core.DomainModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            modelBuilder.Entity<Reviews>()
                .ToTable("Reviews", "Book");

            #endregion Book Schema
        }
    }
}