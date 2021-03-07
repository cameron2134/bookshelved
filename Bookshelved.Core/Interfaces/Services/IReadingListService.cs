using System.Collections.Generic;
using Bookshelved.Core.DTOs.Account;

namespace Bookshelved.Core.Interfaces.Services
{
    public interface IReadingListService
    {
        IEnumerable<ReadingListDTO> GetUserReadingLists(string userID);
    }
}