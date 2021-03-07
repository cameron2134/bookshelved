using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.DTOs.Book;
using Bookshelved.Core.Interfaces.Repos;
using Bookshelved.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _bookRepository = (IBookRepository)_unitOfWork.GetRepository<Book>();
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var allBooks = _bookRepository.Get();
            var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(allBooks);

            return mappedBooks;
        }

        public async Task<BookDetailsDTO> GetBookDetails(int id)
        {
            var book = await _bookRepository.GetBookDetails(id);
            return (book != null) ? _mapper.Map<BookDetailsDTO>(book) : null;
        }
    }
}