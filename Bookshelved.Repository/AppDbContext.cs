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
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Book Schema

            modelBuilder.Entity<Book>()
                .ToTable("Books", "Book")
                .HasOne<Series>()
                .WithOne()
                .HasForeignKey("FK_Book_Series");

            // Author

            modelBuilder.Entity<BookProgress>()
                .ToTable("BookProgress", "Book");

            modelBuilder.Entity<Series>()
                .ToTable("Series", "Book");

            modelBuilder.Entity<Reviews>()
                .ToTable("Reviews", "Book");

            #endregion Book Schema
        }
    }
}