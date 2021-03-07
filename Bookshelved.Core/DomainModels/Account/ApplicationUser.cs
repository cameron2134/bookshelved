using System.Collections.Generic;
using Bookshelved.Core.DomainModels.Book;
using Microsoft.AspNetCore.Identity;

namespace Bookshelved.Core.DomainModels.Account
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Review> BookReviews { get; set; }
        public virtual ICollection<BookProgress> BookProgression { get; set; }
        public virtual ICollection<ReadingList> ReadingLists { get; set; }
    }
}