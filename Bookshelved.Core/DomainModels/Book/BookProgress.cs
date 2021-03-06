﻿using System;
using Bookshelved.Core.DomainModels.Account;

namespace Bookshelved.Core.DomainModels.Book
{
    public class BookProgress
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string UserID { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? CurrentPage { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}