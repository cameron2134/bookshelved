using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bookshelved.Core.DomainModels.Account;
using Bookshelved.Core.DTOs.Account;
using Bookshelved.Core.Interfaces.Repos;
using Bookshelved.Core.Interfaces.Services;
using Bookshelved.Repository;

namespace Bookshelved.Services
{
    public class ReadingListService : IReadingListService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ReadingList> _repo;

        public ReadingListService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.GetRepository<ReadingList>();
        }

        public IEnumerable<ReadingListDTO> GetUserReadingLists(string userID)
        {
            var results = _repo.Get(o => o.UserID == userID);
            return _mapper.Map<IEnumerable<ReadingListDTO>>(results);
        }
    }
}